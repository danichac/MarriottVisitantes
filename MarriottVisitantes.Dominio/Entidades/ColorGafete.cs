using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Dominio.Entidades
{

    public class ColorGafete
    {
        public GafeteId Id { get; set; }
        [MaxLength(12)]
        public string Color { get; set; }
    }

    public enum GafeteId
    {
        [Description("Negro")]
        Negro = 1,
        [Description("Amarillo")]
        Amarillo,
        [Description("Café")]
        Cafe,
        [Description("Rojo")]
        Rojo,
        [Description("Verde")]
        Verde
    }

}