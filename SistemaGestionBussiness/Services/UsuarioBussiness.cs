using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Data;
using SistemaGestionEntities.Models;

namespace SistemaGestionBussiness.Services
{
    public static class UsuarioBussiness
    {
        public static List<Usuario> ObtenerUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }
        public static Usuario ObtenerUsuario(int id) => UsuarioData.ObtenerUsuario(id);

        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioData.CrearUsuario(usuario);
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioData.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(int id)
        {
            UsuarioData.EliminarUsuario(id);
        }
    }
}
