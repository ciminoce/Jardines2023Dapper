using Jardines2023.Entidades.Dtos.DetalleVenta;
using Jardines2023.Entidades.Dtos.Venta;
using Jardines2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmDetalleVenta : Form
    {
        private VentaDetalleDto ventaDto;
        public frmDetalleVenta()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MostrarDatosCliente(ventaDto.ventaListDto);
            GridHelper.MostrarDatosEnGrilla<DetalleVentaDto>(dgvDatos, ventaDto.DetallesDto);

        }

        private void MostrarDatosCliente(VentaListDto ventaListDto)
        {
            ClienteTextBox.Text = ventaListDto.Cliente;
            VentaNroTextBox.Text = ventaListDto.VentaId.ToString();
            TotalVtaTextBox.Text = ventaListDto.Total.ToString("C2");
            FechaVtaTextBox.Text=ventaListDto.FechaVenta.ToShortDateString();
        }

        public void SetVentaDetalle(VentaDetalleDto ventaDto)
        {
            this.ventaDto= ventaDto;
        }

		private void btnImprimir_Click(object sender, EventArgs e)
		{
            ImprimirHelper.ImprimirFactura(ventaDto);
		}
	}
}
