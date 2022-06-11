
using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Dominio.Validaciones
{
    public class NotRequiredIfAttribute : ValidationAttribute
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }

        public NotRequiredIfAttribute(string propertyName, object value, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            Value = value;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var instancia = validationContext.ObjectInstance;
            var tipo = instancia.GetType();
            var valorPropiedad = tipo.GetProperty(PropertyName)
                .GetValue(instancia, null);

            if(valorPropiedad.ToString() == Value.ToString() && value != null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

    }
}