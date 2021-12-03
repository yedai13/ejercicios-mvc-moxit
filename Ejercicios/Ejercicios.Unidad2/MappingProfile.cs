using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ejercicios.Unidad2.Dtos;
using Ejercicios.Unidad2.Models;

namespace Ejercicios.Unidad2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();




            CreateMap<CustomerDto, Customer>()
                .ForMember( c => c.Id, option => option.Ignore());
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, option => option.Ignore());
        }
    }
}
