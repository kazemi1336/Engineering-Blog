using EnggBlog.Core.Interfaces;
using EnggBlog.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace EnggBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUser _iuser;

        public AccountController(IUser iuser)
        {
            _iuser = iuser;
        }
        public IActionResult Login()
        {
            return View();
        }

        [Route("/Account/Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _iuser.LoginUser(login.Mobile, login.Password);

                if (user != null)
                {

                    var Claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                            new Claim(ClaimTypes.Name,user.Mobile),
                             new Claim(ClaimTypes.MobilePhone,user.Mobile),
                        };
                    var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };

                    HttpContext.SignInAsync(principle);
                    return Redirect("/AdminPanel/Admin/Index");

                }
                else
                {
                    ModelState.AddModelError("Password", "مشخصات کاربری صحیح نمی باشد");
                    return View(login);
                }
            }
            else
            {
                return View(login);
            }
        }
    }
}