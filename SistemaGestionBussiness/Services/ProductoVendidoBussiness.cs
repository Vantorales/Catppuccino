using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Data;
using SistemaGestionEntities.Models;

namespace SistemaGestionBussiness.Services
{
    public static class ProductoVendidoBussiness
    {
        public static List<ProductoVendido> ObtenerProductosVendidos()
        {
            return ProductoVendidoData.ListarProductoVendidos();
        }
        public static ProductoVendido ObtenerProductoVendido(int id) => ProductoVendidoData.ObtenerProductoVendido(id);

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.CrearProductoVendido(productoVendido);
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        public static void EliminarProductoVendido(int id)
        {
            ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}
