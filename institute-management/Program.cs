using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using institute_management.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<institute_managementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("institute_managementContext") ?? throw new InvalidOperationException("Connection string 'institute_managementContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
