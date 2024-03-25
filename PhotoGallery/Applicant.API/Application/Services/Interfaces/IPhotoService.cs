using Applicant.API.Application.Contracts.Dtos.PhotoDtos;

namespace Applicant.API.Application.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoReadDto>> GetAllPhotosAsync();
        Task<PhotoReadDto> GetPhotoByIdAsync(int id);
        Task<IEnumerable<PhotoReadDto>> GetPhotosByUserIdAsync(string userId);
        Task<IEnumerable<PhotoReadDto>> GetPhotosByAlbumIdAsync(int albumId);
        Task<PhotoReadDto> AddPhotoAsync(PhotoCreateDto photoCreateDto);
        Task UpdatePhotoAsync(int id, PhotoUpdateDto photoUpdateDto);
        Task DeletePhotoAsync(int id);
        Task LikePhotoAsync(int id);
        Task DislikePhotoAsync(int id);
    }
}
