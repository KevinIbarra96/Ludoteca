using System.Drawing.Printing;
using System.Diagnostics;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.ComponentModel;
using Entidad;
using System.Drawing;
using System.Management;
using System;
using System.Globalization;
using Resources.Properties;
//using DrawingImage = System.Drawing.Image;

namespace Ludoteca.Resources
{
    internal class TicketPrinter
    {
        PrintDocument printtTicket;
        private EN_Visita visita;
        private EN_Fiesta fiesta;

        private readonly CultureInfo culturaMexicana = new CultureInfo("es-MX");

        public TicketPrinter(EN_Visita visita)
        {
            printtTicket = new PrintDocument();
            printtTicket.PrintPage += PrintVisitaPageHandler;
            this.visita = visita;
        }

        public TicketPrinter(EN_Fiesta fiesta)
        {
            printtTicket = new PrintDocument();
            printtTicket.PrintPage += PrintFiestaPageHandler;
        }

        public string[] ListPrinters()
        {

            string[] printerList = new string[PrinterSettings.InstalledPrinters.Count - 4];
            int count = 0;

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                if (!printerName.Contains("OneNote") &&
                    !printerName.Contains("XPS") &&
                    !printerName.Contains("PDF") &&
                    !printerName.Contains("Fax"))
                {
                    printerList[count] = printerName;
                    count += 1;
                }
            }

