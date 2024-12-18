using QRMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace QRMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QRScannerPage : ContentPage
	{
		public QRScannerPage ()
		{
			InitializeComponent ();
		}

        // QR kod okuma sonucunu işleme
        //private void Handle_OnScanResult(Result result)
        //{
        //    // QR kod okuma işlemini durdurma
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await DisplayAlert("QR Kodu", result.Text, "Tamam");
        //        scannerView.IsScanning = false; // Tarama işlemini durdur
        //    });
        //}
        private async void Handle_OnScanResult(Result result)
        {
            //int urunId = int.Parse(result.Text); // QR kod içeriğini ürüne ait ID olarak kabul ediyoruz

            //var productService = new ProductService();
            //var urun = await productService.GetUrunById(urunId);

            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await DisplayAlert("Ürün Bilgileri", $"Ürün Adı: {urun.UrunAdi}\nFiyat: {urun.Fiyat}\nAçıklama: {urun.Aciklama}", "Tamam");
            //    scannerView.IsScanning = false;
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            scannerView.IsScanning = true; // Sayfa açıldığında QR kod okuyucuyu başlat
        }

        protected override void OnDisappearing()
        {
            scannerView.IsScanning = false; // Sayfa kapandığında QR kod okuyucuyu durdur
            base.OnDisappearing();
        }
    }
}