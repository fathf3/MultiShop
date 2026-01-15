using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _context.UserComments.Find(id);
            _context.UserComments.Remove(values);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult CommentList(int id)
        {
            var values = _context.UserComments.Find(id);
            return Ok(values);
        }

    }
}
