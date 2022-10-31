using AppHungry.View;
using AppHungry.View.Tutorial;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHungry
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Presentacion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
