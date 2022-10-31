using AppHungry.Model;
using AppHungry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHungry.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin : ContentPage
    {
        public Admin()
        {
            InitializeComponent();
            MostrarPlatos();
            Platos.RefreshCommand = new Command(() =>
            {
                Platos.IsRefreshing = true;
                MostrarPlatos();
                Thread.Sleep(1);
                Platos.IsRefreshing = false;
            });
        }
        private async Task MostrarPlatos()
        {
            VMPlato funcion = new VMPlato();
            var dt = await funcion.MostrarPlatos();
            Platos.ItemsSource = dt;
        }
        private void Addbtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NewFood());
        }

        private void Platos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Datos = e.Item as MPlato;
            Navigation.PushAsync(new Plato(Datos));
        }
    }
}