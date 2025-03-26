using System;

namespace PeliculasApi.Excepciones
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string mensaje) : base(mensaje)
        {
        }
    }
}
