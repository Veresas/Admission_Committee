using Contracts.Interfaces;
using Database;
using Manager;
using Serilog;

namespace DataGridStarostin.WebApplication
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Seq("http://localhost:5341")
               .CreateLogger();

            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IStudentStorage, DBase>();
            builder.Services.AddScoped<IStudentManager, StudentManager>();
            builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

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
                "default",
                "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
