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
    public partial class CompanyDetailsPage : ContentPage
    {
        public TableViewModel ViewModel { get; set; }

        public CompanyDetailsPage(Company company)
        {
            InitializeComponent();

            // Eğer CompanyID string tipindeyse, int'e dönüştürme işlemi yapılmalı
            if (int.TryParse(company.CompanyID.ToString(), out int companyID))
            {
                ViewModel = new TableViewModel(new FireStoreTableService(), companyID);
            }
            else
            {
                // Dönüştürme başarısız olursa, hata yönetimi burada yapılabilir
                System.Diagnostics.Debug.WriteLine("Invalid CompanyID conversion");
            }

            BindingContext = ViewModel;
        }
    }
}