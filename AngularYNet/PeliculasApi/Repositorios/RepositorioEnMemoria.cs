using PeliculasApi.DTOs;
using PeliculasApi.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace PeliculasApi.Repositorios
{
    public class RepositorioEnMemoria: IRepositorio
    {

        private List<Genero> listadoGeneros;

        public RepositorioEnMemoria()
        {
            listadoGeneros = new List<Genero>();

            listadoGeneros.Add(new Genero { id = 1, nombre = "Comedia" });
            listadoGeneros.Add(new Genero { id = 2, nombre = "Drama" });
            listadoGeneros.Add(new Genero { id = 3, nombre = "Acción" });
            listadoGeneros.Add(new Genero { id = 4, nombre = "Ciencia Ficción" });
        }


        public List<Genero> FindAll()
        {
            return listadoGeneros;
        }


        public Genero FindById(long id)
        {
            /* Busca en listadoGeneros un género cuyo ID sea igual al
               proporcionado y con "FirstOrDefault" (Optional) devuelve
               el objeto o nulo. */

            return listadoGeneros.FirstOrDefault(genero => genero.id == id);
        }


        public Genero Save(EditGeneroRequest datosGenero)
        {
            Genero nuevoGenero = new Genero();

            nuevoGenero.nombre = datosGenero.nombre;

            // listadoGeneros.Add(nuevoGenero);

            return nuevoGenero;
        }


        public Genero Edit(EditGeneroRequest datosGenero, Genero generoAEditar)
        {
            generoAEditar.nombre = datosGenero.nombre;

            return generoAEditar;
        }

        
        public void Delete(Genero genero)
        {
            listadoGeneros.Remove(genero);
        }

    }

}
