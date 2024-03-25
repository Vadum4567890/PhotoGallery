using System;
using AutoMapper;
using Applicant.Domain.Entities;
using Applicant.API.Application.Contracts.Dtos.OrderDtos;
using Applicant.API.Application.Configurations;

namespace Applicant.API.Application.Contracts.Profiles
{

    public class OrderProfiles : Profile
    {
        public OrderProfiles()
        {
            // Source -> Targer
            CreateMap<OrderResult, OrderReadDto>();
            CreateMap<OrderReadDto, OrderResult>();
           
        }

    }
}
