using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Producto
    {
        public int Id { get; set; }
        public string TipoInfusion { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto() { }
        public Producto(int id, string tipoInfusion, string descripcion, int precio, int stock, int idUsuario)
        {
            Id = id;
            TipoInfusion = tipoInfusion;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            IdUsuario = idUsuario;
        }

        public void mostrarInfo()
        {
            Console.WriteLine($"ID:  {Id}");
            Console.WriteLine($"Tipo de Infusion:  {TipoInfusion}");
            Console.WriteLine($"Descripcion:  {Descripcion}");
            Console.WriteLine($"Precio:  {Precio}");
            Console.WriteLine($"Stock:  {Stock}");
            Console.WriteLine($"ID Usuario:  {IdUsuario}");
        }
    }
}
