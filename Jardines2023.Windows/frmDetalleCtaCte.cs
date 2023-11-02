using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
	public partial class frmDetalleCtaCte : Form
	{
		private readonly IServiciosCtasCtes _serviciosCtasCtes;
		private List<MovimientoCtaCte> lista;
		private ClienteListDto cliente;
		public frmDetalleCtaCte()
		{
			InitializeComponent();
			_serviciosCtasCtes = new ServiciosCtasCtes();
		}

		private void btnBuscarCliente_Click(object sender, EventArgs e)
		{
			frmSeleccionarCliente frm = new frmSeleccionarCliente() { Text = "Seleccionar Cliente" };
			DialogResult dr = frm.ShowDialog(this);
			if (dr == DialogResult.OK)
			{
				cliente = frm.GetCliente();
				MostrarDatosCliente(cliente);
				ActualizarCtaCte();
				//Crear la venta
			}

		}

		private void ActualizarCtaCte()
		{
			try
			{
				lista = _serviciosCtasCtes.GetMovimientos(cliente.ClienteId);
				GridHelper.MostrarDatosEnGrilla<MovimientoCtaCte>(dgvDatos, lista);
				txtSaldo.Text = _serviciosCtasCtes.GetSaldo(cliente.ClienteId).ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void MostrarDatosCliente(ClienteListDto cliente)
		{
			txtCliente.Text = $"{cliente.Nombres} {cliente.Apellido}";
			txtDireccion.Text = cliente.Direccion;
			txtLocalidad.Text = cliente.NombreCiudad;
			txtProvincia.Text = cliente.NombrePais;
		}

		private void btnIngresarPago_Click(object sender, EventArgs e)
		{
			frmPagos frm = new frmPagos { Text = "Ingreso del Pago" };
			frm.SetMonto(decimal.Parse(txtSaldo.Text));
			DialogResult dr = frm.ShowDialog(this);
			if (dr == DialogResult.Cancel) { return; }
			try
			{
				var datos=frm.GetDatosDelPago();
				var saldo = _serviciosCtasCtes.GetSaldo(cliente.ClienteId);
				MovimientoCtaCte mov = new MovimientoCtaCte
				{
					FechaMovimiento = DateTime.Now,
					ClienteId = cliente.ClienteId,
					Movimiento = $"Pago {datos.Item1.ToString()}",
					Debe = 0,
					Haber = datos.Item2,
					Saldo = saldo - datos.Item2
				};
				_serviciosCtasCtes.Guardar(mov);
				ActualizarCtaCte();

			}
			catch (Exception)
			{

				throw;
			}
		}

		//private void btnIngresarPago_Click(object sender, EventArgs e)
		//{
		//    // Configurar las credenciales de PayPal
		//    var config = new Dictionary<string, string>
		//    {
		//        {"mode", "sandbox"}, // Puedes cambiar a "live" en producción
		//        {"clientId", "TU_CLIENT_ID"},
		//        {"clientSecret", "TU_CLIENT_SECRET"}
		//    };

		//    var accessToken = new OAuthTokenCredential(config).GetAccessToken();

		//    var apiContext = new APIContext(accessToken);

		//    // Crear un objeto de pago
		//    var payment = new Payment
		//    {
		//        intent = "sale",
		//        payer = new Payer { payment_method = "paypal" },
		//        transactions = new List<Transaction>
		//        {
		//            new Transaction
		//            {
		//                amount = new Amount
		//                {
		//                    currency = "USD",
		//                    total = "100.00"
		//                },
		//                description = "Descripción de la compra"
		//            }
		//        },
		//        redirect_urls = new RedirectUrls
		//        {
		//            return_url = "URL_DE_RETORNO",
		//            cancel_url = "URL_DE_CANCELACIÓN"
		//        }
		//    };

		//    // Crear el pago en PayPal
		//    var createdPayment = payment.Create(apiContext);

		//    // Redirigir al usuario a la página de PayPal para completar el pago
		//    var approvalUrl = createdPayment.links
		//        .FirstOrDefault(link => link.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

		//    if (approvalUrl != null)
		//    {
		//        System.Diagnostics.Process.Start(approvalUrl.href);
		//    }
		//}
	}
}
