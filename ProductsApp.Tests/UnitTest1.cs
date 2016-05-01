using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProductsCommon;

namespace ProductsApp.Tests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestMethod1() {
            var movieBusiness = new MovieBusiness();
            var movies = movieBusiness.ListMoviesByNameAndGenre(null, null);

        }
    }
}
