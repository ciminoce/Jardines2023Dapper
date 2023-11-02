using System.Drawing;

namespace Jardines2023.Windows.Classes
{
    public class ItemCarrito
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Cantidad * Precio;

        public override bool Equals(object obj)
        {
            if(obj is ItemCarrito item)
            {
                return this.ProductoId == item.ProductoId;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ProductoId.GetHashCode();
        }
    }
}
