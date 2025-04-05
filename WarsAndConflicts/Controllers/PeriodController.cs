using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WarsAndConflicts.Application.Services;
using WarsAndConflicts.DataAccess.Entities;
using WarsAndConflicts.Models;

namespace WarsAndConflicts.Controllers
{
    public class PeriodController : Controller
    {
        private readonly IPeriodService _periodService;
        private readonly IUserService _userService;

        public PeriodController(IPeriodService periodService, IUserService userService)
        {
            _periodService = periodService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPeriod(string id)
        {
            var period = await _periodService.Get(Guid.Parse(id));

            return View(period);
        }

        [HttpGet]
        public ActionResult CreatePeriod()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePeriod([FromBody] PeriodRequest model)
        {
            var user = await GetUser();

            if(user != null && user.IsAdmin == 1)
            {
                var period = await _periodService.Create(model.Title, model.Description, Convert.FromBase64String(model.Image));

                if(period != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePeriod(string id, [FromBody] PeriodRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var period = await _periodService.Update(Guid.Parse(id),model.Title, model.Description, Convert.FromBase64String(model.Image));

                if (period != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpDelete]
        public async Task<ActionResult> RemovePeriod(string id)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var isSuccess = await _periodService.Remove(Guid.Parse(id));

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
