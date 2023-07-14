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
    public partial class Posteo : ContentPage
    {
        public Posteo()
        {
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            var conexion = new MySqlConnection(Properties.Resources.Conexion);
            conexion.Open();

            var cmd = new MySqlCommand("Insert into post (calificacion, comentario, fecha, Usuario_idUsuario) values('" + txtCalificacion.Text + "','" + txtcomentario.Text + "','" + txtfecha.Text + "','" + txtid.Text + "')", conexion);
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
    }
}