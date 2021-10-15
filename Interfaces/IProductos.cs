using APIProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductos.Interfaces
{
    public interface IProductos
    {
        public List<Producto> lstProductos { get; set; }
    }
}
