using Applicant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Domain.Repositories
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetAllPhotosAsync();
        Task<Photo> GetPhotoByIdAsync(int id);
        Task<IEnumerable<Photo>> GetPhotosByUserIdAsync(string userId);
        Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(int albumId);
        Task AddPhotoAsync(Photo photo);
        Task UpdatePhotoAsync(Photo photo);
        Task DeletePhotoAsync(int id);
    }
}
