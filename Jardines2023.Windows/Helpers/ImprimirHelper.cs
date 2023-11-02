using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static iTextSharp.tool.xml.html.HTML;
using Jardines2023.Entidades.Dtos.Venta;
using System.Collections;

namespace Jardines2023.Windows.Helpers
{
	public static class ImprimirHelper
	{
		public static void ImprimirReporteCategorias(List<Categoria> lista)
		{
			CrearCarpetaReportes();
			var path = Environment.CurrentDirectory+@"\Reportes";
			var archivo = "ListaCategorias.pdf";
			var completo=Path.Combine(path,archivo);
			string PdfFile = Properties.Resources.ListaCategorias.ToString();
			PdfFile = PdfFile.Replace("@fecha", DateTime.Today.ToShortDateString());
			string lineas = string.Empty;
			foreach (var categoria in lista)
			{
				lineas += "<tr>";
				lineas += "<td>" + categoria.NombreCategoria + "</td>";
				lineas += "</tr>";

			}
			PdfFile = PdfFile.Replace("@filas", lineas);
			PdfFile = PdfFile.Replace("@cantidad", lista.Count.ToString());
			GuardarPdfImagen(completo, PdfFile);
		}

		private static void GuardarPdfImagen(string completo, string PaginaHTML_Texto)
		{
			using (FileStream stream = new FileStream(completo, FileMode.Create))
			{
				//Creamos un nuevo documento y lo definimos como PDF
				Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

				PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
				pdfDoc.Open();
				pdfDoc.Add(new Phrase(""));

				//Agregamos la imagen del banner al documento
				//iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.shop,
				//	System.Drawing.Imaging.ImageFormat.Png);
				//img.ScaleToFit(60, 60);
				//img.Alignment = iTextSharp.text.Image.UNDERLYING;

				////img.SetAbsolutePosition(10,100);
				//img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
				//pdfDoc.Add(img);


				using (StringReader sr = new StringReader(PaginaHTML_Texto))
				{
					XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
				}

				pdfDoc.Close();
				stream.Close();
				Process.Start($"{completo}"); //Muestra el reporte
			}
		}


		private static void CrearCarpetaReportes()
		{
			var path = Environment.CurrentDirectory;
			var carpeta = "Reportes";
			var completo = Path.Combine(path, carpeta);
			if (!Directory.Exists(completo))
			{
				Directory.CreateDirectory(completo);
			}
		}

		public static void ImprimirFactura(VentaDetalleDto ventaDto)
		{
			CrearCarpetaReportes();
			var path = Environment.CurrentDirectory + @"\Reportes";
			var archivo = $"{DateTime.Today.Year}{DateTime.Today.Month}{DateTime.Today.Day}{ventaDto.ventaListDto.Cliente}.pdf";
			var completo = Path.Combine(path, archivo);
			string PdfFile = Properties.Resources.NuevaFactura.ToString();
			PdfFile = PdfFile.Replace("@Nro", ventaDto.ventaListDto.VentaId.ToString().PadLeft(8,'0'));
			PdfFile = PdfFile.Replace("@CLIENTE", ventaDto.ventaListDto.Cliente.ToString());
			PdfFile = PdfFile.Replace("@DIRECCION", ventaDto.ventaListDto.Domicilio);
			PdfFile = PdfFile.Replace("@FECHA", ventaDto.ventaListDto.FechaVenta.ToShortDateString());
			string lineas = string.Empty;
			foreach (var itemVenta in ventaDto.DetallesDto)
			{
				lineas += "<tr>";
				lineas += "<td>" + itemVenta.Cantidad + "</td>";
				lineas += "<td>" + itemVenta.NombreProducto + "</td>";
				lineas += "<td style='text-align: right;'>" + itemVenta.PrecioUnitario.ToString("N2") + "</td>";
				lineas += "<td style='text-align: right;'>" + itemVenta.Total.ToString("N2") + "</td>";
				lineas += "</tr>";

			}
			PdfFile = PdfFile.Replace("@FILAS", lineas);
			PdfFile = PdfFile.Replace("@TOTAL", ventaDto.ventaListDto.Total.ToString("N2"));
			GuardarPdfImagen(completo, PdfFile);

		}
	}
}
