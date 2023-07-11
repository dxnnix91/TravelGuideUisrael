using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuideUisrael
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnpost_Clicked(object sender, EventArgs e)
        {
            if (txtusuario.Text=="admin" && txtcontraseña.Text=="123")
            {
                Navigation.PushAsync(new Home());
            }
            else
            {
                var mensaje = "Datos erroneos!!!";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnlogingoogle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync (new LoginPage());
        }
    }
}