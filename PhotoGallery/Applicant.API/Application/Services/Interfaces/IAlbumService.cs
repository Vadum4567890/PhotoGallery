using Applicant.API.Application.Contracts.Dtos.AlbumDtos;

namespace Applicant.API.Application.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumReadDto>> GetAllAlbumsAsync(CancellationToken cancellationToken = default);
        Task<AlbumReadDto> GetAlbumByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<AlbumReadDto>> GetAlbumsByUserIdAsync(string userId, CancellationToken cancellationToken = default);
        Task<AlbumReadDto> CreateAlbumAsync(AlbumCreateDto albumCreateDto, CancellationToken cancellationToken = default);
        Task UpdateAlbumAsync(int id, AlbumUpdateDto albumUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAlbumAsync(int id, CancellationToken cancellationToken = default);
    }
}
