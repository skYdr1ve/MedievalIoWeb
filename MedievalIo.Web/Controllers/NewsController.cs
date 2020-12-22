using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Services.Interfaces;
using MedievalIoWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalIo.Web.Controllers
{
    public class NewsController : ApiController
    {
        //private readonly INewsService _newsService;

        //public NewsController(INewsService newsService)
        //{
        //    _newsService = newsService;
        //}

        //[HttpPost("Login")]
        //public async Task<IActionResult> Login(LoginModel model)
        //{
        //    try
        //    {
        //        AuthenticatedUserModel user = null;

        //        var result = await _userService.AuthenticateUserAsync(model, AppSettings.UserServiceEndPoint);
        //        if (result != null)
        //        {
        //            await AuthenticationHelper.CreateSessionCookieAsync(HttpContext, result.Token, result.IsAdmin);

        //            user = new AuthenticatedUserModel
        //            {
        //                Token = result.Token,
        //                IsAdmin = result.IsAdmin
        //            };

        //            return Ok(user);
        //        }

        //        return Unauthorized();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        //[HttpGet("CookieExpiration")]
        //public int GetCookieExpirationTime()
        //{
        //    return AppSettings.CookieExpirationInDays;
        //}

        //[Authorize]
        //[HttpGet("Logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    await AuthenticationHelper.RemoveSessionCookieAsync(HttpContext);

        //    return Ok(true);
        //}

        //[HttpPost("Register")]
        //public async Task<IActionResult> Register(RegistrationModel model)
        //{
        //    try
        //    {
        //        var registerUserResult = await _userService.RegisterUserAsync(model, AppSettings.UserServiceEndPoint);
        //        return Ok(registerUserResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(false);
        //    }
        //}
    }
}
