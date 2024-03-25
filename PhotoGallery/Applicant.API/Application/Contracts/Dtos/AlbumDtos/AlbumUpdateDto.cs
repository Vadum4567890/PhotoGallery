using System.ComponentModel.DataAnnotations;

namespace Applicant.API.Application.Contracts.Dtos.AlbumDtos
{
    public class AlbumUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public IEnumerable<int> PhotoIds { get; set; }
    }
}
