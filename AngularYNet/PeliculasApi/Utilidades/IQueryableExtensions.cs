using PeliculasApi.DTOs;
using System.Linq;

namespace PeliculasApi.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDto paginacion)
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.ElementosPorPagina)
                .Take(paginacion.ElementosPorPagina);
        }
    }
}
