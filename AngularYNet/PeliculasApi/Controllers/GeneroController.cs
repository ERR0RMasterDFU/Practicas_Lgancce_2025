using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasApi.DTOs;
using PeliculasApi.Excepciones;
using PeliculasApi.Modelos;
using PeliculasApi.Servicios;
using PeliculasApi.Utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasApi.Controllers
{
    [Route("api/genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        /* REPOSITORIO (SIN BASE DE DATOS):
           private readonly IRepositorio repositorio; */

        private readonly GeneroServicio servicio;
        private readonly ILogger<GeneroController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GeneroController(// IRepositorio repositorio,
            GeneroServicio servicio, ILogger<GeneroController> logger,
            ApplicationDbContext context, IMapper mapper
            )
        {
            // this.repositorio = repositorio;
            this.servicio = servicio;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        //[ServiceFilter(typeof(MiFiltroDeAccion))]
        [HttpGet]
        public async Task<ActionResult<List<Genero>>> GetAll([FromQuery] PaginacionDto paginacion)
        {
            // PAGINACIÓN: 
            var queryable = context.Genero.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var listaGeneros = await queryable.OrderBy(x => x.id).Paginar(paginacion).ToListAsync();

            // DTO:
            // return mapper.Map<List<DTO>>(listaGeneros);

            // BÁSICO:
            // return await context.Genero.ToListAsync();
            return listaGeneros;
        }


        [HttpGet("{id:long}")]
        public async Task<ActionResult<Genero>> GetById(long id)
        {
            var genero = await context.Genero.FindAsync(id);
            if(genero == null)
            {
                throw new EntityNotFoundException($"No se ha encontrado ningun Género con el ID: {id}");
            }
            return genero;
        }


        [HttpPost]
        public async Task<ActionResult<Genero>> Save([FromBody] EditGeneroRequest datosGenero)
        {
            Genero nuevoGenero = servicio.Save(datosGenero);
            context.Add(nuevoGenero);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = nuevoGenero.id }, nuevoGenero);
        }


        [HttpPut("{id:long}")]
        public async Task<ActionResult<Genero>> Edit([FromBody] EditGeneroRequest datosGenero, [FromRoute] long id)
        {
            var genero = await GetById(id);
            Genero generoEditado = servicio.Edit(datosGenero, genero.Value);
            context.Update(generoEditado);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = id }, generoEditado);
        }
        
        
        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            //var genero = GetById(id);
            var genero = await context.Genero.FindAsync(id);

            if(genero == null) {
                return NoContent();
            } else
            {
                context.Remove(genero);
                await context.SaveChangesAsync();
                return NoContent();
            }
            
        }
    }
}
