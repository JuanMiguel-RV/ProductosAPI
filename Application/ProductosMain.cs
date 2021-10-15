using APIProductos.Interfaces;
using APIProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductos.Application
{
    public class ProductosMain : IProducto
    {
        private IProductos _productos;
        public ProductosMain(IProductos productos)
        {
            _productos = productos;
        }
        public async Task<List<Producto>> GetAll()
        {
            try
            {
                return Task.Run(() => _productos.lstProductos).Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener productos, {ex.Message}");
            }
        }
        public async Task<Producto> GetById(int idProducto)
        {
            try
            {
                var response = Task.Run(() => _productos.lstProductos.FirstOrDefault(p =>
                                                                        p.idProducto == idProducto)).Result;

                return response != null ? response :
                    throw new ApplicationException($"No se encontró el producto con el Id: {idProducto}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el producto {ex.Message}");
            }
        }
        public async Task<int> Add(Producto producto)
        {
            try
            {
                var ultimoId = _productos.lstProductos.Count() > 0 ? _productos.lstProductos.Max(p => p.idProducto) : 0;

                _productos.lstProductos.Add(new Producto
                {
                    idProducto = ultimoId + 1,
                    cantidad = producto.cantidad,
                    categoria = producto.categoria,
                    descripcion = producto.descripcion,
                    nombre = producto.nombre,
                    precio = producto.precio
                });

                return (int)_productos.lstProductos.LastOrDefault(p => p != null).idProducto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el producto {ex.Message}");
            }
        }
        public async Task<bool> Delete(int productoId)
        {
            try
            {
                var nuevaLista = Task.Run(() => _productos.lstProductos.Where(p => p.idProducto != productoId));
                _productos.lstProductos = nuevaLista.Result.ToList();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al eliminar el producto {ex.Message}");
            }
        }        
        public async Task<Producto> Update(Producto producto)
        {
            try
            {
                var nuevaLista = Task.Run(() => _productos.lstProductos.Where(p => p.idProducto != producto.idProducto));
                _productos.lstProductos = nuevaLista.Result.ToList();
                _productos.lstProductos.Add(producto);
                return _productos.lstProductos.FirstOrDefault(p => p.idProducto == producto.idProducto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el producto{ex.Message}");
            }
        }

        
    }
}
