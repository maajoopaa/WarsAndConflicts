using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WarsAndConflicts.Application.Services;
using WarsAndConflicts.DataAccess.Entities;
using WarsAndConflicts.Models;

namespace WarsAndConflicts.Controllers
{
    public class WarController : Controller
    {
        private readonly IWarService _warService;
        private readonly IUserService _userService;
        private readonly IPeriodService _periodService;

        public WarController(IWarService warService, IUserService userService, IPeriodService periodService)
        {
            _warService = warService;
            _userService = userService;
            _periodService = periodService;
        }

        [HttpGet]
        public async Task<ActionResult> GetWar(string id)
        {
            var war = await _warService.Get(Guid.Parse(id));

            var periods = await _periodService.GetList();

            ViewData["Periods"] = periods;

            return View(war);
        }

        [HttpGet]
        public async Task<ActionResult> CreateWar()
        {
            var periods = await _periodService.GetList();

            return PartialView(periods);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWar([FromBody] WarRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var war = await _warService.Create(model.Title, model.Description, Convert.FromBase64String(model.Image), Guid.Parse(model.PeriodId));

                if (war != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateWar(string id, [FromBody] WarRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var war = await _warService.Update(Guid.Parse(id),model.Title, model.Description, Convert.FromBase64String(model.Image), Guid.Parse(model.PeriodId));

                if (war != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveWar(string id)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var isSuccess = await _warService.Remove(Guid.Parse(id));

                if (isSuccess)
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
