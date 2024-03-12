using JogoAdivinha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Xml;
using System.Data;
using System.Data.SqlClient;

namespace JogoAdivinha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlite(builder.Configuration.GetConnectionString("ConexaoSQLite")));

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Jogo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}