namespace Jardines2023.Entidades.Dtos.DetalleVenta
{
    public class DetalleVentaDto
    {
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public decimal Total => PrecioUnitario * Cantidad;

    }
}
