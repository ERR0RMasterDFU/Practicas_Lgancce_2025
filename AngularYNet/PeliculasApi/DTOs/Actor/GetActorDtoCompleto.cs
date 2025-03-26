using System.ComponentModel.DataAnnotations;
using System;

namespace PeliculasApi.DTOs.Actor
{
    public class GetActorDtoCompleto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
    }
}
