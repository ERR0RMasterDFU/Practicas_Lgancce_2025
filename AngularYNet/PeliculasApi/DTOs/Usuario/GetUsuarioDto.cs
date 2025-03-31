using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.DTOs.Usuario
{
    public class GetUsuarioDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
