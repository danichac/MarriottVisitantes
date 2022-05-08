
using System;
using System.ComponentModel;
using System.Linq;

namespace MarriottVisitantes.Dominio.Extensiones
{
    public static class MarriottExtensiones
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