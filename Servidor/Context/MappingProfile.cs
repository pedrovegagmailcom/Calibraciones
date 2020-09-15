using ApiWebNetCore.DTOS;
using ApiWebNetCore.Modelo;
using AutoMapper;
using System;


namespace ApiWebNetCore.Context
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Usuario, UsuarioSesionDTO>();
            
            CreateMap<UsuarioSesionDTO, Usuario>();
        }
    }
}
