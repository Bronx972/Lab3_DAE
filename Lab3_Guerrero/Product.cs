using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Guerrero
{
    public class Product
    {
        
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public decimal? Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
