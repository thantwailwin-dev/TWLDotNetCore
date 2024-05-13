using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection.Metadata;
using TWLDotNetCore.RestApi.Db;
using TWLDotNetCore.RestApi.Models;

namespace TWLDotNetCore.RestApi.Controllers
{
    // api/blog => endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Saving Success!" : "Saving Failed!";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
           
            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating Success!" : "Updating Failed!";
            return Ok(message);            
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }       
            

            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating Success!" : "Updating Failed!";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Deleting Success!" : "Deleting Failed!";
            return Ok(message);
        }
    }
}
