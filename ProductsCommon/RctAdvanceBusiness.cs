using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SimpleImpersonation;
using System.Data.SqlClient;
using System.Data.Common;
using Common.Model;

namespace Common
{
    /// <summary>
    /// Class for calling RCT Advance stored procedures.
    /// </summary>
    public class RctAdvanceBusiness
    { 
        // TODO-osy: in app.config / web.config
        private const string connectionString = "Data Source=CHKDS1RCTADVANCE.emea.zurich.dev,1282; Initial Catalog=CHKDS1RCTADVANCE; integrated security=SSPI";
        private const string DOMAIN = "ezcorp";
        private const string USERNAME = "w1011020";
        private const string PASSWORD = "YvgPlys15";

        // TODO-osy: Use Entity Framework
        public IList<Contact> FindAccountContacts(string accountId)
        {
            const string storedProcedureName = "sp_findAccountContacts";
            var contacts = new List<Contact>();
            // IMPORTANT: You have to use LogonType.NewCredentials!!!
            // http://stackoverflow.com/questions/559719/windows-impersonation-from-c-sharp
            using (var impersonation = Impersonation.LogonUser(DOMAIN, USERNAME, PASSWORD, LogonType.NewCredentials))
            {
                using (DbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@accountID", accountId));
                        using (var dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var contact = new Contact();
                                contact.ContactId = Convert.ToString(dataReader["contactID"]);
                                contact.FirstName = Convert.ToString(dataReader["firstName"]);
                                contact.LastName = Convert.ToString(dataReader["lastName"]);
                                contact.ContactType = Convert.ToString(dataReader["contactType"]);
                                contact.Function = Convert.ToString(dataReader["function"]);
                                contacts.Add(contact);
                            }
                        }
                    }
                }
            }
            return contacts;
        }

        public void ImpersonateUser()
        {
            string currentUser = WindowsIdentity.GetCurrent().Name;
            using (var impersonation =  Impersonation.LogonUser(DOMAIN, USERNAME, PASSWORD, LogonType.Network))
            {
                var impersonatedUser = WindowsIdentity.GetCurrent().Name;
            }
        }
    }


}
