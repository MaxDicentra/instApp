using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using instagram.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Diagnostics;

namespace instagram.Controllers
{
    public class HomeController : Controller
    {
        InstContext _context;
        UserManager<User> _userManager;

        public HomeController(InstContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);

            List<Post> allPosts = _context.Posts.ToList();
            List<Post> userPosts = new List<Post>();
            if (User.Identity.IsAuthenticated)
            {
                foreach (var post in allPosts)
                {
                    if (post.UserName == user.UserName)
                        userPosts.Add(post);
                }
                userPosts.OrderByDescending(x => x.dateTime).ThenByDescending(x => x.dateTime.TimeOfDay).ToList();
            }
            userPosts.Reverse();
            return View(userPosts);
        }

        public async Task<IActionResult> Feed()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);

            List<Post> allPosts = _context.Posts.ToList();
            allPosts.OrderByDescending(x => x.dateTime).ThenByDescending(x => x.dateTime.TimeOfDay).ToList();
            allPosts.Reverse();
            return View(allPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? code)
        {
            var error = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            switch (code) {
                case 404: error.MessageForUser = ($"The path {HttpContext.Features.Get<IExceptionHandlerPathFeature>()} can't be found");                                    
                    break;
                default: error.MessageForUser = null;

                    var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                    Log._logger.LogError($"The path {exceptionHandlerPathFeature.Path} " +
                        $"threw an exception {exceptionHandlerPathFeature.Error}");
                    break;    
            }
            return View(error);
        }

        
    }
}
