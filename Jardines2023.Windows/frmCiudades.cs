using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jardines2023.Windows
{
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _servicio;
        private readonly IServiciosPaises _serviciosPaises;
        private List<CiudadDto> lista;

        //Para paginación
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        int? paisFiltro = null;
        bool filtroOn=false;
        public frmCiudades()
        {
            InitializeComponent();
            _servicio = new ServiciosCiudades();
            _serviciosPaises = new ServiciosPaises();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var ciudad in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ciudad);
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCiudadAE frm = new frmCiudadAE(_servicio) { Text = "Agregar Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            CiudadDto ciudadDto = (CiudadDto)r.Tag;
            CiudadDto ciudadCopia = (CiudadDto)ciudadDto.Clone();
            //Traer el objeto Ciudad
            Ciudad ciudad = _servicio.GetCiudadPorId(ciudadDto.CiudadId);
            try
            {
                frmCiudadAE frm = new frmCiudadAE(_servicio) { Text = "Editar Ciudad" };
                frm.SetCiudad(ciudad);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, ciudadCopia);

                    return;
                }
                ciudad = frm.GetCiudad();
                if (ciudad != null)
                {
                    //Crear el dto
                    ciudadDto.CiudadId = ciudad.CiudadId;
                    ciudadDto.NombreCiudad = ciudad.NombreCiudad;
                    ciudadDto.NombrePais =
                        (_serviciosPaises
                        .GetPaisPorId(ciudad.PaisId)).NombrePais;
                    GridHelper.SetearFila(r, ciudadDto);

                }
                else
                {
                    //Recupero la copia del dto
                    GridHelper.SetearFila(r, ciudadCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, ciudadCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            CiudadDto ciudadDto = (CiudadDto)r.Tag;


            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                Ciudad ciudad = _servicio.GetCiudadPorId(ciudadDto.CiudadId);
                if (!_servicio.EstaRelacionada(ciudad))
                {
                    _servicio.Borrar(ciudad.CiudadId);
                    GridHelper.QuitarFila(dgvDatos, r);
                    registros = _servicio.GetCantidad(null);
                    paginas = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                    lblRegistros.Text = registros.ToString();
                    lblPaginas.Text = paginas.ToString();
                    //lblCantidad.Text = _servicio.GetCantidad().ToString();
                    MessageBox.Show("Registro borrado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Ciudad Relacionada!!!", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            if (!filtroOn)
            {
                frmSeleccionarPais frm = new frmSeleccionarPais() { Text = "Seleccionar País" };
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                try
                {
                    filtroOn = true;
                    var pais = frm.GetPais();
                    paisFiltro = pais.PaisId;
                    tsbBuscar.BackColor = Color.Orange;
                    registros = _servicio.GetCantidad(pais.PaisId);
                    paginas = FormHelper.CalcularPaginas(registros, registrosPorPagina);

                    MostrarPaginado();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Quite el filtro activo!!!", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroOn=false;
            paisFiltro = null;
            RecargarGrilla();
            tsbBuscar.BackColor = SystemColors.Control;
        }

        private void RecargarGrilla()
        {
            try
            {
                registros = _servicio.GetCantidad(null);
                paginas = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            catch (Exception)
            {

                throw;
            }

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
            lista = _servicio.GetCiudadesPorPagina(registrosPorPagina, paginaActual, paisFiltro);
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
    }
}
