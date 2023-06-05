using MoviesAPI.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.Configure<MoviesDatabaseSettings>(builder.Configuration.GetSection("MoviesDatabaseSettings"));
builder.Services.AddSingleton<MoviesService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
