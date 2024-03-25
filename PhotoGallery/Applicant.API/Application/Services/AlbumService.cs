using Applicant.API.Application.Contracts.Dtos.AlbumDtos;
using Applicant.API.Application.Services.Interfaces;
using Applicant.Domain.Entities;
using Applicant.Domain.Repositories;
using AutoMapper;

namespace Applicant.API.Application.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepositoryManager _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IRepositoryManager albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AlbumReadDto>> GetAllAlbumsAsync(CancellationToken cancellationToken = default)
        {
            var albums = await _albumRepository.AlbumRepository.GetAllAlbumsAsync();
            return _mapper.Map<IEnumerable<AlbumReadDto>>(albums);
        }

        public async Task<AlbumReadDto> GetAlbumByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var album = await _albumRepository.AlbumRepository.GetAlbumByIdAsync(id);
            return _mapper.Map<AlbumReadDto>(album);
        }

        public async Task<IEnumerable<AlbumReadDto>> GetAlbumsByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            var albums = await _albumRepository.AlbumRepository.GetAlbumsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<AlbumReadDto>>(albums);
        }

        public async Task<AlbumReadDto> CreateAlbumAsync(AlbumCreateDto albumCreateDto, CancellationToken cancellationToken = default)
        {
            var album = _mapper.Map<Album>(albumCreateDto);
            await _albumRepository.AlbumRepository.AddAlbumAsync(album);
            return _mapper.Map<AlbumReadDto>(album);
        }

        public async Task UpdateAlbumAsync(int id, AlbumUpdateDto albumUpdateDto, CancellationToken cancellationToken = default)
        {
            var existingAlbum = await _albumRepository.AlbumRepository.GetAlbumByIdAsync(id);
            if (existingAlbum == null)
            {
                throw new Exception("Album not found");
            }

            _mapper.Map(albumUpdateDto, existingAlbum);
            await _albumRepository.AlbumRepository.UpdateAlbumAsync(existingAlbum);
        }

        public async Task DeleteAlbumAsync(int id, CancellationToken cancellationToken = default)
        {
            await _albumRepository.AlbumRepository.DeleteAlbumAsync(id);
        }
    }
}
