using CreditCardValidator;
using Jardines2023.Windows.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
	public partial class frmPagos : Form
	{
		public frmPagos()
		{
			InitializeComponent();
		}
		private const string MASKED_VISA_MASTER = "0000-0000-0000-0000";
		private const string MASKED_AMEX = "0000-000000-00000";
		private const string MASKED_EMPTY = "";

		private string formaPago;
		private decimal montoAPagar;
		private decimal importe;
		private string codigoAutorizacion;
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			ImporteLabel.Text = montoAPagar.ToString();
			CombosHelper.CargarComboMeses(ref cboMes);
			CombosHelper.CargarComboAnios(ref cboAnio);
			gboxTarjeta.Enabled = false;
			btnOk.Enabled = false;
		}
		public Tuple<string, decimal, string> GetDatosDelPago()
		{
			return new Tuple<string, decimal, string>(formaPago, montoAPagar, codigoAutorizacion);

		}
		private void EfectivoButton_Click(object sender, EventArgs e)
		{
			mtxtTarjeta.Mask = MASKED_EMPTY;
			gboxTarjeta.Enabled = false;
			formaPago = ((Button)sender).Tag.ToString();
			var importeText = Interaction.InputBox("Ingrese el importe", "Pago en Efectivo", "0", 800, 400);
			decimal importeRecibido;
			if (!decimal.TryParse(importeText, out importeRecibido))
			{
				return;
			}
			else if (importeRecibido <= 0)
			{
				MessageBox.Show("Importe inferior a lo que se debe pagar", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			ImporteRecibidoLabel.Text = importeRecibido.ToString("N2");
			if (importeRecibido >= montoAPagar)
			{
				importe = montoAPagar;
				VueltoLabel.Text = (importeRecibido - montoAPagar).ToString("N2");

			}
			else
			{
				importe = importeRecibido;
			}
			btnOk.Enabled = true;
		}

		public void SetMonto(decimal deuda)
		{
			montoAPagar = deuda;
		}

		private void VisaButton_Click(object sender, EventArgs e)
		{
			TransaccionConTarjeta(sender);
		}



		private void VisaDebitoButton_Click(object sender, EventArgs e)
		{
			TransaccionConTarjeta(sender);

		}

		private void MasterDebitoButton_Click(object sender, EventArgs e)
		{
			TransaccionConTarjeta(sender);

		}

		private void MasterButton_Click(object sender, EventArgs e)
		{
			TransaccionConTarjeta(sender);

		}

		private void AmexButton_Click(object sender, EventArgs e)
		{
			TransaccionConTarjeta(sender);

		}
		private void TransaccionConTarjeta(object sender)
		{
			Button button = (Button)sender;
			formaPago = ((Button)sender).Tag.ToString();

			if (button.Text.Contains("Amex"))
			{
				mtxtTarjeta.Mask = MASKED_AMEX;
			}
			else
			{
				mtxtTarjeta.Mask = MASKED_VISA_MASTER;
			}
			gboxTarjeta.Enabled = true;
		}
		private void frmPagos_Load(object sender, EventArgs e)
		{

		}

		private void btnAutorizar_Click(object sender, EventArgs e)
		{
			string creditCard = mtxtTarjeta.Text.Replace("-", "");
			CreditCardDetector cardDetector = new CreditCardDetector(creditCard);
			if (cardDetector.IsValid())
			{
				codigoAutorizacion = ObtenerCodigoAutorizacion();
				if (codigoAutorizacion != null)
				{
					MessageBox.Show($"Pago Aceptado!!!\nCódigo de autorización={codigoAutorizacion}",
						"Transacción Exitosa",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
					btnOk.Enabled = true;
				}
				else
				{
					btnOk.Enabled = false;
					errorProvider1.SetError(mtxtTarjeta, "Pago rechazado!!!");
				}
			}
			else
			{
				errorProvider1.SetError(mtxtTarjeta, "Nro. de Tarjeta no válido");
			}
		}

		private string ObtenerCodigoAutorizacion()
		{
			//Simula autorización 
			Random r = new Random();
			var autorizado = r.Next(1, 3);
			if (autorizado == 1)
			{
				return Guid.NewGuid().ToString();
			}
			return null;
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

		private bool ValidarDatos()
		{
			return true;
		}
	}
}
