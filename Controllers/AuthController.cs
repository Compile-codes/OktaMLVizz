using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{
    /// <summary>
    /// Initiates the login process by redirecting the user to Okta.
    /// After successful login, the user will be redirected to /auth/success.
    /// </summary>
    [HttpGet("login")]
    public IActionResult Login()
    {
        return Challenge(new AuthenticationProperties
        {
            RedirectUri = "/auth/success"
        }, OpenIdConnectDefaults.AuthenticationScheme);
    }

    [HttpGet("success")]
    [Authorize]
    public IActionResult Success()
    {
        var userName = User.Identity?.Name ?? "Unknown";
        return Content($"Login successful! Welcome, {userName}");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        return SignOut(new AuthenticationProperties
        {
            RedirectUri = "/auth/loggedout"
        },
        CookieAuthenticationDefaults.AuthenticationScheme,
        OpenIdConnectDefaults.AuthenticationScheme);
    }

    [HttpGet("loggedout")]
    public IActionResult LoggedOut()
    {
        return Content("You have been logged out.");
    }

    [HttpGet("error")]
    [AllowAnonymous]
    public IActionResult Error(string message = "Login failed")
    {
        return Content($"Login error: {message}");
    }
}
