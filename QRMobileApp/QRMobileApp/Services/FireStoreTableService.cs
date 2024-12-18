using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace QRMobileApp.Services
{
    public class FireStoreTableService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://firestore.googleapis.com/v1/projects/qrmobileappv1/databases/(default)/documents/tables";
        private const string ApiKey = "AIzaSyDtDi2D1vaCOtJZma4fM58hhFwhBUzfvqo"; // API anahtarınız

        public FireStoreTableService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Table>> GetTablesAsync(int companyID)
        {
            var tables = new List<Table>();
            try
            {
                // Firestore'a filtreli sorgu
                var json = new JObject(
                    new JProperty("structuredQuery",
                        new JObject(
                            new JProperty("from",
                                new JArray(
                                    new JObject(
                                        new JProperty("collectionId", "tables")))),
                            new JProperty("where",
                                new JObject(
                                    new JProperty("fieldFilter",
                                        new JObject(
                                            new JProperty("field",
                                                new JObject(
                                                    new JProperty("fieldPath", "CompanyID"))),
                                            new JProperty("op", "EQUAL"),
                                            new JProperty("value",
                                                new JObject(
                                                    new JProperty("integerValue", companyID))))))))));

                var content = new StringContent(json.ToString(), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{BaseUrl}:runQuery?key={ApiKey}", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JObject.Parse(responseBody);

                    var documentsArray = jsonResponse["documents"];
                    if (documentsArray != null && documentsArray.Count() > 0)
                    {
                        foreach (var doc in documentsArray)
                        {
                            var fields = (JObject)doc["fields"];
                            tables.Add(new Table
                            {
                                TableID = (int)fields["TableID"]["integerValue"],
                                TableName = (string)fields["TableName"]["stringValue"],
                                TableSpending = (int)fields["TableSpending"]["integerValue"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
            }
            return tables;
        }
    }
    public class Table
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int TableSpending { get; set; }
    }
}