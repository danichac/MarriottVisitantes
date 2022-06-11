using System;
using System.Linq;
using Xunit;
using MarriottVisitantes.Servicios.Interfaces;
using System.Collections.Generic;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Dominio.Extensiones;
using MarriottVisitantes.PruebasUnitarias;

namespace MarriottVisitantes.Servicios.Reportes
{
    public class GeneradorReporteTests
    {
        private readonly IGeneradorReporte _generadorReporte;

        public GeneradorReporteTests()
        {
            _generadorReporte = new GeneradorReporte();
        }

        [Fact]
        public void Generar_Con_Lista_Vacia_Da_Reporte_Vacio()
        {
            var reporte = _generadorReporte.GenerarReporte(new List<Visita>(), DateTime.Today);

            var cantidadFilas = reporte.Worksheets.FirstOrDefault().Rows().Count();

            Assert.Equal(1, cantidadFilas);
        }

        [Fact]
        public void Encabezados_Son_Correctos()
        {
            var encabezados = Enum.GetValues(typeof(Encabezados))
                .Cast<Encabezados>()
                .Select(x => 
                     x.ObtenerDescripcion().Split('|')[0]
                )
                .ToList();

            var reporte = _generadorReporte.GenerarReporte(new List<Visita>(), DateTime.Today);

            var encabezadosReporte = reporte.Worksheets.FirstOrDefault().FirstRow().Cells()
                .Select(x => x.Value.ToString()).ToList();
                
            var todosSonCorrectos = encabezados.All(e => encabezadosReporte.Contains(e));
            Assert.True(todosSonCorrectos);
        }

        [Fact]
        public void Reporte_Genera_Valores_Correctos()
        {
            
            var listaVisitas = FuenteDatos.ObtenerVisitas();
            var fecha = DateTime.Today;

            var reporte = _generadorReporte.GenerarReporte(listaVisitas, fecha);
            var listaFilas = reporte.Worksheets.FirstOrDefault().Rows().Skip(1).Select(x => x);

            var indiceVisita = 0;

            foreach(var fila in listaFilas)
            {
                
                Assert.Equal(fila.Cell(1).Value.ToString(), listaVisitas[indiceVisita].Visitante.ObtenerNombreCompleto());
                Assert.Equal(fila.Cell(2).Value.ToString(), listaVisitas[indiceVisita].Visitante.Cedula);
                Assert.Equal(fila.Cell(3).Value.ToString(), listaVisitas[indiceVisita].Visitante.NombreEmpresa);
                Assert.Equal(fila.Cell(4).Value.ToString(), 
                    listaVisitas[indiceVisita].ColorGafeteId.GetValueOrDefault(GafeteId.Nulo).ObtenerDescripcion());
                Assert.Equal(fila.Cell(5).Value.ToString(), listaVisitas[indiceVisita].NumeroGafete?.ToString());
                Assert.Equal(fila.Cell(6).Value.ToString(), listaVisitas[indiceVisita].TipoVisitaId.ObtenerDescripcion());
                Assert.Equal(fila.Cell(7).Value.ToString(), listaVisitas[indiceVisita].Usuario.GetNombreApellido());
                Assert.Equal(fila.Cell(8).Value.ToString(), listaVisitas[indiceVisita].HoraEntrada.ToString("HH:mm:ss"));
                Assert.Equal(fila.Cell(9).Value.ToString(), listaVisitas[indiceVisita].HoraSalida?.ToString("HH:mm:ss"));
                Assert.Equal(DateTime.Parse(fila.Cell(10).Value.ToString()).ToString("dd/M/yyyy"),
                    listaVisitas[indiceVisita].FechaVisita.Date.ToString("dd/M/yyyy"));

                indiceVisita ++;
            }
       
        }

        [Fact]
        public void Reporte_Genera_Cantidad_Correcta_De_Filas()
        {
            
            var listaVisitas = FuenteDatos.ObtenerVisitas();
            var fecha = DateTime.Today;
            var cantidadEsperada = listaVisitas.Count + 1;

            var reporte = _generadorReporte.GenerarReporte(listaVisitas, fecha);
            
            var cantidadFilas = reporte.Worksheets.FirstOrDefault().Rows().Count();

            Assert.Equal(cantidadEsperada, cantidadFilas);
        }
    }
}