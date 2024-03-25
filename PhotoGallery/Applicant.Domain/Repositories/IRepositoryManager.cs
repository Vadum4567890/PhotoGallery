using System;


namespace Applicant.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IAccessCodeRepository AccessCodeRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IUnitOfWork UnitOfWork { get; }
        IAlbumRepository AlbumRepository { get; }
        IPhotoRepository PhotoRepository { get; }
    }

}
