using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography.X509Certificates;

namespace TravelGuideUisrael
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Posteo : ContentPage
    {
        
        public Posteo()
        {
            InitializeComponent();
            
            
        }
        
        public void btnIngresar_Clicked(object sender, EventArgs e)
        {
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            String fecha = txtfecha.Date.ToString("yyyy/MM/dd");
            String fecha1 = txtfecha.Date.TimeOfDay.ToString();
            txtfoto.Text = fecha1 + "/" + fecha;            
            

            var cmd = new MySqlCommand("Insert into post (calificacion, comentario, imagen, fecha, Usuario_idUsuario) values('" + txtCalificacion.Text + "','" + txtcomentario.Text + "','"+txtfoto.Text+ "','" + fecha + "','" + txtid.Text + "')", conexion);
            var rd = cmd.ExecuteReader();

            var mensaje = "Datos Correctamente ingresados";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Home());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var categoria=new List<string>();
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("Select nombre From usuario", conexion);            
            var rd = cmd.ExecuteReader();            
            while (rd.Read())
            {
                categoria.Add(rd.GetString("nombre"));
                

            }
            rd.Close();
            combousuario.ItemsSource= categoria;
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
                txtid.Text = rd.GetInt32(0).ToString();
            }
            rd.Close();
        }

        private void btnFoto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync (new Foto());
            String fecha = txtfecha.Date.ToString("yyyy/MM/dd");
            String fecha1 = txtfecha.Date.TimeOfDay.ToString();
            txtfoto.Text = fecha1+"/"+fecha;
        }

        private void txtfecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            String fecha = txtfecha.Date.ToString("yyyy/MM/dd");
            txtfoto.Text = fecha;
        }
    }
}