using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMobileApp.Services;
using Xamarin.Forms;

namespace QRMobileApp.ViewModels
{
    public class RestaurantsViewModel
    {
        private readonly FirestoreService _firestoreService;

        // Şirket verilerini tutan koleksiyon
        public ObservableCollection<Company> Companies { get; private set; }

        public RestaurantsViewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
            Companies = new ObservableCollection<Company>();

            // Veriyi yükle
            Task.Run(async () => await LoadCompanies());
        }

        private async Task LoadCompanies()
        {
            try
            {
                var companiesList = await _firestoreService.GetCompaniesAsync();
                if (companiesList != null && companiesList.Count > 0)
                {
                    // UI Thread üzerinde ekleme
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        foreach (var company in companiesList)
                        {
                            Companies.Add(company);
                        }
                    });
                    Debug.WriteLine($"Toplam Şirket Sayısı: {Companies.Count}");
                }
                else
                {
                    Debug.WriteLine("Şirket verisi boş.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Veri yüklenirken hata oluştu: {ex.Message}");
            }
        }
    }
}