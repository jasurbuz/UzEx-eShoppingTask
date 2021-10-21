using e_Shopping.Services.DTOs;
using e_Shopping.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MVC_e_Shopping.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public IActionResult Index()
        {
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto.Password == "Admin" && loginDto.Username == "Admin")
            {
                return RedirectToAction(nameof(AdminController.Index), "Admin");
            }

            if (loginDto.Password == "Moderator" && loginDto.Username == "Moderator")
            {
                return RedirectToAction(nameof(BidController.Index), "Bid");
            }
            var client = await _unitOfWork.Clients.Get(c => c.INN == loginDto.Username && c.Password == loginDto.Password);
            
            if(client is null)
            {
                ModelState.AddModelError("", "Invaid username or password");
                return View();
            }

            return RedirectToAction(nameof(BidController.Index), "Bid");
        }
    }
}
