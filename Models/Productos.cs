using APIProductos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductos.Models
{   
    public class Productos : IProductos
    {
        private List<Producto> _productos;
        public List<Producto> lstProductos
        {
            get
            {
                if (_productos == null)
                    _productos = new List<Producto>();
                return _productos;
            }

            set { _productos = value; }
        }
    }
}
