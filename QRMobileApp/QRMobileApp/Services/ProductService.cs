using Newtonsoft.Json;
using QRMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QRMobileApp.Services
{

    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private const string FirestoreUrl = "https://firestore.googleapis.com/v1/projects/qrwebappv1/databases/(default)/documents/products";
        private const string ApiKey = "AIzaSyDtDi2D1vaCOtJZma4fM58hhFwhBUzfvqo"; // Firebase API anahtarınızı buraya ekleyin

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                // Firebase JSON formatına uygun hale getirme
                var json = JsonConvert.SerializeObject(new
                {
                    fields = new
                    {
                        Name = new { stringValue = product.Name },
                        Price = new { doubleValue = product.Price }
                    }
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{FirestoreUrl}?key={ApiKey}", content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP hatası: {httpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ürün oluşturulurken hata oluştu: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Product>> GetAllProducts(string apiUrl)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(apiUrl);
                var firestoreResponse = JsonConvert.DeserializeObject<FirestoreResponse>(response);

                if (firestoreResponse != null && firestoreResponse.Documents.Count > 0)
                {
                    return firestoreResponse.Documents.Select(doc => new Product
                    {
                        Name = doc.Fields.Name.StringValue,
                        Price = doc.Fields.Price.IntegerValue != null ? Convert.ToInt32(doc.Fields.Price.IntegerValue) : 0 // Eğer IntegerValue null ise 0 olarak ayarla
                    }).ToList();
                }

                return new List<Product>(); // Boş liste döndür
            }
            catch (Exception ex)
            {
                // Hata mesajını konsola yazdır
                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
                return new List<Product>(); // Hata durumunda boş liste döndür
            }
        }
    }
}
