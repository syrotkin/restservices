﻿using System;
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

using ProductsApp.Models;

namespace ProductApiClient {
    class ProductApiClientProgram {
        static void Main(string[] args) {

            CallApiMethods();


            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static async void CallApiMethods() {
            const string baseUrl = "http://localhost:38223/";

            using (var httpClient = new HttpClient()) {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.Timeout = new TimeSpan(0, 10, 0); // 10 minutes
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                const string productUrl = "api/products/";
                var productList = await RetrieveAllProducts(httpClient, productUrl);

                int id = 5;
                var product = await RetrieveProductById(httpClient, productUrl, 2);
                if (product == null) {
                    Console.WriteLine("No product with Id = " + id);
                } else {
                    Console.WriteLine("Retrieved product " + product.Name + ", price: " + product.Price);
                }


            }

        }

        private static async Task<Product> RetrieveProductById(HttpClient httpClient,
                string productUrl,
                int id) {
            var request = new HttpRequestMessage(HttpMethod.Get, productUrl + id);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);
            return product;
        }

        private static async Task<List<Product>> RetrieveAllProducts(
                HttpClient httpClient,
                string allProductsUrl) {
            var request = new HttpRequestMessage(HttpMethod.Get, allProductsUrl);
            // if sending a POST request, specify the content
            //request.Content = new StringContent();
            //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<Product>>(content);
            return productList;
        }

    }
}
