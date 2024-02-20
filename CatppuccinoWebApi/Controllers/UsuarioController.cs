using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities.Models;

namespace CatppuccinoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet(Name = "ObtenerUsuarios")]
        public ActionResult <IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(UsuarioBussiness.ObtenerUsuarios().ToArray());
        }

        [HttpGet("{id}", Name = "ObtenerUsuario")]

        public ActionResult <Usuario> GetUsuario(int id)
        {
            var resultado = UsuarioBussiness.ObtenerUsuario(id);

            if (resultado == null)
                return NotFound(); 

            return Ok(resultado);
        }

        [HttpPost(Name = "CrearUsuario")]

        public ActionResult Post([FromBody] Usuario usuario)
        {
            UsuarioBussiness.CrearUsuario(usuario);
            return Ok("Se creó correctamente el Usuario");
        }

        [HttpPut(Name = "ModificarUsuario")]

        public ActionResult Put([FromBody] Usuario usuario)
        {
            var resultado = UsuarioBussiness.ObtenerUsuario(usuario.Id);
            if (resultado != null)
            {
                UsuarioBussiness.ModificarUsuario(usuario);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete(Name = "EliminarUsuario")]

        public ActionResult Delete([FromBody] int id)
        {
            var resultado = UsuarioBussiness.ObtenerUsuario(id);
            if (resultado != null)
            {
                UsuarioBussiness.EliminarUsuario(id);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
