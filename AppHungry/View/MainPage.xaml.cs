using AppHungry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppHungry
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            FlyoutMenu.listview.ItemSelected += OnSelectedItem;
        }
        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ItemMenu;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage)) { BarBackgroundColor = Color.MidnightBlue}; ;
                FlyoutMenu.listview.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
