using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRMobileApp.Models;
using Xamarin.Forms;


namespace QRMobileApp.Services
{
    public class FirestoreService
    {
        private readonly HttpClient _httpClient;
        private const string FirestoreUrl = "https://firestore.googleapis.com/v1/projects/qrmobileappv1/databases/(default)/documents/companies";
        private readonly string _apiKey = "AIzaSyDtDi2D1vaCOtJZma4fM58hhFwhBUzfvqo"; // Firebase API anahtarınızı buraya ekleyin

        public FirestoreService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            var response = await _httpClient.GetAsync($"{FirestoreUrl}?key={_apiKey}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var firestoreResponse = JsonConvert.DeserializeObject<FirestoreResponse>(json);

            return firestoreResponse.Documents.Select(doc => new Company
            {
                CompanyID = doc.Fields["CompanyID"].StringValue,
                CompanyName = doc.Fields["CompanyName"].StringValue
            }).ToList();
        }
    }

    public class FirestoreResponse
    {
        public List<FirestoreDocument> Documents { get; set; }
    }

    public class FirestoreDocument
    {
        public Dictionary<string, FirestoreField> Fields { get; set; }
    }

    public class FirestoreField
    {
        [JsonProperty("stringValue")]
        public string StringValue { get; set; }
    }

    public class Company
    {
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}