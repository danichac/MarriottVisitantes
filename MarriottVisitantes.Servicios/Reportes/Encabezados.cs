using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Servicios.Reportes
{
    public enum Encabezados
    {
        [Description("Nombre|A1")]
        Nombre,
        [Description("Identificación|B1")]
        Identificacion,
        [Description("Empresa|C1")]
        Empresa,
        [Description("Color de gafete|D1")]
        ColorGafete,
        [Description("N° de gafete|E1")]
        NumGafete,
        [Description("Tipo de visita|F1")]
        Tipo,
        [Description("Empleado|G1")]
        Empleado,
        [Description("Hora de entrada|H1")]
        Entrada,
        [Description("Hora de salida|I1")]
        Salida,
        [Description("Fecha|J1")]
        Fecha,
        [Description("Temperatura|K1")]
        Temperatura
    }
}