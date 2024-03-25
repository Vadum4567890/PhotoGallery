using System;

namespace Applicant.API.Application.Services.Interfaces
{
    public interface IServiceManager
    {
        IAccessCodeService AccessCodeService { get; }
        IUserService UserService { get; }
        IAlbumService AlbumService { get; }
        IPhotoService PhotoService { get; }
    }
}