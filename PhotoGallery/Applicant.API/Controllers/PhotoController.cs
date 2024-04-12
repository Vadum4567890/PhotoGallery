using Applicant.API.Application.Contracts.Dtos.PhotoDtos;
using Applicant.API.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Applicant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhotoController(IPhotoService photoService, IWebHostEnvironment webHostEnvironment)
        {
            _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoReadDto>>> GetAllPhotosAsync()
        {
            var photos = await _photoService.GetAllPhotosAsync();

            var photoDtos = photos.Select(photo => new PhotoReadDto
            {
                Caption = photo.Caption,
                Dislikes = photo.Dislikes,
                Id = photo.Id,
                ImageSrc = String.Format("{0}://{1}/Images/{2}", Request.Scheme, Request.Host, photo.Caption),
                Likes = photo.Likes,
            });

            return Ok(photoDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PhotoReadDto>>> GetPhotoByIdAsync(int id)
        {
            var photos = await _photoService.GetPhotosByAlbumIdAsync(id);

            if (photos == null || !photos.Any())
            {
                return NotFound();
            }

            var photoDtos = photos.Select(photo => new PhotoReadDto
            {
                Caption = photo.Caption,
                Dislikes = photo.Dislikes,
                Id = photo.Id,
                ImageSrc = String.Format("{0}://{1}/Images/{2}", Request.Scheme, Request.Host, photo.Caption),
                Likes = photo.Likes,
            });

            return Ok(photoDtos);
        }


        [HttpPost]
        public async Task<ActionResult<PhotoReadDto>> AddPhotoAsync([FromForm] PhotoCreateDto photoCreateDto)
        {
      
            var photo = await _photoService.AddPhotoAsync(photoCreateDto);
            if (photo == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetPhotoByIdAsync), new { id = photo.Id }, photo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhotoAsync(int id, [FromForm] PhotoUpdateDto photoUpdateDto)
        {
            if (id != photoUpdateDto.Id)
            {
                return BadRequest();
            }

            await _photoService.UpdatePhotoAsync(id, photoUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoAsync(int id)
        {
            await _photoService.DeletePhotoAsync(id);

            return NoContent();
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikePhotoAsync(int id)
        {
            await _photoService.LikePhotoAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/dislike")]
        public async Task<IActionResult> DislikePhotoAsync(int id)
        {
            await _photoService.DislikePhotoAsync(id);
            return NoContent();
        }



     
    }
}
