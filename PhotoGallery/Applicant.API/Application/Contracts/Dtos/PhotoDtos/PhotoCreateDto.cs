﻿namespace Applicant.API.Application.Contracts.Dtos.PhotoDtos
{
    public class PhotoCreateDto
    {

        public string UserId { get; set; }
        public int AlbumId { get; set; }
    
        public IFormFile ImageFile { get; set; }
    }
}
