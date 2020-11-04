using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core_API.Data;
using Core_API.Models;
using Core_API.Mappers;

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
        public async Task<ActionResult<IEnumerable<NewsArticleViewModel>>> GetNewsArticles()
        {
            return await _context.NewsArticles.Select(x => (x.NewsArticleToViewModel())).ToListAsync();
        }

        // GET: api/NewsArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsArticleViewModel>> GetNewsArticle(int id)
        {
            var newsArticle = await _context.NewsArticles.Where(x => x.ID == id).FirstOrDefaultAsync();

            if (newsArticle == null)
            {
                return NotFound();
            }

            return newsArticle.NewsArticleToViewModel();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsArticle(int id, NewsArticleViewModel newsArticleViewModel)
        {
            if (id != newsArticleViewModel.ID)
            {
                return BadRequest();
            }
            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if(newsArticle == null)
            {
                return NotFound();
            }

            newsArticle.ArticleTitle = newsArticleViewModel.ArticleTitle;
            newsArticle.ArticleContent = newsArticleViewModel.ArticleContent;
            newsArticle.ArticlePicture = newsArticleViewModel.ArticlePicture;
            newsArticle.ArticlePictureCredit = newsArticleViewModel.ArticlePictureCredit;
            newsArticle.UserID = "1";

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

        [HttpPost]
        public async Task<ActionResult<NewsArticleViewModel>> PostNewsArticle(NewsArticleViewModel newsArticleViewModel)
        {
            var newsArticle = new NewsArticle
            {
                UserID = "1",
                ArticleTitle = newsArticleViewModel.ArticleTitle,
                ArticleContent = newsArticleViewModel.ArticleContent,
                ArticlePicture = newsArticleViewModel.ArticlePicture,
                ArticlePictureCredit = newsArticleViewModel.ArticlePictureCredit,
                DateTimeCreated = DateTime.Now.ToString("hh:mm | dd-MM-yyyy"),
                TimeStampUploaded = DateTime.Now

            };

            _context.NewsArticles.Add(newsArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNewsArticle), new { id = newsArticleViewModel.ID }, newsArticle.NewsArticleToViewModel());
        }

        // DELETE: api/NewsArticles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsArticleViewModel>> DeleteNewsArticle(int id)
        {
            var newsArticle = await _context.NewsArticles.FindAsync(id);
            if (newsArticle == null)
            {
                return NotFound();
            }

            _context.NewsArticles.Remove(newsArticle);
            await _context.SaveChangesAsync();

            return newsArticle.NewsArticleToViewModel();
        }

        private bool NewsArticleExists(int id)
        {
            return _context.NewsArticles.Any(e => e.ID == id);
        }
    }
}
