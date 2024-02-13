using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido() { }
        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;
        }

        public void mostrarInfo()
        {
            Console.WriteLine($"ID:  {Id}");
            Console.WriteLine($"ID Producto:  {IdProducto}");
            Console.WriteLine($"Stock:  {Stock}");
            Console.WriteLine($"ID Venta:  {IdVenta}");
        }
    }
}
