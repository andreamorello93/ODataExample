﻿using AutoMapper;
using ODataExample.Application.DTOs;
using ODataExample.DAL.Models;

namespace ODataExample.Application.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;

            CreateMap<Product, ProductDTO>().ReverseMap()
                .ForAllMembers(opt 
                    => opt.ExplicitExpansion());
        }
    }
}
