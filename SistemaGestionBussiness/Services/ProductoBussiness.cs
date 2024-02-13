using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Data;
using SistemaGestionEntities.Models;

namespace SistemaGestionBussiness.Services
{
    public static class ProductoBussiness
    {
        public static List<Producto> ObtenerProductos()
        {
            return ProductoData.ListarProductos();
        }
        public static Producto ObtenerProducto(int id) => ProductoData.ObtenerProducto(id);

        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        public static void ModificarProducto(Producto producto)
        {
            ProductoData.ModificarProducto(producto);
        }

        public static void EliminarProducto(int id)
        {
            ProductoData.EliminarProducto(id);
        }
    }
}
