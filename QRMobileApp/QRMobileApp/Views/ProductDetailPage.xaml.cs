using QRMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(List<Product> products)
        {
            InitializeComponent();
            DisplayProducts(products);
        }

        private void DisplayProducts(List<Product> products)
        {
            // Ürünleri ListView'e ata
            ProductsListView.ItemsSource = products;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Seçilen ürünü al
            if (e.SelectedItem is Product selectedProduct)
            {
                // await Navigation.PushAsync(new ProductDetailPage(selectedProduct));
            }

            // Seçim sonrası, ListView'deki seçimi sıfırla
            ((ListView)sender).SelectedItem = null;
        }
    }
}