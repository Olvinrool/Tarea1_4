using Microsoft.Maui.Controls;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using Tarea1_4.Models;
using Tarea1_4.Services;

namespace Tarea1_4
{
    public partial class MainPage : ContentPage
    {
        DatabaseService databaseService;

        public object FotosListView { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "fotos.db3"));
            CargarFotos();
        }

        async void TomarFoto_Clicked(object sender, EventArgs e)
        {
            var mediaOptions = new StoreCameraMediaOptions
            {
                SaveToAlbum = false,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Rear
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

            if (foto != null)
            {
                var rutaImagen = foto.Path;
                var nombre = "Nombre de la foto"; 
                var descripcion = "Descripción de la foto"; 
                GuardarFotoEnBaseDeDatos(rutaImagen, nombre, descripcion);
                CargarFotos();
            }
        }

        async void GuardarFotoEnBaseDeDatos(string rutaImagen, string nombre, string descripcion)
        {
            var nuevaFoto = new Foto
            {
                RutaImagen = rutaImagen,
                Nombre = nombre,
                Descripcion = descripcion
            };

            await databaseService.SaveFotoAsync(nuevaFoto);
        }

        async void CargarFotos()
        {
            var fotos = await databaseService.GetFotosAsync();
            FotosListView = fotos;
        }

        async void VerRegistros_Clicked(object sender, EventArgs e)
        {
            
        }

        async void FotosListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }
    }
}
