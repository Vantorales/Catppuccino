using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities.Models;

namespace CatppuccinoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : Controller
    {
        [HttpGet(Name = "ObtenerProductoVendidos")]
        public ActionResult<IEnumerable<ProductoVendido>> GetProductoVendidos()
        {
            return Ok(ProductoVendidoBussiness.ObtenerProductosVendidos().ToArray());
        }

        [HttpGet("{id}", Name = "ObtenerProductoVendido")]

        public ActionResult<ProductoVendido> GetProductoVendido(int id)
        {
            var resultado = ProductoVendidoBussiness.ObtenerProductoVendido(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPost(Name = "CrearProductoVendido")]

        public ActionResult Post([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoBussiness.CrearProductoVendido(productoVendido);
            return Ok("Se creó correctamente el ProductoVendido");
        }

        [HttpPut(Name = "ModificarProductoVendido")]

        public ActionResult Put([FromBody] ProductoVendido productoVendido)
        {
            var resultado = ProductoVendidoBussiness.ObtenerProductoVendido(productoVendido.Id);
            if (resultado != null)
            {
                ProductoVendidoBussiness.ModificarProductoVendido(productoVendido);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete(Name = "EliminarProductoVendido")]

        public ActionResult Delete([FromBody] int id)
        {
            var resultado = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (resultado != null)
            {
                ProductoVendidoBussiness.EliminarProductoVendido(id);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
