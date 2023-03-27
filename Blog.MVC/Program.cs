using Blog.BLL;
using Blog.BLL.Concrete;
using Blog.BLL.Helper;
using Blog.DAL.Entities;
using Blog.DAL.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Blog.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddSession();
			builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BlogDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<IAccountManager, AccountManager>();
            builder.Services.AddScoped<IArticleManager, ArticleManager>();
            builder.Services.AddScoped<ICommonManager, CommonManager>();
            builder.Services.AddScoped<IMailService, MailService>();
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			app.UseSession();
			app.UseAuthorization();

			app.MapControllerRoute(name: "activatedmail",
				pattern: "account/activatedmail/{guid}",
				defaults: new { controller = "Account", action = "ActivatedMail" });

			app.MapControllerRoute(name: "signinmail",
				pattern: "account/signinmail/{guid}",
				defaults: new { controller = "Account", action = "SignInMail" });

            //app.MapControllerRoute(name: "articleTagUrl",
            //    pattern: "article/tag/{tagUrl}",
            //    defaults: new {controller = "Home", action = "Index"}
            //    );
			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}