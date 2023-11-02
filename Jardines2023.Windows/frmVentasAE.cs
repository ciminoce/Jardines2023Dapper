using Jardines2023.Entidades.Dtos.Categoria;
using Jardines2023.Entidades.Dtos.Producto;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Entidades.Enum;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Classes;
using Jardines2023.Windows.Helpers;
using Jardines2023.Windows.UsersControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmVentasAE : Form
    {
        private IServiciosProductos _serviciosProductos;
        private List<ProductoListDto> _productosLista;
        private int? categoriaSeleccionadaId = null;
        private string categoriaSeleccionada = null;
        public frmVentasAE()
        {
            InitializeComponent();
            _serviciosProductos = new ServiciosProductos();
        }
        private Venta venta;
        public Venta GetVenta()
        {
            return venta;
        }

        private void frmVentasAE_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboCategorias(ref cboCategorias);
            _productosLista = _serviciosProductos.GetProductos(categoriaSeleccionadaId);
            MostrarProductosEnLayout(categoriaSeleccionada);
        }

        private void MostrarProductosEnLayout(string categoria)
        {
            ProductoFlowLayoutPanel.Controls.Clear();

            foreach (var productoEnLista in _productosLista)
            {
                var ucProducto = SetearUserControl(productoEnLista);
                AgregarUserControl(ucProducto, categoriaSeleccionada);

            }
        }

        private void AgregarUserControl(ucProducto ucProducto, string categoria)
        {
            if (ucProducto.Categoria == categoria || categoria == null)
            {
                ucProducto.Visible = true;
            }
            else
            {
                ucProducto.Visible = false;

            }
            ProductoFlowLayoutPanel.Controls.Add(ucProducto);
        }

        private ucProducto SetearUserControl(ProductoListDto productoEnLista)
        {
            var ucProducto = new ucProducto
            {
                ProductoId = productoEnLista.ProductoId,
                NombreProducto = productoEnLista.NombreProducto,
                Precio = productoEnLista.PrecioUnitario.ToString("C"),
                Stock = productoEnLista.UnidadesEnStock.ToString(),
                Categoria = productoEnLista.NombreCategoria


            };
            if (productoEnLista.UnidadesEnStock == 0)
            {
                ucProducto.Enabled = false;
                ucProducto.BackColor = Color.Yellow;
            }

            ucProducto.Name = productoEnLista.ProductoId.ToString();
            ucProducto.btnAgregar.Tag = ucProducto;
            ucProducto.btnAgregar.Click += BtnAgregar_Click;

            return ucProducto;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var ucSeleccionado = (ucProducto)((Button)sender).Tag;
            var productoId = ucSeleccionado.ProductoId;

            var producto = _serviciosProductos.GetProductoPorId(productoId);

            ItemCarrito ic = new ItemCarrito
            {
                ProductoId = producto.ProductoId,
                NombreProducto = producto.NombreProducto,
                Cantidad = 1,
                Precio = producto.PrecioUnitario

            };
            Carrito.GetInstancia().AgregarAlCarrito(ic);
            MostrarCarrito();
            ActualizarStock(ic.ProductoId, ic.Cantidad);
        }

        private void ActualizarStock(int productoId, int cantidad)
        {
            var uc = (ucProducto)ProductoFlowLayoutPanel.Controls.Find(productoId.ToString(), true)[0];
            int nuevaCantidad = int.Parse(uc.Stock) - cantidad;
            ((ucProducto)ProductoFlowLayoutPanel
                .Controls.Find(productoId.ToString(), true)[0])
                .Stock = nuevaCantidad.ToString();
            if (nuevaCantidad == 0)
            {
                uc.Enabled = false;
                uc.BackColor = Color.Yellow;
            }
            else
            {
                uc.Enabled = true;
                uc.BackColor = SystemColors.ControlLight;

            }

        }

        private void MostrarCarrito()
        {
            GridHelper.LimpiarGrilla(dgvCarrito);
            foreach (var itemEnCarrito in Carrito.GetInstancia().GetItems())
            {
                var r = GridHelper.ConstruirFila(dgvCarrito);
                GridHelper.SetearFila(r, itemEnCarrito);
                GridHelper.AgregarFila(dgvCarrito, r);
            }
            lblCantidad.Text = Carrito.GetInstancia().GetCantidadProductos().ToString();
            lblTotal.Text = Carrito.GetInstancia().GetTotal().ToString("C");
        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedIndex > 0)
            {
                //categoriaSeleccionadaId = ((CategoriaComboDto)cboCategorias
                //    .SelectedItem).CategoriaId;
                categoriaSeleccionada = ((CategoriaComboDto)cboCategorias
                    .SelectedItem).NombreCategoria;

            }
            else
            {
                categoriaSeleccionada = null;
            }
            _productosLista = _serviciosProductos.GetProductos(categoriaSeleccionadaId);
            MostrarProductosEnLayout(categoriaSeleccionada);
        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //_productosLista = _serviciosProductos.GetProductos(null);
                //MostrarProductosEnLayout();
                var r = dgvCarrito.SelectedRows[0];
                var itemQuitar = (ItemCarrito)r.Tag;
                Carrito.GetInstancia().QuitarAlCarrito(itemQuitar);
                MostrarCarrito();
                ActualizarStock(itemQuitar.ProductoId, -itemQuitar.Cantidad);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Ver si tengo algo en el carrito
            if (Carrito.GetInstancia().GetCantidad() == 0)
            {
                return;
            }
            frmSeleccionarCliente frm = new frmSeleccionarCliente() { Text = "Seleccionar Cliente" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                MessageBox.Show("Debe seleccionar un cliente" + Environment.NewLine +
                    "o CANCELAR la operación",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var cliente = frm.GetCliente();
                //Crear la venta
                var detalles = new List<DetalleVenta>();
                foreach (var item in Carrito.GetInstancia().GetItems())
                {
                    var detalle = new DetalleVenta()
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.Precio
                    };
                    detalles.Add(detalle);
                }
                venta = new Venta()
                {
                    FechaVenta = DateTime.Now,
                    ClienteId = cliente.ClienteId,
                    EstadoOrden = EstadoOrden.Aceptada,
                    Total = Carrito.GetInstancia().GetTotal(),
                    Detalles = detalles,

                };
                Carrito.GetInstancia().VaciarCarrito();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
