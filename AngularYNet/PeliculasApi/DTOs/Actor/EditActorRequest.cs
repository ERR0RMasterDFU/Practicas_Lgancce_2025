using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace PeliculasApi.DTOs.Actor
{
    public class EditActorRequest
    {
        [Required(ErrorMessage = "El {0} no puede estar vacío")]
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; }

        [StringLength(maximumLength: 15000)]
        public string Biografia { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public IFormFile Foto { get; set; }
    }
}
