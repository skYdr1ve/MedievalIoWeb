using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using MedievalIo.Services.constants;
using MedievalIo.Web.Helpers;

namespace MedievalIoWeb.Helpers
{
	public class AuthenticationHelper
	{
		public static async Task CreateSessionCookieAsync(HttpContext httpContext, string token, bool isAdmin)
		{
			var claims = GetClaimsList(token, isAdmin);

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			await AuthenticateUserAsync(httpContext, claimsIdentity);
		}

		public static async Task RemoveSessionCookieAsync(HttpContext httpContext)
		{
			await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}

		public static string GetAuthCookie(HttpContext httpContext)
		{
			return httpContext.Request.Cookies[AuthDomainConfig.AuthDomainCookie];
		}

		private static async Task AuthenticateUserAsync(HttpContext httpContext, ClaimsIdentity claimsIdentity)
		{
			var authProperties = new AuthenticationProperties();

			await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
		}

		private static List<Claim> GetClaimsList(string token, bool isAdmin)
		{
			return new List<Claim>
			{
                new Claim(AuthenticationConstants.Token,  token),
				new Claim(AuthenticationConstants.Role, isAdmin ? "Admin" : "" )
            };
		}
	}
}
