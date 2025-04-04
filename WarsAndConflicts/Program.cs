using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WarsAndConflicts.Application.Services;
using WarsAndConflicts.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//authorization services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Account/SignIn");
builder.Services.AddAuthorization();

//services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IPeriodService, PeriodService>();
builder.Services.AddTransient<IWarService, WarService>();

//db
var connectionString = builder.Configuration.GetConnectionString("WarsDbContext");
builder.Services.AddDbContext<WarsDbContext>(opt => opt.UseLazyLoadingProxies().UseNpgsql(connectionString,
    b => b.MigrationsAssembly("WarsAndConflicts")));

//not cycling json converting
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
