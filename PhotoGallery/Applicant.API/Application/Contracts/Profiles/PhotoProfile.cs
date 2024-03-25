using Applicant.API.Application.Contracts.Dtos.AlbumDtos;
using Applicant.API.Application.Contracts.Dtos.PhotoDtos;
using Applicant.Domain.Entities;
using AutoMapper;

namespace Applicant.API.Application.Contracts.Profiles
{
    public class PhotoProfiles : Profile
    {
        public PhotoProfiles()
        {
            CreateMap<Photo, PhotoReadDto>();
            CreateMap<PhotoReadDto, Photo>();
            CreateMap<PhotoCreateDto, Photo>();
            CreateMap<Photo, PhotoCreateDto>();
            CreateMap<PhotoUpdateDto, Photo>();
        }
    }
}
