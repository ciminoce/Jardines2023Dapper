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
	public partial class frmFecha : Form
	{
		public frmFecha()
		{
			InitializeComponent();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (ValidarDatos())
			{
				DialogResult = DialogResult.OK;
			}
		}
		public DateTime GetFecha()
		{
			return dtpFechaFiltro.Value.Date;
		}
		private bool ValidarDatos()
		{
			bool valido = true;
			errorProvider1.Clear();
			if (dtpFechaFiltro.Value.Date>DateTime.Now.Date) {
				valido = false;
				errorProvider1.SetError(dtpFechaFiltro, "Fecha mayor a la fecha actual!!!");
			}
			return valido;
		}
	}
}
