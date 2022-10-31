using AppHungry.Model;
using AppHungry.ViewModel;
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
    public partial class NewFood : ContentPage
    {
        string SelectedItem;
        public NewFood()
        {
            InitializeComponent();
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            bool condicion = string.IsNullOrEmpty(FoodName.Text) || string.IsNullOrEmpty(FoodPrecio.Text) || string.IsNullOrEmpty(FoodImageLink.Text);
            if (condicion)
            {
                DisplayAlert("Campos Vacios", "Complete todos los campos", "OK");
            }
            else
            {
                InsertarPlato();
                this.Navigation.PopAsync();
            }
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {

        }
        private void FoodGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            var valor = selectedItem.ToString();
            SelectedItem = valor;
        }
        private async Task InsertarPlato()
        {
            VMPlato funcion = new VMPlato();
            MPlato parametros = new MPlato();
            parametros.Nombre = FoodName.Text;
            parametros.Genero =SelectedItem;
            parametros.Precio =Convert.ToDecimal(FoodPrecio.Text);
            parametros.LinkImage = FoodImageLink.Text;
            await funcion.InsertarPlato(parametros);
            await DisplayAlert("Listo", "Creada con Exito", "OK");
        }

        
    }
}