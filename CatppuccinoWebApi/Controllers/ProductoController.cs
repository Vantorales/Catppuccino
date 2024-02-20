using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness.Services;
using SistemaGestionEntities.Models;

namespace CatppuccinoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        [HttpGet(Name = "ObtenerProductos")]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            return Ok(ProductoBussiness.ObtenerProductos().ToArray());
        }

        [HttpGet("{id}", Name = "ObtenerProducto")]

        public ActionResult<Producto> GetProducto(int id)
        {
            var resultado = ProductoBussiness.ObtenerProducto(id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPost(Name = "CrearProducto")]

        public ActionResult Post([FromBody] Producto producto)
        {
            ProductoBussiness.CrearProducto(producto);
            return Ok("Se creó correctamente el Producto");
        }

        [HttpPut(Name = "ModificarProducto")]

        public ActionResult Put([FromBody] Producto producto)
        {
            var resultado = ProductoBussiness.ObtenerProducto(producto.Id);
            if (resultado != null)
            {
                ProductoBussiness.ModificarProducto(producto);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete(Name = "EliminarProducto")]

        public ActionResult Delete([FromBody] int id)
        {
            var resultado = ProductoBussiness.ObtenerProducto(id);
            if (resultado != null)
            {
                ProductoBussiness.EliminarProducto(id);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
