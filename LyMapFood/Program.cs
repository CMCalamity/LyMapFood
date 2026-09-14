var builder = WebApplication.CreateBuilder(args);

// Bật dịch vụ MVC và Session
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Cho phép nạp file index.html làm trang chủ mặc định
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

// UseSession PHẢI nằm TRƯỚC UseAuthorization và MapControllerRoute
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();