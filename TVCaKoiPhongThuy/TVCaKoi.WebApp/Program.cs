using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;

namespace TVCaKoi.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
            {
            // Yêu cầu xác thực cho tất cả các trang trong thư mục /Admin
                options.Conventions.AuthorizeFolder("/Admin/Index");
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Admin/Login"; // Đường dẫn đến trang đăng nhập
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Đặt thời gian sống của cookie là 5 phút
                options.SlidingExpiration = true; // Tự động gia hạn cookie khi người dùng hoạt động
            });

            // Kết nối database
            var connectionstring = builder.Configuration.GetConnectionString("MySqlConn");
            builder.Services.AddDbContext<ApptvcakoiContext>(options =>
            {
                options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
            });


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

            app.UseAuthentication();
            app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
