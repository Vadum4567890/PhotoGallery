using Applicant.API.Application.Contracts.Dtos.AlbumDtos;
using Applicant.API.Application.Contracts.Dtos.UserDtos;
using Applicant.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Applicant.API.Application.Contracts.Profiles
{
    public class AlbumProfiles : Profile
    {
        public AlbumProfiles()
        {
            CreateMap<Album, AlbumReadDto>();
            CreateMap<AlbumReadDto, Album>();
            CreateMap<AlbumCreateDto, Album>();
            CreateMap<Album, AlbumCreateDto>();
            CreateMap<AlbumUpdateDto, Album>();
        }
    }
}
