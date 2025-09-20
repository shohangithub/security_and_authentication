using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Configure Entity Framework with an in-memory database
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));


// Configure Identity services and link to Entity Framework stores
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();


// over-write redirect url
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        // override unauthorize access redirect path
        if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == StatusCodes.Status200OK)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }

        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
});



// Configure authentication and authorization
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationBuilder()
       .AddPolicy("admin", policy => policy.RequireRole("Admin"))
       .AddPolicy("doctor", policy => policy.RequireClaim("type", "doctor"))
       .AddPolicy("patient", policy => policy.RequireRole("User").RequireClaim("type", "patient"))
       .AddPolicy("user", policy => policy.RequireRole("User"));


builder.Services.AddTransient<IEmailSender, EmailSender>();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapPublicEndpoints();
app.MapAdminEndpoints();
app.MapAccountEndpoints();

app.MapGet("/", () => "I am root");

var roles = new[] { "Admin", "User" };

app.Run();
