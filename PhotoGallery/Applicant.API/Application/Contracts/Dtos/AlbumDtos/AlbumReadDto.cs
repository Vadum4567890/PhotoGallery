namespace Applicant.API.Application.Contracts.Dtos.AlbumDtos
{
    public class AlbumReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public IEnumerable<int> PhotoIds { get; set; }
    }

}
