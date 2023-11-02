using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            _servicio = new ServiciosVentas();
        }
        private List<VentaListDto> lista;
        private IServiciosVentas _servicio;
        private int registros;
        private int paginas;
        private int registrosPorPagina = 10;
        private int paginaActual = 1;
        private Func<Venta, bool> filtro = null;

		private void frmVentas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(dgvDatos, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();

        }
        private void MostrarPaginado()
        {
            lista = _servicio.GetVentasPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {

            paginaActual = paginas;
            MostrarPaginado();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmVentasAE frm = new frmVentasAE() { Text = "Nueva Venta" };
            DialogResult dr = frm.ShowDialog(this);
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            var venta = frm.GetVenta();
            try
            {
                _servicio.Guardar(venta);
                RecargarGrilla();
                MessageBox.Show("Venta guardada!!!");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void RecargarGrilla()
        {
            try
            {
                registros = _servicio.GetCantidad();
                paginas = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                paginaActual = paginas;
                MostrarPaginado();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var ventaSeleccionada = (VentaListDto)r.Tag;

            VentaDetalleDto ventaDetalleDto = _servicio.GetVentaDetalle(ventaSeleccionada.VentaId);


            frmDetalleVenta frm = new frmDetalleVenta() { Text = "Detalle de Venta" };
            frm.SetVentaDetalle(ventaDetalleDto);
            DialogResult dr = frm.ShowDialog(this);

        }

		private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
		{
            frmSeleccionarCliente frm = new frmSeleccionarCliente() { Text = "Seleccionar Cliente" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var cliente = frm.GetCliente();
            

			
            
		}

		private void fechaToolStripMenuItem_Click(object sender, EventArgs e)
		{
            frmFecha frm = new frmFecha() { Text = "Seleccione Fecha" };
            DialogResult dr = frm.ShowDialog(this);
            if(dr == DialogResult.Cancel)
            {
                return;
            }
            var fecha = frm.GetFecha();
            try
            {
                lista = _servicio.GetVentasPorFecha(fecha);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
		}

		private void tsbFiltrar_Click(object sender, EventArgs e)
		{

		}
	}
}
