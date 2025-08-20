using DotNetEnv;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Read env vars
string oktaDomain = Environment.GetEnvironmentVariable("OKTA_DOMAIN") ?? throw new("Missing OKTA_DOMAIN");
string clientId = Environment.GetEnvironmentVariable("OKTA_CLIENT_ID") ?? throw new("Missing OKTA_CLIENT_ID");
string clientSecret = Environment.GetEnvironmentVariable("OKTA_CLIENT_SECRET") ?? throw new("Missing OKTA_CLIENT_SECRET");
string callbackPath = Environment.GetEnvironmentVariable("OKTA_CALLBACK_PATH") ?? "/signin-oidc";

// Authentication pipeline: Cookie + OpenID Connect
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    options.Authority = $"{oktaDomain}/oauth2/default";
    options.ClientId = clientId;
    options.ClientSecret = clientSecret;
    options.CallbackPath = callbackPath;

    options.ResponseType = "code";
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;

    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name",
        ValidateIssuer = true
    };

    // Redirect to error page if login fails
    options.Events = new OpenIdConnectEvents
    {
        OnRemoteFailure = context =>
        {
            context.Response.Redirect("/auth/error?message=" + Uri.EscapeDataString(context.Failure?.Message ?? "Login failed"));
            context.HandleResponse();
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();