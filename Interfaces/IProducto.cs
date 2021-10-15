using APIProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductos.Interfaces
{
    public interface IProducto
    {
        public Task<List<Producto>> GetAll();
        public Task<Producto> GetById(int productoId);
        public Task<int> Add(Producto productos);
        public Task<bool> Delete(int productoId);
        public Task<Producto> Update(Producto producto);      

    }
}
