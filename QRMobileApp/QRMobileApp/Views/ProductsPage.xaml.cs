using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMobileApp.Services;
using QRMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private ProductViewModel _viewModel;

        public ProductsPage()
        {
            InitializeComponent();
            _viewModel = new ProductViewModel(new FirestoreProductService());
            BindingContext = _viewModel;

            LoadProductsAsync();
        }
        private async void LoadProductsAsync()
        {
            await _viewModel.LoadProductsAsync();
        }
    }
}