using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orientation_example_exam.Data;
using Orientation_example_exam.Models;
using Orientation_example_exam.ViewModels;
using Orientation_example_exam.Services;
using Microsoft.AspNetCore.Mvc;

namespace Orientation_example_exam.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel();
            vm.User = new User();

            return View(vm);
        }

        [HttpPost("save-link")]
        public IActionResult Index(User user)
        {
            IndexViewModel vm = new IndexViewModel();

            if (userService.IsAliasInDb(user))
            {
                ViewData["status"] = "Your alias is already in use!";
                vm.User = user;

                return View(vm);
            }
            else
            {
                User newUser = new User(user.Alias, user.Url);
                userService.AddUserToDb(newUser);
                ViewData["status"] = $"Your URL is aliased to {newUser.Alias} and your secret code is {newUser.SecretCode}.";
                vm.User = new User();

                return View(vm);
            }
        }

        [HttpGet("a/{alias}")]
        public IActionResult Alias(string alias)
        {
            if (userService.IsAliasInDb(alias))
            {
                userService.HitCountUp(alias);
                string url = userService.FindUrl(alias);

                return Redirect(url);
            }
            else
            {
                return StatusCode(404, "Error");
                //return NotFound("Error"); 
            }
        }

        [HttpGet("api/links")]
        public IActionResult ApiLinks()
        {
            return Ok(userService.FillList());
        }

        [HttpDelete("api/links/{id}")]
        public IActionResult Delete(long id, [FromBody]User user)
        {
            if(!userService.IsUserInDb(id))
            {
                return NotFound();
            }
            else if (userService.IsCorrectSecretCode(id, user.SecretCode))
            {
                userService.Delete(user.SecretCode);
                return NoContent();
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}