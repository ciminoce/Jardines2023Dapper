using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Jardines2023.Windows.UsersControls
{
    public partial class ucProducto : UserControl
    {
        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imagenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imagenes\ArchivoNoEncontrado.jpg";

        public ucProducto()
        {
            InitializeComponent();
        }
        public int ProductoId { get; set; }
        public string NombreProducto { set => lblProducto.Text = value; }
        public string Stock { get => lblStock.Text; set => lblStock.Text = value; }
        public string Precio { set => lblPrecio.Text = value; }
        public string Imagen
        {
            set
            {
                if (value != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists(value))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile(value);
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }

            }
        }
        public string Categoria { get; set; }
        private void ucProducto_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Aquamarine;
        }

        private void ucProducto_Leave(object sender, EventArgs e)
        {

        }

        private void ucProducto_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ControlLight;
        }
    }
}
