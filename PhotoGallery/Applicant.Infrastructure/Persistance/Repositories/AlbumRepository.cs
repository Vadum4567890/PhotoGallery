using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applicant.Domain.Entities;
using Applicant.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Applicant.Infrastructure.Persistance.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _dbContext;

        public AlbumRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            return await _dbContext.Albums.ToListAsync();
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            return await _dbContext.Albums.FindAsync(id);
        }

        public async Task<IEnumerable<Album>> GetAlbumsByUserIdAsync(string userId)
        {
            return await _dbContext.Albums.Where(album => album.UserId == userId).ToListAsync();
        }

        public async Task AddAlbumAsync(Album album)
        {
            _dbContext.Albums.Add(album);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            _dbContext.Entry(album).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAlbumAsync(int id)
        {
            var album = await _dbContext.Albums.FindAsync(id);
            if (album != null)
            {
                _dbContext.Albums.Remove(album);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
