using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Configure Entity Framework with an in-memory database
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));


// Configure Identity services and link to Entity Framework stores
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();


builder.Services.AddAuthentication();
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();



app.MapGet("/", () => "I am root");
app.MapGet("/admin-only", () => "admin access only").RequireAuthorization();
app.MapGet("/user-claim-check", () => "Access with specific claim").RequireAuthorization();


var roles = new[] { "Admin", "User" };




app.Run();
  