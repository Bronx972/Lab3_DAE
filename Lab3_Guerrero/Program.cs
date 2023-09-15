// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Data;
using Lab3_Guerrero;

class Program
{
    // Cadena de conexión a la base de datos
    public static string connectionString = "Data Source=LAB1504-09\\SQLEXPRESS;Initial Catalog=TecsupDB2023_G;User ID=userTecsup;Password=123456";


    static void Main()
    {

        DataTable productos_dt = ListarProductosDataTable();


        Console.WriteLine("POR DATA TABLE");

        foreach (DataRow row in productos_dt.Rows)
        {
            Console.WriteLine($"ID: {row["IdProducto"]}");
            Console.WriteLine($"Nombre: {row["Nombre"]}");
            Console.WriteLine($"Categoria: {row["Categoria"]}");
            Console.WriteLine($"Precio: {row["Precio"]}");
            Console.WriteLine($"Fecha de Vencimiento: {row["FechaVencimiento"]}");
            Console.WriteLine();
        }
        

        List<Product> productos = ListarProductosListaObjetos();

        Console.WriteLine("POR lISTA DE OBJETOS");

        foreach (Product producto in productos)
        {
            Console.WriteLine($"ID: {producto.IdProducto}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Categoría: {producto.Categoria}");
            Console.WriteLine($"Precio: {producto.Precio}");
            Console.WriteLine($"Fecha de Vencimiento: {producto.FechaVencimiento}");
            Console.WriteLine();
        }

        
    }

    //De forma desconectada
    private static DataTable ListarProductosDataTable()
    {
        // Crear un DataTable para almacenar los resultados
        DataTable dataTable = new DataTable();
        // Crear una conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT * FROM Product";

            // Crear un adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            // Llenar el DataTable con los datos de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            connection.Close();

        }
        return dataTable;
    }

    //De forma conectada
    private static List<Product> ListarProductosListaObjetos()
    {
        List<Product> productos = new List<Product>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT IdProducto,Nombre,Categoria,Precio,FechaVencimiento FROM Product";

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

                            productos.Add(new Product
                            {
                                IdProducto = (int)reader["IdProducto"],
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
        return productos;

    }


}