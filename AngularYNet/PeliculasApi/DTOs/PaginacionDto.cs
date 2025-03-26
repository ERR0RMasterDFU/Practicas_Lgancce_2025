namespace PeliculasApi.DTOs
{
    public class PaginacionDto
    {

        public int Pagina { get; set; } = 1;

        private int elementosPorPagina = 20;
        private readonly int maxElementosPorPagina = 100;

        public int ElementosPorPagina
        {
            get
            {
                return elementosPorPagina;
            }
            set
            {
                elementosPorPagina = (value > maxElementosPorPagina) ? maxElementosPorPagina : value;
            }
        }
    }
}
