using System;
using AutoMapper;
using Person.DTO;
using Person.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Person
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person.Entity.Person, PersonDto>().ReverseMap();
        }
    }
}
