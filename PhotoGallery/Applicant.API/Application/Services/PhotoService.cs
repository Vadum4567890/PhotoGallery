using Applicant.API.Application.Contracts.Dtos.PhotoDtos;
using Applicant.API.Application.Services.Interfaces;
using Applicant.Domain.Entities;
using Applicant.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Applicant.API.Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepositoryManager _photoRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhotoService(IRepositoryManager photoRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<PhotoReadDto>> GetAllPhotosAsync()
        {
            var photos = await _photoRepository.PhotoRepository.GetAllPhotosAsync();
            return _mapper.Map<IEnumerable<PhotoReadDto>>(photos);
        }

        public async Task<PhotoReadDto> GetPhotoByIdAsync(int id)
        {
            var photo = await _photoRepository.PhotoRepository.GetPhotoByIdAsync(id);
            return _mapper.Map<PhotoReadDto>(photo);
        }

        public async Task<IEnumerable<PhotoReadDto>> GetPhotosByUserIdAsync(string userId)
        {
            var photos = await _photoRepository.PhotoRepository.GetPhotosByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PhotoReadDto>>(photos);
        }

        public async Task<IEnumerable<PhotoReadDto>> GetPhotosByAlbumIdAsync(int albumId)
        {
            var photos = await _photoRepository.PhotoRepository.GetPhotosByAlbumIdAsync(albumId);
            return _mapper.Map<IEnumerable<PhotoReadDto>>(photos);
        }

        public async Task<PhotoReadDto> AddPhotoAsync(PhotoCreateDto photoCreateDto)
        {
            var imageName = await SaveImage(photoCreateDto.ImageFile);
            var photo = _mapper.Map<Photo>(photoCreateDto);
            photo.Caption = imageName; // Set the ImageSrc directly
            await _photoRepository.PhotoRepository.AddPhotoAsync(photo);
            return _mapper.Map<PhotoReadDto>(photo);
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        public async Task UpdatePhotoAsync(int id, PhotoUpdateDto photoUpdateDto)
        {
            var existingPhoto = await _photoRepository.PhotoRepository.GetPhotoByIdAsync(id);
            if (existingPhoto == null)
            {
                throw new Exception("Photo not found");
            }

            _mapper.Map(photoUpdateDto, existingPhoto);
            await _photoRepository.PhotoRepository.UpdatePhotoAsync(existingPhoto);
        }

        public async Task DeletePhotoAsync(int id)
        {
            var photo =  await _photoRepository.PhotoRepository.GetPhotoByIdAsync(id);
            if (photo != null)
            {
                DeleteImage(photo.Caption);
            }
            
             await _photoRepository.PhotoRepository.DeletePhotoAsync(id);
             
        }

        public async Task LikePhotoAsync(int id)
        {
            var photo = await _photoRepository.PhotoRepository.GetPhotoByIdAsync(id);
            if (photo == null)
            {
                throw new Exception("Photo not found");
            }

            photo.Likes++;
            await _photoRepository.PhotoRepository.UpdatePhotoAsync(photo);
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        public async Task DislikePhotoAsync(int id)
        {
            var photo = await _photoRepository.PhotoRepository.GetPhotoByIdAsync(id);
            if (photo == null)
            {
                throw new Exception("Photo not found");
            }

            photo.Dislikes++;
            await _photoRepository.PhotoRepository.UpdatePhotoAsync(photo);
        }
    }
}
