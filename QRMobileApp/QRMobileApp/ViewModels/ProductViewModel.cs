using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMobileApp.Models;
using QRMobileApp.Services;
using Xamarin.Forms;

namespace QRMobileApp.ViewModels
{
    public class ProductViewModel
    {
        private readonly FirestoreProductService _fireStoreService;

        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel(FirestoreProductService fireStoreService)
        {
            _fireStoreService = fireStoreService;
            Products = new ObservableCollection<Product>();
        }

        public async Task LoadProductsAsync()
        {
            try
            {
                Debug.WriteLine("LoadProductsAsync çalışıyor...");
                var products = await _fireStoreService.GetProductsAsync();

                if (products != null && products.Count > 0)
                {
                    foreach (var product in products)
                    {
                        Products.Add(product);
                    }
                }
                else
                {
                    Debug.WriteLine("Ürünler listesi boş.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadProductsAsync hatası: {ex.Message}");
            }
        }
    }
}