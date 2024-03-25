using System.ComponentModel.DataAnnotations;

namespace Applicant.API.Application.Contracts.Dtos.AlbumDtos
{
    public class AlbumCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string UserId { get; set; }
        public IEnumerable<int> PhotoIds { get; set; }
    }
}
