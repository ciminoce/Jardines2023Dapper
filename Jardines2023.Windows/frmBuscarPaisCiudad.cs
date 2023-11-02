using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmBuscarPaisCiudad : Form
    {
        private Pais paisSeleccionado;
        private CiudadComboDto ciudadSeleccionada;

        public frmBuscarPaisCiudad()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscarPaisCiudad_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }
        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex > 0)
            {
                paisSeleccionado = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarComboCiudades(ref cboCiudades, paisSeleccionado.PaisId);
            }
            else
            {
                paisSeleccionado = null;
                ciudadSeleccionada = null;
                cboCiudades.DataSource = null;
            }

        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiudades.SelectedIndex > 0)
            {
                ciudadSeleccionada = (CiudadComboDto)cboCiudades.SelectedItem;
            }
            else
            {
                ciudadSeleccionada = null;
            }
        }

        public Pais GetPais()
        {
            return paisSeleccionado;
        }
        public CiudadComboDto GetCiudad()
        {
            return ciudadSeleccionada;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar una ciudad");
            }
            return valido;
        }
    }
}
