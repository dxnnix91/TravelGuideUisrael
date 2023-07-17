using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;
using System.Net.NetworkInformation;

namespace TravelGuideUisrael
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetail : ContentPage
    {
        private Pin pin;
        public HomeDetail()
        {
           

        InitializeComponent();

            

            // Definir la ubicación y zoom inicial del mapa
            mymap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.791235, -122.394207), Distance.FromKilometers(2)));

            // Obtener la ubicación actual del dispositivo
            GetDeviceLocation();

            // Agregar un controlador de eventos para el evento MapClicked
            mymap.MapClicked += Mapa_MapClicked;

            // Agregar el mapa al contenido de la página
            Content = new StackLayout
            {
                Children = { mymap }
            };

        }

        private void Mapa_MapClicked(object sender, MapClickedEventArgs e)
        {
            // Eliminar el PIN anterior si existe
            if (pin != null)
                mymap.Pins.Remove(pin);

            // Crear un nuevo PIN en la ubicación donde se hizo clic
            pin = new Pin
            {
                Position = e.Position,
                Label = "Nuevo PIN",
                Address = "Dirección del PIN"
            };

            // Agregar el nuevo PIN al mapa
            mymap.Pins.Add(pin);
            Navigation.PushAsync(new Posteo());
        }

        public async void GetDeviceLocation()
        {
            try
            {
                // Verificar y solicitar los permisos de ubicación necesarios
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted)
                        return;
                }

                // Obtener la última ubicación conocida del dispositivo
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    // Mover el mapa a la ubicación actual del dispositivo
                    mymap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(2)));

                    // Agregar un PIN en la ubicación actual
                    var pin = new Pin
                    {
                        Position = new Position(location.Latitude, location.Longitude),
                        Label = "Ubicación actual",
                        Address = "Tu ubicación"
                    };
                    
                    mymap.Pins.Add(pin);
                    
                }
            }
            catch (FeatureNotSupportedException)
            {
                // El dispositivo no admite la geolocalización
                // Manejar el caso de error según sea necesario
            }
            catch (PermissionException)
            {
                // Permiso denegado por el usuario
                // Manejar el caso de error según sea necesario
            }
            catch (Exception)
            {
                // Ocurrió un error al obtener la ubicación
                // Manejar el caso de error según sea necesario
            }
        }
    }
}
