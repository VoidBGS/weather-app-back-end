using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_API.Data;
using Core_API.Mappers;
using Core_API.Models;
using Core_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly WeatherHovenContext _context;

        public PicturesController(WeatherHovenContext context)
        {
            _context = context;
        }

        // GET: api/Pictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPicturesOfTheDay()
        {
            return await _context.Pictures.OrderByDescending(x => x.TimeStamp).ToListAsync();
        }

        // GET api/<PicturesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> GetPictureOfTheDay(int id)
        {
            var picture = await _context.Pictures.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (picture == null)
            {
                return NotFound();
            }

            return picture;
        }

        // POST api/<PicturesController
        [HttpPost]
        public async Task<ActionResult<PictureViewModel>> PostPictureOfTheDay(PictureViewModel pictureViewModel)
        {
            var picture = new Picture
            {
                AuthorName = pictureViewModel.AuthorName,
                Link = pictureViewModel.Link,
                DateTimeCreated = DateTime.Now.ToString("hh:mm | dd-MM-yyyy"),
                TimeStamp = DateTime.Now
            };

            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPicturesOfTheDay), new { id = picture.Id }, picture.PictureToViewModel(picture.AuthorName));
        }

        // DELETE api/<PicturesController/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<PictureViewModel>> DeletePictureOfTheDay(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);

            if (picture == null)
            {
                return NotFound();
            }

            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
