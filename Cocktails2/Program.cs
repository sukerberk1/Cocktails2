using Cocktails2.Application;
using Microsoft.EntityFrameworkCore;
using Cocktails2.Application.Services;
using Cocktails2.Application.Services.Interfaces;
using Cocktails2.Persistence.Data;
using Cocktails2.Persistence;

namespace Cocktails2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddPersistence();
        builder.Services.AddApplicationServices();

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

        // Seed DB
        app.Services.SeedDatabase();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}