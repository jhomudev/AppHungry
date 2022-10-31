using AppHungry.Model;
using AppHungry.Services;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppHungry.ViewModel
{
    public class VMPlato
    {
        List<MPlato> Platos = new List<MPlato>();

        public async Task<List<MPlato>> MostrarPlatos()
        {
            var data = await Conexion.Firebase
                .Child("Platos") /*se llama al objeto Platos de la db Firebase*/
                .OrderByKey()
                .OnceAsync<MPlato>();
            foreach (var Datos in data)
            {
                MPlato parametros = new MPlato();
                parametros.Id_plato = Datos.Key;
                parametros.Nombre = Datos.Object.Nombre;
                parametros.LinkImage = Datos.Object.LinkImage;
                parametros.Genero = Datos.Object.Genero;
                parametros.Precio = Datos.Object.Precio;

                Platos.Add(parametros);
            }
            return Platos;
        }
        public async Task InsertarPlato(MPlato parametros)
        {
            await Conexion.Firebase
                .Child("Platos")
                .PostAsync(new MPlato()
                {
                    Nombre = parametros.Nombre,
                    Precio = parametros.Precio,
                    Genero = parametros.Genero,
                    LinkImage = parametros.LinkImage,
                });
        }
        public async Task EliminarPlato(MPlato parametros)
        {
            await Conexion.Firebase
                .Child("Platos")
                .Child(parametros.Id_plato)
                .DeleteAsync();
        }
        public async Task ModificarPlato(MPlato parametros)
        {
            await Conexion.Firebase
                 .Child("Platos")
                 .Child(parametros.Id_plato)
                 .PutAsync(new MPlato()
                 {
                     Id_plato = parametros.Id_plato,
                     Nombre = parametros.Nombre,
                     Precio = parametros.Precio,
                     Genero = parametros.Genero,
                     LinkImage = parametros.LinkImage,
                 }); ; ;

        }
    }
}
