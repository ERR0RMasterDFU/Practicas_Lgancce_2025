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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PeliculasApi.Controllers
{
    [Route("api/actor")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActorController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorDeArchivos;
        private readonly string contenedor = "actores";

        public ActorController(ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorDeArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorDeArchivos = almacenadorDeArchivos;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetActorDtoSimple>>> GetAll([FromQuery] PaginacionDto paginacion)
        {
            // PAGINACIÓN: 
            var queryable = context.Actor.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var listaActores = await queryable.OrderBy(x => x.Id).Paginar(paginacion).ToListAsync();

            return mapper.Map<List<GetActorDtoSimple>>(listaActores);
        }


        [HttpGet("{id:long}")]
        [AllowAnonymous]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<GetActorDtoCompleto>> Save([FromForm] EditActorRequest datosActor)
        {
            var nuevoActor = mapper.Map<Actor>(datosActor);
            
            if (datosActor.Foto != null)
            {
                nuevoActor.Foto = await almacenadorDeArchivos.GuardarArchivo(contenedor, datosActor.Foto);
            }

            context.Add(nuevoActor);
            await context.SaveChangesAsync();
           
            var nuevoActorDto = mapper.Map<GetActorDtoCompleto>(nuevoActor);

            return CreatedAtAction(nameof(GetById), new { id = nuevoActorDto.Id }, nuevoActorDto);
        }

        
        [HttpPut("{id:long}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<Actor>> Edit([FromForm] EditActorRequest datosActor, [FromRoute] long id)
        {

            var actorAEditar = await context.Actor.FindAsync(id);
            if (actorAEditar == null)
            {
                throw new EntityNotFoundException($"No se ha encontrado ningún Actor con el ID: {id}");
            }

            var actorEditado = mapper.Map(datosActor, actorAEditar);

            // Si la foto es null, la lógica de borrar y no guardar se maneja en el método EditarArchivo
            if (datosActor.Foto != null)
            {
                actorEditado.Foto = await almacenadorDeArchivos.EditarArchivo(contenedor, datosActor.Foto, actorEditado.Foto);
            }
            else
            {
                // Si no hay foto, la ruta se establecerá a null y no se guardará ninguna foto
                actorEditado.Foto = null;
            }

            context.Update(actorEditado);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = id }, actorEditado);
        }


        [HttpDelete("{id:long}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
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
                await almacenadorDeArchivos.BorrarArchivo(actor.Foto, contenedor);
                return NoContent();
            }
        }
        
    }
}
