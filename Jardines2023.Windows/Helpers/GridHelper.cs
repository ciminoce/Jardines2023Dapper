using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Dtos.DetalleVenta;
using Jardines2023.Entidades.Dtos.Producto;
using Jardines2023.Entidades.Dtos.Proveedor;
using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Windows.Classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jardines2023.Windows.Helpers
{
    public static class GridHelper
    {

        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;

        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Pais pais:
                    r.Cells[0].Value = pais.NombrePais;
                    break;
                case CiudadDto ciudad:
                    r.Cells[0].Value = ciudad.NombrePais;
                    r.Cells[1].Value = ciudad.NombreCiudad;
                    break;
                case Categoria categoria:
                    r.Cells[0].Value = categoria.NombreCategoria;
                    r.Cells[1].Value = categoria.Descripcion;
                    break;
                case ClienteListDto cliente:
                    r.Cells[0].Value = $"{cliente.Apellido}, {cliente.Nombres}";
                    r.Cells[1].Value = cliente.Direccion;
                    r.Cells[2].Value = cliente.NombrePais;
                    r.Cells[3].Value = cliente.NombreCiudad;
                    break;
                case ProveedorListDto proveedor:
                    r.Cells[0].Value = proveedor.NombreProveedor;
                    r.Cells[1].Value = proveedor.NombrePais;
                    r.Cells[2].Value = proveedor.NombreCiudad;
                    break;
                case ProductoListDto producto:
                    r.Cells[0].Value = producto.NombreProducto;
                    r.Cells[1].Value = producto.NombreCategoria;
                    r.Cells[2].Value = producto.PrecioUnitario;
                    r.Cells[3].Value = producto.UnidadesEnStock;
                    r.Cells[4].Value = producto.Suspendido;
                    break;
                case VentaListDto venta:
                    r.Cells[0].Value = venta.VentaId;
                    r.Cells[1].Value = venta.FechaVenta.ToShortDateString();
                    r.Cells[2].Value = venta.Cliente;
                    r.Cells[3].Value = venta.Total;
                    r.Cells[4].Value = venta.TransaccionId;
                    r.Cells[5].Value = venta.EstadoOrden.ToString();
                    break;
                case ItemCarrito item:
                    r.Cells[0].Value = item.NombreProducto;
                    r.Cells[1].Value = item.Precio;
                    r.Cells[2].Value = item.Cantidad;
                    r.Cells[3].Value = item.Total;
                    break;
                case MovimientoCtaCte ctaCte:
                    r.Cells[0].Value = ctaCte.FechaMovimiento;
                    r.Cells[1].Value = ctaCte.Movimiento;
                    r.Cells[2].Value = ctaCte.Debe;
                    r.Cells[3].Value = ctaCte.Haber;
                    r.Cells[4].Value = ctaCte.Saldo;
                    break;
                case DetalleVentaDto item:
                    r.Cells[0].Value = item.NombreProducto;
                    r.Cells[1].Value = item.PrecioUnitario;
                    r.Cells[2].Value = item.Cantidad;
                    r.Cells[3].Value = item.Total;
                    break;
            }
            r.Tag = obj;

        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }

        public static void MostrarDatosEnGrilla<T>(DataGridView dgv, List<T> lista) where T : class
        {
            GridHelper.LimpiarGrilla(dgv);
            foreach (var obj in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgv);
                GridHelper.SetearFila(r, obj);
                GridHelper.AgregarFila(dgv, r);
            }

        }

    }
}
