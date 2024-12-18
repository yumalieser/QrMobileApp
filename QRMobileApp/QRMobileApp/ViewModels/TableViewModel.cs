using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using QRMobileApp.Services;
using Xamarin.Forms;

namespace QRMobileApp.ViewModels
{
    public class TableViewModel
    {
        private readonly FireStoreTableService _firestoreService;

        public ObservableCollection<Table> Tables { get; set; }

        public TableViewModel(FireStoreTableService firestoreService, int companyID)
        {
            _firestoreService = firestoreService;
            Tables = new ObservableCollection<Table>();

            LoadTables(companyID);
        }

        private async void LoadTables(int companyID)
        {
            var tablesList = await _firestoreService.GetTablesAsync(companyID);
            if (tablesList != null && tablesList.Count > 0)
            {
                foreach (var table in tablesList)
                {
                    Tables.Add(table);
                }
            }
        }
    }
}