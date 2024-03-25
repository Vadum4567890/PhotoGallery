using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Applicant.API.Application.Services.Interfaces;
using Applicant.API.Application.Contracts.Dtos.AlbumDtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Applicant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums(CancellationToken cancellationToken = default)
        {
            var albums = await _albumService.GetAllAlbumsAsync(cancellationToken);
            return Ok(albums);
        }

        [HttpGet("{id}", Name = "GetAlbumById")]
        public async Task<IActionResult> GetAlbumById(int id, CancellationToken cancellationToken = default)
        {
            var album = await _albumService.GetAlbumByIdAsync(id, cancellationToken);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAlbum([FromBody] AlbumCreateDto albumCreateDto, CancellationToken cancellationToken = default)
        {
            var createdAlbum = await _albumService.CreateAlbumAsync(albumCreateDto, cancellationToken);
            return CreatedAtAction(nameof(GetAlbumById), new { id = createdAlbum.Id }, createdAlbum);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAlbum(int id, [FromBody] AlbumUpdateDto albumUpdateDto, CancellationToken cancellationToken = default)
        {
            if (id != albumUpdateDto.Id)
            {
                return BadRequest();
            }

            await _albumService.UpdateAlbumAsync(id, albumUpdateDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAlbum(int id, CancellationToken cancellationToken = default)
        {
            await _albumService.DeleteAlbumAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
