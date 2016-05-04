using Common;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class RctAdvanceController : ApiController
    {
        // Also see WebApiConfig for Routing -- specifying "ActionApi"
        // /api/rctadvance/findAccountContacts?accountId=xxxx
        // e.g. http://localhost:38223/api/rctadvance/findaccountcontacts?accountId=027123T183703777
        [HttpGet]
        [ActionName("findAccountContacts")]
        public IEnumerable<Contact> FindAccountContacts(string accountId)
        {
            var rctBusiness = new RctAdvanceBusiness();
            return rctBusiness.FindAccountContacts(accountId);
        }
    }
}
