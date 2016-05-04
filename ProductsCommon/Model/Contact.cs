using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// Class to be returned by the REST service. This is not a complete Contact Entity, 
    /// but a collection of properties useful for the stored procedure
    /// </summary>
    public class Contact
    {
        [JsonProperty("contactID")]
        public string ContactId { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("contactType")]
        public string ContactType { get; set; }

        [JsonProperty("function")]
        public string Function { get; set; }
    }
}
