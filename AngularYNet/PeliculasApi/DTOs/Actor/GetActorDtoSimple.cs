using System.ComponentModel.DataAnnotations;
using System;

namespace PeliculasApi.DTOs.Actor
{
    public class GetActorDtoSimple
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
    }
}
