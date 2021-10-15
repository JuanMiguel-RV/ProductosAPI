using System;
using System.Collections.Generic;
using System.Linq;

namespace APIProductos.Models
{
    public class Producto
    {
        public int? idProducto { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public float precio { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
    }
}
