﻿using SistemaGestionEntities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Data
{
    public static class VentaData
    {
        private static string connectionstring = @"Server=localhost\SQLEXPRESS;Database=CatpuccinoDB;Trusted_Connection=true;";
        public static List<Venta> ListarVentas()
        {
            List<Venta> ListaVentas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string getallquery = "select * from Venta";
                using (SqlCommand command = new SqlCommand(getallquery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(reader["Id"]);
                                venta.Descripcion = reader["Descripcion"].ToString();
                                venta.Precio = Convert.ToInt32(reader["Precio"]);
                                venta.Descuento = Convert.ToInt32(reader["Descuento"]);
                                venta.IdUsuario = Convert.ToInt32(reader["idUsuario"]);

                                ListaVentas.Add(venta);

                            }
                        }

                    }
                }

                connection.Close();
                return ListaVentas;
            }
        }

        public static Venta ObtenerVenta(int id)
        {
            Venta venta = null;


            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string getIdQuery = "select * from Venta where id = @IdVenta";
                using (SqlCommand command = new SqlCommand(getIdQuery, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdVenta";
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
                                venta = new Venta
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Descripcion = reader["Comentarios"].ToString(),
                                    Precio = Convert.ToInt32(reader["Total"]),
                                    Descuento = Convert.ToInt32(reader["Descuento"]),
                                    TipoInfusion = reader["TipoInfusion"].ToString(),
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                                };
                            }
                        }
                    }
                }
                connection.Close();
                return venta;
            }
        }

        public static void CrearVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string insertquery = "insert into Venta (Descripcion, Precio, Descuento, TipoInfusion, IdUsuario) " +
                                     "values (@Descripcion, @Precio, @Descuento, @TipoInfusion, @idUsuario)";
                using SqlCommand command = new SqlCommand(insertquery, connection);

                command.Parameters.AddWithValue("@Descripcion", venta.Descripcion);
                command.Parameters.AddWithValue("@Precio", venta.Precio);
                command.Parameters.AddWithValue("@Descuento", venta.Descuento);
                command.Parameters.AddWithValue("@TipoInfusion", venta.TipoInfusion);
                command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);

                try
                {
                    connection.Open();
                    int rowsaffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente la venta. filas afectadas: {rowsaffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar la venta: {ex.Message}");
                }
                connection.Close();
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                if (ObtenerVenta(venta.Id) != null)
                {
                    string updateQuery = "update Venta set Descripcion = @NuevaDescripcion, Precio = @NuevoPrecio, " +
                              "Descuento = @NuevoDescuento, TipoInfusion = @NuevoTipoInfusion " +
                              "where Id = @IdVenta";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@IdVenta", venta.Id);
                    command.Parameters.AddWithValue("@NuevaDescripcion", venta.Descripcion);
                    command.Parameters.AddWithValue("@NuevoPrecio", venta.Precio);
                    command.Parameters.AddWithValue("@NuevoDescuento", venta.Descuento);
                    command.Parameters.AddWithValue("@NuevoTipoInfusion", venta.TipoInfusion);
                    //command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el venta. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el venta: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }

        public static void EliminarVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                if (ObtenerVenta(id) != null)
                {
                    string deleteQuery = "delete from Venta where Id = @IdVenta";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@IdVenta", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente el venta. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar el venta: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}
