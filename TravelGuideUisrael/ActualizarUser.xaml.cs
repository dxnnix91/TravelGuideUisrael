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
    public partial class ActualizarUser : ContentPage
    {
        public ActualizarUser()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("UPDATE usuario SET nombre = '" + txtNombre.Text + "', apellido = '" + txtApellido.Text + "', edad = '" + txtEdad.Text + "', correo = '" + txtMail.Text + "', clave = '" + txtClave.Text + "' WHERE idUsuario = "+ iduser.Text, conexion);
            var rd = cmd.ExecuteReader();

            var mensaje = "Datos Correctamente Actualizados";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Home());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var categoria = new List<string>();
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("Select nombre From usuario", conexion);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                categoria.Add(rd.GetString("nombre"));


            }
            rd.Close();
            combousuario.ItemsSource = categoria;
            conexion.Close();
        }
        private void combousuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaid = combousuario.SelectedItem.ToString();
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Close();
            conexion.Open();

            var cmd = new MySqlCommand("Select * from usuario where nombre='" + categoriaid + "'", conexion);
            var rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                iduser.Text = rd.GetInt32(0).ToString();
            }
            rd.Close();

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            
            try
            {
                var cmd = new MySqlCommand("DELETE FROM usuario WHERE idUsuario =" + iduser.Text, conexion);
                var rd = cmd.ExecuteReader();
                rd.Read();
                
                    var mensaje = "Usuario Eliminado";
                    DependencyService.Get<Mensaje>().longAlert(mensaje);
                    Navigation.PushAsync(new Home());

                
            }
            catch (Exception)
            {

                var mensaje = "No puedes eliminar un ususario con posts activos";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
            }
        }
    }
}
