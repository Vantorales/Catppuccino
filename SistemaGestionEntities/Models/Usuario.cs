using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string InfusionFavorita { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string nickname, string password, string mail, string infusionFavorita)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Nickname = nickname;
            Password = password;
            Mail = mail;
            InfusionFavorita = infusionFavorita;
        }

        public void mostrarInfo()
        {
            Console.WriteLine($"ID:  {Id}");
            Console.WriteLine($"Nombre:  {Nombre}");
            Console.WriteLine($"Apellido:  {Apellido}");
            Console.WriteLine($"Nickname:  {Nickname}");
            Console.WriteLine($"Mail:  {Mail}");
            Console.WriteLine($"Infusion Favorita:  {InfusionFavorita}");
        }

    }
}
