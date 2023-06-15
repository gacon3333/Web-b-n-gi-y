
using Assignment.IServices;
using Assignment.Services;
using ClassLibrary1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IGioHangChiTietServices, GioHangChiTietServices>();
builder.Services.AddTransient<IChiTietSpServices, ChiTietSpServices>();
builder.Services.AddTransient<IMauSacServices, MauSacServices>();
builder.Services.AddTransient<IkichCoServices, KichCoServices>();
builder.Services.AddTransient<IKieuSpServices, KieuSpServices>();
builder.Services.AddTransient<IGioHangServices, GioHangServices>();
builder.Services.AddTransient<IHoaDonServices, HoaDonServices>();
builder.Services.AddTransient<IHoaDonChiTietServices, HoaDonChiTietServices>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(9000);
});
builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "629703848067-f626d4aunia9ohbuu063k42qj2prgoqs.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// tìm kiếm sản phẩm theo khoảng giá