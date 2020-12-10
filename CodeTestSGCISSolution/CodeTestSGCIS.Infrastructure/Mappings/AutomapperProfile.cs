using AutoMapper;
using CodeTestSGCIS.Core.DTOs;
using CodeTestSGCIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTestSGCIS.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<TypePerson, PersonTypeDto>();
            CreateMap<PersonTypeDto, TypePerson>();
        }
    }
}
