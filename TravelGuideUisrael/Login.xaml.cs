using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySqlConnector;
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
            //String usuario = txtusuario.Text;
            //String correo = txtcontraseña.Text;

            //if (txtusuario.Text == "admin" && txtcontraseña.Text == "123")
            //{
            //    Navigation.PushAsync(new Home());
            //}
            //else
            //{
            //    var mensaje = "Datos erroneos!!!";
            //    DependencyService.Get<Mensaje>().longAlert(mensaje);
            //}
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("Select * From usuario where correo='" + txtusuario.Text + "'and clave='" + txtcontraseña.Text + "'", conexion);
            var rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                
                var mensaje = "Datos Correctos";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new Home());
            }
            else
            {
                var mensaje = "Datos Incorrectos";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
            }
        }
        private void Conexion()
        {
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("Select * From usuario where correo='" + txtusuario.Text + "'and clave='" + txtcontraseña.Text + "'", conexion);
            var rd = cmd.ExecuteReader();

            if(rd.Read())
                 {
                DisplayAlert("Information", "Login succes", "OK");
            }
            else
            {
                DisplayAlert("Information", "Login not succes", "OK");
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