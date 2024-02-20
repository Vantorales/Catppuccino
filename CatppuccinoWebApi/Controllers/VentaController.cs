using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities.Models;

namespace CatppuccinoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        [HttpGet(Name = "ObtenerVentas")]
        public ActionResult<IEnumerable<Venta>> GetVentas()
        {
            return Ok(VentaBussiness.ObtenerVentas().ToArray());
        }

        [HttpGet("{id}", Name = "ObtenerVenta")]

        public ActionResult<Venta> GetVenta(int id)
        {
            var resultado = VentaBussiness.ObtenerVenta(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPost(Name = "CrearVenta")]

        public ActionResult Post([FromBody] Venta venta)
        {
            VentaBussiness.CrearVenta(venta);
            return Ok("Se creó correctamente la Venta");
        }

        [HttpPut(Name = "ModificarVenta")]

        public ActionResult Put([FromBody] Venta venta)
        {
            var resultado = VentaBussiness.ObtenerVenta(venta.Id);
            if (resultado != null)
            {
                VentaBussiness.ModificarVenta(venta);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete(Name = "EliminarVenta")]

        public ActionResult Delete([FromBody] int id)
        {
            var resultado = VentaBussiness.ObtenerVenta(id);
            if (resultado != null)
            {
                VentaBussiness.EliminarVenta(id);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
