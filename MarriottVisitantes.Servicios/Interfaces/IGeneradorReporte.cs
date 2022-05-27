using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Servicios.Interfaces
{
    public interface IGeneradorReporte
    {
        public XLWorkbook GenerarReporte(IList<Visita> visitas, DateTime fechaVisitas);
    }
}