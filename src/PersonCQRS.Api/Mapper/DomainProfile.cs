using System;
using AutoMapper;
using PersonCQRS.Api.Commands;
using PersonCQRS.Domain.AggregatesModel;

namespace PersonCQRS.Api.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<CreatePersonCommand, Person>()
                .ForMember(p => p.DateOfBirth, option =>
                    option.MapFrom(_ => DateTime.Now));
            
        }
    }
}