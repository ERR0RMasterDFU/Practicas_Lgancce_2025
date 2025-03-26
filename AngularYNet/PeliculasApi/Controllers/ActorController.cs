using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi.DTOs;
using PeliculasApi.Excepciones;
using PeliculasApi.Modelos;
using PeliculasApi.Utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PeliculasApi.DTOs.Actor;
using System;

namespace PeliculasApi.Controllers
{
    [Route("api/actor")]
    [ApiController]
    public class ActorController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorDeArchivos;
        private readonly string contendor = "actores";

        public ActorController(ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorDeArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorDeArchivos = almacenadorDeArchivos;
        }


        [HttpGet]
        public async Task<ActionResult<List<GetActorDtoSimple>>> GetAll([FromQuery] PaginacionDto paginacion)
        {
            // PAGINACIÓN: 
            var queryable = context.Actor.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var listaActores = await queryable.OrderBy(x => x.Id).Paginar(paginacion).ToListAsync();

            return mapper.Map<List<GetActorDtoSimple>>(listaActores);
        }


        [HttpGet("{id:long}")]
        public async Task<ActionResult<GetActorDtoCompleto>> GetById(long id)
        {
            var actor = await context.Actor.FindAsync(id);
            if (actor == null)
            {
                throw new EntityNotFoundException($"No se ha encontrado ningún Actor con el ID: {id}");
            }
            return mapper.Map<GetActorDtoCompleto>(actor);
        }


        [HttpPost]
        public async Task<ActionResult<GetActorDtoCompleto>> Save([FromForm] EditActorRequest datosActor)
        {
            var nuevoActor = mapper.Map<Actor>(datosActor);
            
            if (datosActor.Foto != null)
            {
                nuevoActor.Foto = await almacenadorDeArchivos.GuardarArchivo(contendor, datosActor.Foto);
            }

            context.Add(nuevoActor);
            await context.SaveChangesAsync();
            Console.WriteLine(datosActor.Foto);
            var nuevoActorDto = mapper.Map<GetActorDtoCompleto>(nuevoActor);

            return CreatedAtAction(nameof(GetById), new { id = nuevoActorDto.Id }, nuevoActorDto);
        }

        /*
        [HttpPut("{id:long}")]
        public async Task<ActionResult<Actor>> Edit([FromBody] EditActorRequest datosActor, [FromRoute] long id)
        {
            var actor = await GetById(id);
            Actor actorEditado = servicio.Edit(datosGenero, genero.Value);
            context.Update(actorEditado);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = id }, actorEditado);
        }*/


        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            var actor = await context.Actor.FindAsync(id);

            if (actor == null)
            {
                return NoContent();
            }
            else
            {
                context.Remove(actor);
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
        
    }
}
