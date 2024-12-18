using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMobileApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QRMobileApp.Views;
using QRMobileApp.ViewModels;
using System.Collections.ObjectModel;

namespace QRMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsPage : ContentPage
    {
        public RestaurantsPage()
        {
            InitializeComponent();
            // FirestoreService ve ViewModel ayarı
            var firestoreService = new FirestoreService();
            this.BindingContext = new RestaurantsViewModel(firestoreService);
        }
    }
}