using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        private static string connectionstring = @"Server=localhost\SQLEXPRESS;Database=CatpuccinoDB;Trusted_Connection=true;";
        public static List<Producto> ListarProductos()
        {
            List<Producto> ListaProductos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string getallquery = "select * from Producto";
                using (SqlCommand command = new SqlCommand(getallquery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(reader["Id"]);
                                producto.TipoInfusion = reader["TipoInfusion"].ToString();
                                producto.Descripcion = reader["Descripcion"].ToString();
                                producto.Precio = Convert.ToInt32(reader["Precio"]);
                                producto.Stock = Convert.ToInt32(reader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                                ListaProductos.Add(producto);

                            }
                        }

                    }
                }

                connection.Close();
                return ListaProductos;
            }
        }

        public static Producto ObtenerProducto(int id)
        {
            Producto producto = null;


            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string getidquery = "select * from Producto where id = @idProducto";
                using (SqlCommand command = new SqlCommand(getidquery, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = id;

                    command.Parameters.Add(parametro);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                producto = new Producto
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TipoInfusion = reader["TipoInfusion"].ToString(),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Precio = Convert.ToInt32(reader["Precio"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                                };
                            }
                        }
                    }
                }
                connection.Close();
                return producto;
            }
        }

        public static void CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string insertquery = "insert into Producto (TipoInfusion, Descripcion, Precio, Stock, IdUsuario) " +
                                     "values (@TipoInfusion, @Descripcion, @Precio, @Stock, @idUsuario)";
                using SqlCommand command = new SqlCommand(insertquery, connection);

                command.Parameters.AddWithValue("@TipoInfusion", producto.TipoInfusion);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);

                try
                {
                    connection.Open();
                    int rowsaffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente el producto. filas afectadas: {rowsaffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar el producto: {ex.Message}");
                }
                connection.Close();
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                if (ObtenerProducto(producto.Id) != null)
                {
                    string updateQuery = "update Producto set TipoInfusion = @NuevoTipoInfusion, Descripcion = @NuevoDescripcion, " +
                              "Precio = @NuevoPrecio, Stock = @NuevaPassword, " +
                              "where Id = @IdProducto";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@IdProducto", producto.Id);
                    command.Parameters.AddWithValue("@NuevoTipoInfusion", producto.TipoInfusion);
                    command.Parameters.AddWithValue("@NuevoDescripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@NuevoPrecio", producto.Precio);
                    command.Parameters.AddWithValue("@NuevoStock", producto.Stock);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el producto. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el producto: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }

        public static void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                if (ObtenerProducto(id) != null)
                {
                    string deleteQuery = "delete from Producto where Id = @IdProducto";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@IdProducto", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente el producto. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}
