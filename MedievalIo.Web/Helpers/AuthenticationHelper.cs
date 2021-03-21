using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using MedievalIo.Services.constants;
using MedievalIo.Web.Helpers;
using System.IdentityModel.Tokens.Jwt;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using MedievalIo.Web.Models;

namespace MedievalIoWeb.Helpers
{
	public class AuthenticationHelper
	{
        private static IJsonSerializer _serializer = new JsonNetSerializer();
        private static IDateTimeProvider _provider = new UtcDateTimeProvider();
        private static IBase64UrlEncoder _urlEncoder = new JwtBase64UrlEncoder();
        private static IJwtAlgorithm _algorithm = new HMACSHA256Algorithm();

		public static async Task CreateSessionCookieAsync(HttpContext httpContext, string token, bool isAdmin, string id)
		{
			var claims = GetClaimsList(token, isAdmin, id);

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

        public static DateTime GetExpiryTimestamp(string accessToken)
        {
            try
            {
                IJwtValidator _validator = new JwtValidator(_serializer, _provider);
                IJwtDecoder decoder = new JwtDecoder(_serializer, _validator, _urlEncoder, _algorithm);
                var token = decoder.DecodeToObject<JwtToken>(accessToken);
                var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(token.exp);
                return dateTimeOffset.LocalDateTime;
            }
            catch (TokenExpiredException)
            {
                return DateTime.MinValue;
            }
            catch (SignatureVerificationException)
            {
                return DateTime.MinValue;
            }
            catch (Exception ex)
            {
                // ... remember to handle the generic exception ...
                return DateTime.MinValue;
            }
        }

        private static async Task AuthenticateUserAsync(HttpContext httpContext, ClaimsIdentity claimsIdentity)
		{
			var authProperties = new AuthenticationProperties();

			await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
		}

		private static List<Claim> GetClaimsList(string token, bool isAdmin, string id)
		{
			return new List<Claim>
			{
                new Claim(AuthenticationConstants.Token,  token),
				new Claim(AuthenticationConstants.Id, id),
				new Claim(AuthenticationConstants.Role, isAdmin ? "Admin" : "" )
            };
		}
    }
}
