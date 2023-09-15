using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Wpf_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string connectionString = "Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=Neptuno2;User ID=usrNeptuno;Password=123456";
        public MainWindow()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = LoadCollectionData();

        }
        /// List of Authors
        /// </summary>
        /// <returns></returns>
        private List<Producto> LoadCollectionData()
        {
            List<Producto> productos = new List<Producto>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para seleccionar datos
                string query = "SELECT IdProducto,Nombre,Categoria,FechaVencimiento FROM Product";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila

                                productos.Add(new Producto
                                {
                                    IdProducto = (int)reader["IdEmpleado"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Categoria = reader["Categoria"].ToString(),
                                    Precio = (decimal)reader["Precio"],
                                    FechaVencimiento = (DateTime)reader["FechaVencimiento"]

                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();


            }
            return empleados;














        }

        private void RowColorButton_Click(object sender, RoutedEventArgs e)
        {
            Producto productos = (Producto)McDataGrid.SelectedItem;
            //  MessageBox.Show("Selected author: " + author.Name);
        }
    }
}
