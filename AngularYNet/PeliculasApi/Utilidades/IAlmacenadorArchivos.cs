using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PeliculasApi.Utilidades
{
    public interface IAlmacenadorArchivos
    {
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> EditarArchivo(string contendor, IFormFile archivo, string ruta);
        Task<string> GuardarArchivo(string contendor, IFormFile archivo);
    }
}
