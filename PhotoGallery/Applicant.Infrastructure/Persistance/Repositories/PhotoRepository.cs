using Applicant.Domain.Entities;
using Applicant.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicant.Infrastructure.Persistance.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _dbContext;

        public PhotoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Photo>> GetAllPhotosAsync()
        {
            return await _dbContext.Photos.ToListAsync();
        }

        public async Task<Photo> GetPhotoByIdAsync(int id)
        {
            return await _dbContext.Photos.FindAsync(id);
        }

        public async Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(int albumId)
        {
            return await _dbContext.Photos.Where(photo => photo.AlbumId == albumId).ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetPhotosByUserIdAsync(string userId)
        {
            return await _dbContext.Photos.Where(photo => photo.UserId == userId).ToListAsync();
        }

        public async Task AddPhotoAsync(Photo photo)
        {
            _dbContext.Photos.Add(photo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePhotoAsync(Photo photo)
        {
            _dbContext.Entry(photo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePhotoAsync(int id)
        {
            var photo = await _dbContext.Photos.FindAsync(id);
            if (photo != null)
            {
                _dbContext.Photos.Remove(photo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
