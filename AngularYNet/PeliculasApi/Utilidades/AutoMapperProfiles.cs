using AutoMapper;
using PeliculasApi.DTOs;
using PeliculasApi.DTOs.Actor;
using PeliculasApi.Modelos;

namespace PeliculasApi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // GÉNERO
            CreateMap<EditGeneroRequest, Genero>();

            // ACTOR
            CreateMap<EditActorRequest, Actor>().ForMember(x => x.Foto, options => options.Ignore()); // SE IGNORA LA FOTO
            CreateMap<Actor, GetActorDtoSimple>().ReverseMap();
            CreateMap<Actor, GetActorDtoCompleto>().ReverseMap();
            CreateMap<GetActorDtoCompleto, Actor>().ReverseMap();


            /* 
          
            LISTAS:
             
                AQUÍ:
                    1- CreateMap<Entidad, DTO>().ReverseMap();

                 CONTROLLER:
                    1- Implementar IMapper mapper
                    2- return mapper.Map<List<DTO>>(listaAMapear);


            CREACIÓN:
             
                AQUÍ:
                    1- CreateMap<DTO, Entidad>();

                 CONTROLLER:
                    1- Implementar IMapper mapper
                    2- return mapper.Map<Genero>(DTO);
            */
        }
    }
}
