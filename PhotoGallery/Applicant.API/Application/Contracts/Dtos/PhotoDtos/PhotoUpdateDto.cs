namespace Applicant.API.Application.Contracts.Dtos.PhotoDtos
{
    public class PhotoUpdateDto
    {
        public int Id { get; set; } // Ідентифікатор фотографії, який потрібно оновити
        public string Caption { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}