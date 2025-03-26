using System;
using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Modelos
{
    public class Actor
    {
        public long Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; }

        [StringLength(maximumLength: 15000)]
        public string Biografia { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Foto { get; set; }
    }
}
