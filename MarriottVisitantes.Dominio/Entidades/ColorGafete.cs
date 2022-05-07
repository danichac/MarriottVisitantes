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

    public static class EnumExtensions
    {
        public static string ObtenerDescripcion(this Enum GenericEnum)
        {
            var tipoGenerico = GenericEnum.GetType();
            var infoMiembros = tipoGenerico.GetMember(GenericEnum.ToString());

            if (infoMiembros is not null && infoMiembros.Length > 0)
            {
                var attributos = infoMiembros[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributos is not null && attributos.Count() > 0)
                {
                    return ((DescriptionAttribute)attributos.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }
    }
}