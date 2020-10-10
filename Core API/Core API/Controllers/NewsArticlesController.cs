using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core_API.Data;
using Core_API.Models;

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        private readonly NewsArticleContext _context;

        public NewsArticlesController(NewsArticleContext context)
        {
            _context = context;
        }

        // GET: api/NewsArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsArticles()
        {
            return await _context.NewsArticles.ToListAsync();
        }

        // GET: api/NewsArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsArticle>> GetNewsArticle(int id)
        {
            var newsArticle = await _context.NewsArticles.FindAsync(id);

            if (newsArticle == null)
            {
                return NotFound();
            }

            return newsArticle;
        }

        // PUT: api/NewsArticles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsArticle(int id, NewsArticle newsArticle)
        {
            if (id != newsArticle.ID)
            {
                return BadRequest();
            }

            _context.Entry(newsArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NewsArticles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NewsArticle>> PostNewsArticle(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsArticle", new { id = newsArticle.ID }, newsArticle);
        }

        // DELETE: api/NewsArticles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsArticle>> DeleteNewsArticle(int id)
        {
            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            _context.NewsArticles.Remove(newsArticle);
            await _context.SaveChangesAsync();

            return newsArticle;
        }

        private bool NewsArticleExists(int id)
        {
            return _context.NewsArticles.Any(e => e.ID == id);
        }
    }
}
