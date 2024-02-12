using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Venta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Descuento { get; set; }
        public string TipoInfusion { get; set; }
        public int IdUsuario { get; set; }

        public Venta() { }
        public Venta(int id, string descripcion, int precio, int descuento, string tipoInfusion, int idUsuario)
        {
            Id = id;
            Descripcion = descripcion;
            Precio = precio;
            Descuento = descuento;
            TipoInfusion = tipoInfusion;
            IdUsuario = idUsuario;
        }

        public void mostrarInfo()
        {
            Console.WriteLine($"ID:  {Id}");
            Console.WriteLine($"Descripcion:  {Descripcion}");
            Console.WriteLine($"Precio:  {Precio}");
            Console.WriteLine($"Descuento:  {Descuento}");
            Console.WriteLine($"Tipo de Infusion:  {TipoInfusion}");
            Console.WriteLine($"ID Usuario:  {IdUsuario}");
        }
    }
}
