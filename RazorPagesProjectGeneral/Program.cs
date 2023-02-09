using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Внедряем зависимость реальной бд
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ImageDBConnection"));
});
// Add services to the container.
builder.Services.AddRazorPages();
// Внедряем зависимости интерфейса и псевдобазы данных
builder.Services.AddSingleton<IImageRepository, MockImageRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
