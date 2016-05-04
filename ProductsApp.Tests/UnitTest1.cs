using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Common;

namespace ProductsApp.Tests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestMovieBusiness() {
            var movieBusiness = new MovieBusiness();
            var movies = movieBusiness.ListMoviesByNameAndGenre(null, null);

        }
        
        [TestMethod]
        public void TestImpersonation()
        {
            var rctBusiness = new RctAdvanceBusiness();
            rctBusiness.ImpersonateUser();
        }

        [TestMethod]
        public void TestFindAccountContacts()
        {
            var rctBusiness = new RctAdvanceBusiness();
            var contacts = rctBusiness.FindAccountContacts("027123T183703777");
        }
    }
}
