using DAL;
using BLL;
using Microsoft.EntityFrameworkCore;
using DAL.Classes;
using DAL.Interfaces;
using BLL.Classes;
using BLL.Interfaces;
using BLL.Services;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSession(options =>{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<CollegeDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped(typeof(IGenericActionsDB<>), typeof(GenericActionsDB<>));
builder.Services.AddScoped< ICustomersService, CustomersService>();
builder.Services.AddScoped< IOrderManagmentService, OrderManagementServices>();
builder.Services.AddScoped<IEndOrder, EndOrder>();
builder.Services.AddScoped<IimageService,ImageService>();
builder.Services.AddScoped<SpecificActionsBD>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
