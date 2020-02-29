using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using instagram.Models;
using instagram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace instagram.Controllers
{
    [Authorize(Roles = "user")]
    public class PublicationController : Controller
    {
        InstContext _context;
        UserManager<User> _userManager;
        IHostingEnvironment _appEnvironment;

        public PublicationController(InstContext context, IHostingEnvironment appEnvironment, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePublicationViewModel pvm)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Post post = new Post { Coment = pvm.Coment, UserName=user.UserName, dateTime = DateTime.Now};
            if (pvm.Photo != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(pvm.Photo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Photo.Length);
                }

                post.Photo = imageData;
            }
            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Create");
        }

    }
}