using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using QRMobileApp.Models;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace QRMobileApp.Services
{
    public class FirestoreProductService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://firestore.googleapis.com/v1/projects/qrmobileappv1/databases/(default)/documents/products";
        private const string ApiKey = "AIzaSyDtDi2D1vaCOtJZma4fM58hhFwhBUzfvqo"; // API anahtarınız buraya ekleyin

        public FirestoreProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = new List<Product>();
            try
            {
                var jsonResponse = await _httpClient.GetStringAsync("https://firestore.googleapis.com/v1/projects/qrmobileappv1/databases/(default)/documents/products");
                var documents = JToken.Parse(jsonResponse)["documents"];

                if (documents != null && documents.HasValues)
                {
                    foreach (var doc in documents)
                    {
                        var fields = doc["fields"];

                        // Null kontrolü ekleyin
                        if (fields != null)
                        {
                            var productNameToken = fields["name"];
                            var priceToken = fields["price"];

                            // Null kontrolü ekleyin ve doğru tür dönüşümü
                            if (productNameToken != null && priceToken != null && priceToken["integerValue"] != null)
                            {
                                string productName = productNameToken["stringValue"].ToString();
                                int price = (int)priceToken["integerValue"];

                                // Konsolda kontrol
                                Console.WriteLine($"Product: {productName}, Price: {price}");

                                products.Add(new Product
                                {
                                    Name = productName,
                                    Price = price
                                });
                            }
                            else
                            {
                                Console.WriteLine("Missing 'name' or 'price' field in document.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fields are null for document.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No documents found.");
                }
            }
            catch (Exception ex)
            {
                // Hataları loglayın
                Console.WriteLine($"Error fetching products: {ex.Message}");
            }

            return products;
        }
    }
}
