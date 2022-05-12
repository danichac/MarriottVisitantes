using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Dominio.Entidades
{

    public class TipoVisita
    {
        public TipoVisitaId Id { get; set; }
        [MaxLength(50)]
        public string Tipo { get; set; }
    }

    public enum TipoVisitaId
    {
        [Description("Entrega")]
        Entrega = 1,
        [Description("Extensa")]
        Extensa,
    }

}