using PeliculasApi.Validaciones;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.DTOs
{
    public class EditGeneroRequest: IValidatableObject
    {
        [Required(ErrorMessage = "El {0} no puede estar vacío")]
        [PrimeraLetraMayuscula]
        public string nombre { get; set; }


        // VALIDACIÓN (CAPITALIZAR "nombre")
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                var primeraLetra = nombre[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                    // "nameof": .get() de C#
                    yield return new ValidationResult("La primera letra debe ser mayúscula.",
                        new string[] {nameof(nombre)});
                }
            }
        }

    }
}
