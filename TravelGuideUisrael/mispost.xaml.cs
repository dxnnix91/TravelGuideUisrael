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
    public partial class mispost : ContentPage
    {
        private ListView listView;
        private List<string> items;
        public mispost()
        {
            InitializeComponent();
            items = new List<string>();

            // Crear una instancia del ListView
            listView = new ListView();

            // Obtener los datos de la base de datos y cargarlos en la lista de elementos
            LoadData();

            // Asignar la lista de elementos como origen de datos del ListView
            listView.ItemsSource = items;

            // Agregar el ListView al contenido de la página
            Content = new StackLayout
            {
                Children = { listView }
            };
        }

        private void LoadData()
        {
            // Configurar la conexión a la base de datos MySQL
            string connectionString = "Server=sql10.freemysqlhosting.net;Database=sql10632630;Uid=sql10632630;Pwd=cTAlAsDSWx;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();

                    // Consulta SQL para obtener los datos
                    string query = "SELECT * FROM post";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Obtener el valor de la columna deseada (por ejemplo, "nombre")
                                string calificacion = reader.GetString("calificacion");
                                string comentario = reader.GetString("comentario");
                                

                                // Agregar el valor a la lista de elementos
                                items.Add(calificacion+"       "+comentario);
                            }
                        }
                    }

                    // Cerrar la conexión a la base de datos
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejar el caso de error según sea necesario
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
    
