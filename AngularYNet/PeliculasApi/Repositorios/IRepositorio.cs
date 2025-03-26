using PeliculasApi.DTOs;
using PeliculasApi.Modelos;
using System.Collections.Generic;

namespace PeliculasApi.Repositorios
{
    public interface IRepositorio
    {
        List<Genero> FindAll();

        Genero FindById(long id);

        Genero Save(EditGeneroRequest datosGenero);

        Genero Edit(EditGeneroRequest datosGenero, Genero generoAEditar);
    }
}
