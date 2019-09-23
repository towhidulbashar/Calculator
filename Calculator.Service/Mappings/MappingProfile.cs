using AutoMapper;
using Calculator.Domain;
using Calculator.Resource;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Resource to domain
            CreateMap<CreateApplicationUserResource, ApplicationUser>();

            //Domain to response
            CreateMap<CalculationHistory, CalculationHistoryResponse>()
                .ForMember(response => response.UserName, d => d.MapFrom(history => history.ApplicationUser.UserName));
        }
    }
}
