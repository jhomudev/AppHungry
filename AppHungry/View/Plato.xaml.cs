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
    public partial class Plato : ContentPage
    {
        string nombre, genero, image, id, SelectedItem;
        decimal precio;
        bool ConfirmDelete=false;

        public Plato(MPlato Datos)
        {
            InitializeComponent();
            nombre = Datos.Nombre;
            precio = Datos.Precio;
            image = Datos.LinkImage;
            genero = Datos.Genero;
            id = Datos.Id_plato;
            _image.Source = image;
            FoodGeneroLabel.Text = genero;
            FoodName.Text = nombre;
            FoodPrecio.Text = precio.ToString();
            FoodImageLink.Text = image;
            DisabledEntries();
        }
        
        //private async Task SaveButton_Clicked(object sender, EventArgs e)
        //{
        //    //await ActualizarPlato();
        //    //await DisplayAlert("Listo", "Plato modificado.", "OK");
        //    //await this.Navigation.PopAsync();
        //}

        private void FoodGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            var valor = selectedItem.ToString();
            SelectedItem = valor;
        }

        private void TopButtonedit_Clicked(object sender, EventArgs e)
        {
            EnabledEntries();
        }

        private void TopButtondelete_Clicked(object sender, EventArgs e)
        {
            EliminarPlato();
            this.Navigation.PopAsync();
            
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            ActualizarPlato();
            this.Navigation.PopAsync();
        }

        private void EnabledEntries()
        {
            FoodGenero.InputTransparent = false;
            FoodPrecio.InputTransparent = false;
            FoodImageLink.InputTransparent = false;
            FoodGeneroLabel.HeightRequest = 0;
            FoodGenero.HeightRequest = 50;
            SaveButton.IsEnabled = true;
            FoodName.Focus();
        }
        private void DisabledEntries()
        {
            FoodGenero.InputTransparent = true;
            FoodPrecio.InputTransparent = true;
            FoodImageLink.InputTransparent = true;
            FoodGeneroLabel.HeightRequest = 30;
            SaveButton.IsEnabled = false;
        }
        
        private async Task EliminarPlato()
        {
            VMPlato funcion = new VMPlato();
            MPlato parametros = new MPlato();
            parametros.Nombre = nombre;
            parametros.Genero = genero;
            parametros.Precio = precio;
            parametros.Id_plato= id;
            parametros.LinkImage = image;
            await funcion.EliminarPlato(parametros);
            await DisplayAlert("Alert", "Plato eliminado", "OK");
        }
        private async Task ActualizarPlato()
        {
            VMPlato funcion = new VMPlato();
            MPlato parametros = new MPlato();
            parametros.Nombre = FoodName.Text;
            parametros.Genero = SelectedItem;
            parametros.Precio = Convert.ToDecimal(FoodPrecio.Text);
            parametros.Id_plato = id;
            parametros.LinkImage = FoodImageLink.Text;
            await funcion.ModificarPlato(parametros);
            await DisplayAlert("Listo", "Plato modificado con éxito", "OK");
        }
    }
}