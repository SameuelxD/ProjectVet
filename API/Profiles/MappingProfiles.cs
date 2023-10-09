using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        { 
            CreateMap<Cita,CitaDto>().ReverseMap();
            CreateMap<Ciudad,CiudadDto>().ReverseMap();
            CreateMap<ClienteDireccion,ClienteDireccionDto>().ReverseMap();
            CreateMap<Cliente,ClienteDto>().ReverseMap();    
            CreateMap<ClienteTelefono,ClienteTelefonoDto>().ReverseMap();
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<Mascota,MascotaDto>().ReverseMap();  
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Raza,RazaDto>().ReverseMap();
            CreateMap<Servicio,ServicioDto>().ReverseMap();  

        /* Toma la Entidad Pais y mapeala de acuerdo a la estructura del Dto 
        
        ReverseMap permite convertir de Entidad a Dto y de Dto a Entidad , es como un puente entre ellas , de esta forma es que se establece la relacion con los Dtos */
        
        }
    }
}