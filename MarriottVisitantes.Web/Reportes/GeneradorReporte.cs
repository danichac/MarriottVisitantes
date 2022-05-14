using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Dominio.Extensiones;

namespace MarriottVisitantes.Web.Reportes
{
    public class GeneradorReporte
    {
        public XLWorkbook GenerarReporte(IList<Visita> visitas, DateTime fechaVisitas)
        {
            var encabezados = Enum.GetValues(typeof(Encabezados))
                .Cast<Encabezados>()
                .Select(x => 
                    new KeyValuePair<string,string>(x.ObtenerDescripcion().Split('|')[1], x.ObtenerDescripcion().Split('|')[0])
                )
                .ToList();

            var reporte = new XLWorkbook();
            var sheet = reporte.AddWorksheet();
            
            foreach(var encabezado in encabezados)
            {
                sheet.Cell(encabezado.Key).Value = encabezado.Value;
                sheet.Cell(encabezado.Key).Style.Font.Bold = true;
            }

            int fila = 2;

            foreach(var visita in visitas)
            {
                sheet.Cell($"A{fila}").Value = visita.Visitante.ObtenerNombreCompleto();
                sheet.Cell($"B{fila}").Value = visita.Visitante.Cedula;
                sheet.Cell($"C{fila}").Value = visita.Visitante.NombreEmpresa;
                sheet.Cell($"D{fila}").Value = visita.ColorGafeteId.ObtenerDescripcion();
                sheet.Cell($"E{fila}").Value = visita.NumeroGafete;
                sheet.Cell($"F{fila}").Value = visita.TipoVisitaId.ObtenerDescripcion();
                sheet.Cell($"G{fila}").Value = visita.Usuario.GetNombreApellido();;
                sheet.Cell($"H{fila}").Value = string.Format("{0:t}",visita.HoraEntrada);
                sheet.Cell($"I{fila}").Value = string.Format("{0:t}", visita.HoraSalida);
                sheet.Cell($"J{fila}").Value = visita.FechaVisita.ToString("dd/MM/yyyy");
                sheet.Cell($"K{fila}").Value = visita.Temperatura?.ToString();
                fila++;
            }

            return reporte;
        }
    }
}