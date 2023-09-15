using System;

namespace Wpf_Lab3
{
    internal class Producto
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public decimal? Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}