            return printerList;
        }
        private void PrintFiestaPageHandler(object sender, PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            string imagePath = "logo_lustkids.scale-100.jpeg";

            Graphics gfx = e.Graphics;
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            System.Drawing.Font EncabezadosFont = new System.Drawing.Font("Arial", 7, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 7, FontStyle.Regular);

            int x = 0, y = 5, offset = 10, LineSpace = 12;
            float ancho = 180; // Ancho del área de texto
            float alto = 30; // Alto del área de texto

            // Encabezado centrado
            string titulo = "JUST KIDS";

            gfx.DrawString(titulo, titleFont, Brushes.Black, new RectangleF(x, y, ancho, alto), format);
            offset += LineSpace;

            using (Stream imageStream = FileSystem.OpenAppPackageFileAsync(imagePath).Result)
            {
                if (imageStream != null)
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(imageStream))
                    {
                        // Dibujar la imagen
                        gfx.DrawImage(image, x + 40, y + offset, 110, 40); // Ajusta tamaño y posición
                        offset += (LineSpace * 5);
                    }
                }
            }

            gfx.DrawString("Av. Lázaro Cárdenas No. 1559 ", EncabezadosFont, Brushes.Black, new RectangleF(x, y + offset, ancho, alto), format);
            offset += LineSpace;
            gfx.DrawString("Local A07 Plaza Las Americas ", EncabezadosFont, Brushes.Black, new RectangleF(x, y + offset, ancho, alto), format);
            offset += LineSpace;
            gfx.DrawString("Lázaro Cárdenas Michoacan ", EncabezadosFont, Brushes.Black, new RectangleF(x, y + offset, ancho, alto), format);
            offset += LineSpace;
            gfx.DrawString("Tel. 7536882066 ", EncabezadosFont, Brushes.Black, new RectangleF(x, y + offset, ancho, alto), format);
            offset += (LineSpace * 2);

            gfx.DrawString("Folio: " + fiesta.id, regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            foreach (var hijo in fiesta.Hijo)
            {
                gfx.DrawString("Nombre: " + hijo.NombreHijo, regularFont, Brushes.Black, x, y + offset);
                offset += LineSpace;
            }

            gfx.DrawString("Fecha de la fiesta: " + fiesta.Fecha , regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            gfx.DrawString("Turno: " + fiesta.Turno , regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            gfx.DrawString("Tematica: " + fiesta.Tematica  , regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            gfx.DrawString("Tipo de comida: " + fiesta.TipoComida , regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            gfx.DrawString("Niños adicionales: " + fiesta.NinosAdicionales , regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;

            //Linea Horizontal Ajustada
            offset += LineSpace;
            gfx.DrawLine(Pens.Black, x, offset, x + 200, offset);
            offset += LineSpace;

            //Dibujar Encabezados de productos y Servicios
            gfx.DrawString("Productos y Servicios", EncabezadosFont, Brushes.Black, x, y + offset);
            //gfx.DrawString("Precio ", EncabezadosFont, Brushes.Black, x + 110, y + offset);
            gfx.DrawString("Total ", EncabezadosFont, Brushes.Black, x + 145, y + offset);
            offset += LineSpace;

            gfx.DrawString(fiesta.Servicio.ServicioName, regularFont, Brushes.Black, x, y + offset);
            //gfx.DrawString(fiesta.Servicio.Precio.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
            gfx.DrawString(fiesta.Servicio.Precio.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
            offset += LineSpace;

            gfx.DrawString("Anticipo" , regularFont, Brushes.Black, x, y + offset);
            //gfx.DrawString(fiesta.Servicio.Precio.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
            gfx.DrawString("-"+fiesta.Anticipo.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
            offset += LineSpace;

            //Linea Horizontal Ajustada
            offset += LineSpace;
            gfx.DrawLine(Pens.Black, x, offset, x + 200, offset);
            offset += LineSpace;

            gfx.DrawString("Pendiente", EncabezadosFont, Brushes.Black, x, y + offset);
            gfx.DrawString((fiesta.Total - fiesta.Anticipo).ToString("C2", culturaMexicana), EncabezadosFont, Brushes.Black, x + 135, y + offset);

            offset += (LineSpace * 4);
            gfx.DrawString("¡Gracias por su visita!", titleFont, Brushes.Black, x, y + offset);
        }

        private void PrintVisitaPageHandler(object sender, PrintPageEventArgs e)
        {

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center
            };
            
            string imagePath = "logo_lustkids.scale-100.jpeg";

            Graphics gfx = e.Graphics;
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            System.Drawing.Font EncabezadosFont = new System.Drawing.Font("Arial", 7, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 7, FontStyle.Regular);

            int x = 0, y = 5,offset=10, LineSpace = 12;
            float ancho = 180; // Ancho del área de texto
            float alto = 30; // Alto del área de texto

            // Encabezado centrado
            string titulo = "JUST KIDS";

            gfx.DrawString(titulo, titleFont, Brushes.Black, new RectangleF(x, y, ancho, alto), format);
            offset += LineSpace;

            using (Stream imageStream = FileSystem.OpenAppPackageFileAsync(imagePath).Result)
            {
                if (imageStream != null)
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(imageStream))
                    {
                        // Dibujar la imagen
                        gfx.DrawImage(image, x+40, y+offset, 110, 40); // Ajusta tamaño y posición
                        offset += (LineSpace*5);
                    }
                }
            }

            gfx.DrawString("Av. Lázaro Cárdenas No. 1559 ", EncabezadosFont, Brushes.Black, new RectangleF(x, y+ offset, ancho, alto), format);
            offset += LineSpace;
            gfx.DrawString("Local A07 Plaza Las Americas ", EncabezadosFont, Brushes.Black, new RectangleF(x, y+ offset, ancho, alto), format);
            offset += LineSpace;
            gfx.DrawString("Lázaro Cárdenas Michoacan ", EncabezadosFont, Brushes.Black, new RectangleF(x, y + offset, ancho, alto), format);
            offset += LineSpace;
            gfx.DrawString("Tel. 7536882066 ", EncabezadosFont, Brushes.Black, new RectangleF(x, y + offset, ancho, alto), format);
            offset += (LineSpace * 2);

            gfx.DrawString("Folio: " + visita.id, regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            foreach (var hijo in visita.Hijos)
            {
                gfx.DrawString("Nombre: " + hijo.NombreHijo, regularFont, Brushes.Black,x,y + offset);
                offset += LineSpace;
            }

            gfx.DrawString("Hora entrada: " + visita.HoraEntrada, regularFont, Brushes.Black, x, y+offset);
            offset += LineSpace;
            gfx.DrawString("Hora salida: " + visita.HoraSalida, regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            gfx.DrawString("Gafete: " + visita.NumeroGafete, regularFont, Brushes.Black, x, y + offset) ;
            offset += LineSpace;
            gfx.DrawString("Minutos de estadía: " + visita.TiempoTotal.ToString("N0"), regularFont, Brushes.Black, x, y + offset);
            offset += LineSpace;
            
            if (visita.Servicios.First().Servicio_Id != ApplicationProperties.IdTiempoLibreServicio && visita.TiempoExcedido > 0)
            {
                gfx.DrawString("Minutos extendidos: " + visita.TiempoExcedido.ToString("N0"), regularFont, Brushes.Black, x, y + offset);
                offset += LineSpace;
            }

            //Linea Horizontal Ajustada
            offset += LineSpace;
            gfx.DrawLine(Pens.Black, x, offset, x+200 , offset);
            offset += LineSpace;

            //Dibujar Encabezados de productos y Servicios
            gfx.DrawString("Productos y Servicios" , EncabezadosFont, Brushes.Black, x, y + offset);
            gfx.DrawString("Precio ", EncabezadosFont, Brushes.Black, x+110, y + offset);
            gfx.DrawString("Total ", EncabezadosFont, Brushes.Black, x + 145, y + offset);
            offset += LineSpace;

            foreach (var servicio in visita.Servicios)
            {
                double PrecioTotalTiempo = 0;

                gfx.DrawString(servicio.ServicioName, regularFont, Brushes.Black, x, y + offset);
                gfx.DrawString(servicio.Servicio_Precio.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
                gfx.DrawString((servicio.Servicio_Precio*visita.Hijos.Count).ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
                offset += LineSpace;

                if (servicio.Servicio_Id == ApplicationProperties.IdTiempoLibreServicio)
                {
                    gfx.DrawString("Precio/Minuto", regularFont, Brushes.Black, x+15 , y + offset);
                    if (visita.TiempoTotal <= 35)
                    {
                        gfx.DrawString(((double)ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue).ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
                        PrecioTotalTiempo = visita.TiempoTotal * (double)ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue * visita.Hijos.Count ;
                    }
                    else
                    {
                        gfx.DrawString(((double)ApplicationProperties.PrecioMinutoSesentaMin.ConfigDecimalValue).ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
                        PrecioTotalTiempo = visita.TiempoTotal * (double)ApplicationProperties.PrecioMinutoSesentaMin.ConfigDecimalValue * visita.Hijos.Count;
                    }
                    gfx.DrawString(PrecioTotalTiempo.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
                }
                else
                {
                    //Se calcula el tiempo de tolerancia
                    if(visita.TiempoExcedido > 0)
                    {
                        gfx.DrawString("Precio/Minuto Ex.", regularFont, Brushes.Black, x + 15, y + offset);
                        gfx.DrawString(((double)ApplicationProperties.PrecioMinutoDespuesServicio.ConfigDecimalValue).ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
                        PrecioTotalTiempo = visita.TiempoExcedido * (double)ApplicationProperties.PrecioMinutoDespuesServicio.ConfigDecimalValue * visita.Hijos.Count;
                    }

                    gfx.DrawString(PrecioTotalTiempo.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
                }

                offset += LineSpace;

            }

            foreach (var producto in visita.Productos)
            {
                gfx.DrawString(producto.CantidadProducto, regularFont, Brushes.Black, x, y + offset);
                gfx.DrawString(producto.precioProductoVisita.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
                gfx.DrawString((producto.precioProductoVisita * producto.CantidadProductoVisita).ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
                offset += LineSpace;
            }

            if (!visita.GafeteEntregado)
            {
                gfx.DrawString("Gafete", regularFont, Brushes.Black, x, y + offset);
                gfx.DrawString(50.00.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 110, y + offset);
                gfx.DrawString(50.00.ToString("C2", culturaMexicana), regularFont, Brushes.Black, x + 145, y + offset);
                offset += LineSpace;
            }

            //Linea Horizontal Ajustada
            offset += LineSpace;
            gfx.DrawLine(Pens.Black, x, offset, x + 200, offset);
            offset += LineSpace;

            gfx.DrawString("Total", EncabezadosFont, Brushes.Black, x, y+offset);
            gfx.DrawString(visita.Total.ToString("C2", culturaMexicana), EncabezadosFont, Brushes.Black, x+135, y+offset);

            offset += (LineSpace*4);
            gfx.DrawString("¡Gracias por su visita!", titleFont, Brushes.Black, x, y+offset);

        }

        public async Task PrintTicket(string PrintName)
        {

            printtTicket.PrinterSettings.PrinterName = PrintName;

            if (!printtTicket.PrinterSettings.IsValid)
            {
                Debug.WriteLine("La impresora especificada no es válida.");
                return;
            }
            else
            {
                printtTicket.Print();
                Debug.WriteLine("La impresora imprimió correctamente.");
            }

        }


    }
}
