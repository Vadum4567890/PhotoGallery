namespace Applicant.API.Application.Contracts.Dtos.PhotoDtos
{
    public class PhotoReadDto
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string ImageSrc { get; set; }

        // Інші властивості, які ви хочете повернути при читанні фото
    }
}
