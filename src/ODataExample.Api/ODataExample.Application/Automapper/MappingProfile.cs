using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ODataExample.Application.DTOs;
using ODataExample.DAL.Models;

namespace ODataExample.Application.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForAllMembers(opt 
                    => opt.ExplicitExpansion());
        }
    }
}
