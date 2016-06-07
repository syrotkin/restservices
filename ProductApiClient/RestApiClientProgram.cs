using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Common.Model;

namespace ProductApiClient
{
    class RestApiClientProgram
    {
        static void Main(string[] args)
        {
             CallApiMethods();
            //Task<IEnumerable<Contact>> task = CallStoredProcedures();
            //var contacts = task.Result;


            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static IEnumerable<Contact> CallStoredProcedures()
        {
            const string accountId = "027123T183703777";
            const string baseUrl = "http://localhost:38223/api/rctadvance/";
            string storedProcedureName = string.Format("findaccountcontacts?accountId={0}", accountId);

            // This is used for Windows authentication
            var httpHandler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            using (var httpClient = new HttpClient(httpHandler))
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var request = new HttpRequestMessage(HttpMethod.Get, storedProcedureName))
                {
                    httpClient.SendAsync(request).ContinueWith(sendTask =>
                    {
                        var response = sendTask.Result;
                        response.EnsureSuccessStatusCode();
                        response.Content.ReadAsStringAsync().ContinueWith(readTask =>
                        {
                            var content = readTask.Result;
                            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(content);
                            return contacts;
                        });
                        return Enumerable.Empty<Contact>();
                    });
                }
                return Enumerable.Empty<Contact>();
            }
        }

        private static async void CallApiMethods()
        {
            // TODO-osy: make it a config value
            //const string baseUrl = "http://localhost:38223/";
            const string baseUrl = "http://localhost/publishedapplications/";
            const string apiUrl = "api/products/";
            int productId = 5;

            var httpHandler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            using (var httpClient = new HttpClient(httpHandler))
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.Timeout = new TimeSpan(0, 10, 0); // 10 minutes
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var productList = await RetrieveAllProducts(httpClient, apiUrl);

                var product = await RetrieveProductById(httpClient, apiUrl, productId);
                if (product == null)
                {
                    Console.WriteLine("No product with Id = " + productId);
                }
                else
                {
                    Console.WriteLine("Retrieved product " + product.Name + ", price: " + product.Price);
                }
            }
        }

        private static async Task<Product> RetrieveProductById(HttpClient httpClient,
                string productUrl,
                int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, productUrl + id);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);
            return product;
        }

        private static async Task<List<Product>> RetrieveAllProducts(
                HttpClient httpClient,
                string allProductsUrl)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, allProductsUrl))
            {
                // if sending a POST request, specify the content
                //request.Content = new StringContent();
                //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                using (HttpResponseMessage response = await httpClient.SendAsync(request))
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var productList = JsonConvert.DeserializeObject<List<Product>>(content);
                    return productList;
                }
            }
        }

    }
}
