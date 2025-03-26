using PeliculasApi.DTOs;
using PeliculasApi.Excepciones;
using PeliculasApi.Modelos;
using PeliculasApi.Repositorios;
using System.Collections.Generic;

namespace PeliculasApi.Servicios
{
    public class GeneroServicio
    {
        private IRepositorio repositorio;

        public GeneroServicio(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }


        public List<Genero> FindAll()
        {
            return repositorio.FindAll();
        }


        public Genero FindById(long id)
        {
            Genero genero = repositorio.FindById(id);

            if (genero == null)
            {
                throw new EntityNotFoundException($"No se ha encontrado ningun Género con el ID: {id}");
            }

            return genero;
        }


        public Genero Save(EditGeneroRequest datosGenero)
        {
            return repositorio.Save(datosGenero);
        }


        public Genero Edit(EditGeneroRequest datosGenero, Genero genero)
        {
            //Genero genero = FindById(id);

            return repositorio.Edit(datosGenero, genero);
        }
    }
}
