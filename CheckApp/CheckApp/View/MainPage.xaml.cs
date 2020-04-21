using CheckApp.Models;
using CheckApp.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        private ObservableCollection<MasterPageItem> _menuItem;
        public MainPage()
        {
            InitializeComponent();
            
            _menuItem = MenuItemPage.GetMasterPageItems();
            navigationMenuItem.ItemsSource = _menuItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (MasterPageItem)e.SelectedItem;

            Type pagina = itemSelected.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(pagina));
            IsPresented = false;
        }        
    }
}
