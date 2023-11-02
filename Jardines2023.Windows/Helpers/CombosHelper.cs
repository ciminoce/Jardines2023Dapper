using Jardines2023.Entidades.Dtos.Categoria;
using Jardines2023.Entidades.Dtos.Ciudad;
using Jardines2023.Entidades.Dtos.Proveedor;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using System;
using System.Windows.Forms;

namespace Jardines2023.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarComboPaises(ref ComboBox combo)
        {
            IServiciosPaises serviciosPaises = new ServiciosPaises();
            var lista = serviciosPaises.GetPaises(null);
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "Seleccione País"
            };
            lista.Insert(0, defaultPais);
            combo.DataSource = lista;
            combo.DisplayMember = "NombrePais";
            combo.ValueMember = "PaisId";
            combo.SelectedIndex = 0;
        }
        public static void CargarComboCiudades(ref ComboBox combo, int paisId)
        {
            IServiciosCiudades serviciosCiudades = new ServiciosCiudades();
            var lista = serviciosCiudades.GetCiudadesCombos(paisId);
            var defaultCiudad = new CiudadComboDto()
            {
                CiudadId = 0,
                NombreCiudad = "Seleccione Ciudad"
            };
            lista.Insert(0, defaultCiudad);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreCiudad";
            combo.ValueMember = "CiudadId";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboCategorias(ref ComboBox combo)
        {
            IServiciosCategorias serviciosCategorias = new ServiciosCategorias();
            var lista = serviciosCategorias.GetCategoriasCombos();
            var defaultCategoria = new CategoriaComboDto()
            {
                CategoriaId = 0,
                NombreCategoria = "Seleccione Categoría"
            };
            lista.Insert(0, defaultCategoria);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreCategoria";
            combo.ValueMember = "CategoriaId";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboProveedores(ref ComboBox combo)
        {
            IServiciosProveedores serviciosProveedores = new ServiciosProveedores();
            var lista = serviciosProveedores.GetProveedoresCombo();
            var defaultProveedor = new ProveedorComboDto()
            {
                ProveedorId = 0,
                NombreProveedor = "Seleccione Proveedor"
            };
            lista.Insert(0, defaultProveedor);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreProveedor";
            combo.ValueMember = "ProveedorId";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboMeses(ref ComboBox combo)
        {
            for (int i = 1;i<=12; i++)
            {
                string mes=i.ToString().PadLeft(2,'0');
                combo.Items.Add(mes);
            }
            combo.SelectedIndex = -1;
        }

        public static void CargarComboAnios(ref ComboBox combo)
        {
            int anioActual=DateTime.Now.Year;
            for (int i = anioActual; i <= anioActual + 10; i++)
            {
                /*2023
                 *0123 
                 * substring(2,2)=23
                 */
				string anio =i.ToString().Substring(2,2);
				combo.Items.Add(anio);
			}
			combo.SelectedIndex = -1;
		}
	}
}
