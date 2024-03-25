using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Applicant.Domain.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Caption { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        
        [NotMapped]
        public string ImageSrc { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}