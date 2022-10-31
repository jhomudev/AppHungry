using AppHungry.View.Tutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHungry.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Presentacion : ContentPage
    {
        public Presentacion()
        {
            InitializeComponent();
            Animacion();
        }
        public async Task Animacion()
        {
            iconApp.Opacity = 0;
            await iconApp.FadeTo(1, 5000);
            //App.Current.MainPage = new NavigationPage(new Introduccion());
            await this.Navigation.PushAsync(new Introduccion());
        }
    }
}