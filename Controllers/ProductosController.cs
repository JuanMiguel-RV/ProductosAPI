using APIProductos.Interfaces;
using APIProductos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private IProducto _producto;
        public ProductosController(IProducto producto) {
            _producto = producto;
        }

        [HttpGet,Route("")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> ObtenerProductos()
        {
            try
            {
                var resp = await _producto.GetAll();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet, Route("id")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> ObtenerProductoId(int id)
        {
            try
            {
                var resp = await _producto.GetById(id);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet, Route("id")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> EliminarProducto(int id)
        {
            try
            {
                var resp = await _producto.Delete(id);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet, Route("")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> InsertarProducto(Producto producto)
        {
            try
            {
                var resp = await _producto.Add(producto);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet, Route("")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> ActualizarProducto(Producto producto)
        {
            try
            {
                var resp = await _producto.Update(producto);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
