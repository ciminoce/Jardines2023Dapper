using Jardines2023.Entidades.Dtos.Cliente;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmSeleccionarCliente : Form
    {
        public frmSeleccionarCliente()
        {
            InitializeComponent();
        }
        private ClienteListDto cliente;
        List<ClienteListDto> clienteList;
        private string texto = "";
        private IServiciosClientes _servicio = new ServiciosClientes();
        private void frmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            clienteList = _servicio.GetClientes(null, null);
            BuscarCliente(clienteList, texto);
            GridHelper.MostrarDatosEnGrilla<ClienteListDto>(dgvDatos, clienteList);
        }

        private void BuscarCliente(List<ClienteListDto> clienteList, string texto)
        {
            var listaFiltrada = clienteList;
            if (texto.Length != 0)
            {
                Func<ClienteListDto, bool> condicion = c => c.Apellido.ToUpper().Contains(texto.ToUpper()) || c.Nombres.ToUpper().Contains(texto.ToUpper());
                listaFiltrada = clienteList.Where(condicion).ToList();

            }
            GridHelper.MostrarDatosEnGrilla<ClienteListDto>(dgvDatos, listaFiltrada);

        }

        public ClienteListDto GetCliente() => cliente;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (cliente is null)
            {
                valido = false;
                errorProvider1.SetError(txtBuscar, "Debe seleccionar un cliente");
            }
            return valido;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }
            var r = dgvDatos.Rows[e.RowIndex];
            cliente = (ClienteListDto)r.Tag;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            texto = txtBuscar.Text;
            BuscarCliente(clienteList, texto);
        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var r = dgvDatos.Rows[e.RowIndex];
            cliente = (ClienteListDto)r.Tag;

        }
    }
}
