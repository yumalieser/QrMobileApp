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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        // Restoranlar Butonuna Tıklanınca
        private async void OnRestaurantsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RestaurantsPage());
        }

        // QR Okut Butonuna Tıklanınca
        private async void OnScanQRCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QRScannerPage());
        }

        // Tüm Ürünler Butonuna Tıklanınca
        private async void OnAllProductsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }
    }
}