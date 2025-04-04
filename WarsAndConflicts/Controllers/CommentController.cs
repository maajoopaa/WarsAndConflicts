using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WarsAndConflicts.Application.Services;
using WarsAndConflicts.DataAccess.Entities;
using WarsAndConflicts.Models;

namespace WarsAndConflicts.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetComments(string warId)
        {
            var comments = await _commentService.GetList(Guid.Parse(warId));

            return Json(comments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment([FromBody] CommentRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var comment = await _commentService.Create(model.Body, user.Id, Guid.Parse(model.WarId));

                if (comment != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        private async Task<UserEntity?> GetUser()
        {
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (claimValue is not null)
            {
                var user = await _userService.Get(Guid.Parse(claimValue));

                return user;
            }

            return null;
        }
    }
}
