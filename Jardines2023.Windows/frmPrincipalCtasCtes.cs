using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
	public partial class frmPrincipalCtasCtes : Form
	{
		public frmPrincipalCtasCtes()
		{
			InitializeComponent();
		}

		private void btnCtasPorCliente_Click(object sender, EventArgs e)
		{
			frmDetalleCtaCte frm = new frmDetalleCtaCte();
			frm.ShowDialog(this);
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
