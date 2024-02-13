using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Data;
using SistemaGestionEntities.Models;

namespace SistemaGestionBussiness.Services
{
    public static class VentaBussiness
    {
        public static List<Venta> ObtenerVentas()
        {
            return VentaData.ListarVentas();
        }
        public static Venta ObtenerVenta(int id) => VentaData.ObtenerVenta(id);

        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }

        public static void ModificarVenta(Venta venta)
        {
            VentaData.ModificarVenta(venta);
        }

        public static void EliminarVenta(int id)
        {
            VentaData.EliminarVenta(id);
        }
    }
}
