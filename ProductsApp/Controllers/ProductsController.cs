using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Common.Model;

namespace ProductsApp.Controllers {
    public class ProductsController : ApiController {

        private readonly Product[] m_products = {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Food", Price = 1m},
            new Product {Id = 2, Name = "Pen", Category = "Stationery", Price = 2.5m},
            new Product {Id = 3, Name = "Onion", Category = "Food", Price = 0.8m}
        };

        // This is mapped to /api/products
        [HttpGet]
        public IEnumerable<Product> GetAllProducts() {
            return m_products;
        }

        // Mapped to /api/products/id
        public IHttpActionResult GetProduct(int id) {
            var product = m_products.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                // returns NotFoundResult
                return NotFound();
            }
            // Returns OkNegotiatedContentResult
            return Ok(product);
        }

        // this is mapped to /api/products?name=xxx // the parameter name in the query string has to match 
        // otherwise the other -- default (GetAllProducts) method is called
        [HttpGet]
        public IHttpActionResult GetByName(string name) {
            if (name == null) {
                return Ok(m_products);
            }

            var product = m_products.FirstOrDefault(p => p.Name.Contains(name));
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }

        // matches /api/products?name=xxx&price=yyy
        // Both parameters name and price have to be present. The order does not matter.
        // If only name is present, the GetByName method is called
        // If only price is present, there is no matching method yet, so GetAllProducts is called.
        [HttpGet]
        public IHttpActionResult GetByNameAndPrice(string name, string price) {
            if (name == null && price == null) {
                return Ok(m_products);
            }
            Product product;
            decimal parsedPrice;
            if (name == null) {
                if (!decimal.TryParse(price, out parsedPrice)) {
                    return NotFound();
                }
                product = m_products.FirstOrDefault(p => p.Price == parsedPrice);
                if (product == null) {
                    return NotFound();
                }
                return Ok(product);
            }

            if (price == null) {
                product = m_products.FirstOrDefault(p => p.Name.Contains(name));
                if (product == null) {
                    return NotFound();
                }
                return Ok(product);
            }

            if (!decimal.TryParse(price, out parsedPrice)) {
                return NotFound();
            }
            product = m_products.FirstOrDefault(p => p.Name.Contains(name) && p.Price == parsedPrice);
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
