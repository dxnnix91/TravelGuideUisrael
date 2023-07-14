using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuideUisrael
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
		}

		private void btnRegistrar_Clicked(object sender, EventArgs e)
		{
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("Insert into usuario (nombre, apellido, edad, correo, clave) values('"+ txtNombre.Text +"','" + txtApellido.Text + "','" + txtEdad.Text + "','" + txtMail.Text + "','" + txtClave.Text + "')", conexion);
            var rd = cmd.ExecuteReader();

            var mensaje = "Datos Correctamente ingresados";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Login());
        }
	}
}