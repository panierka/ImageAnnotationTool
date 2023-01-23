using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Security;
using Security.Hashing;
using Security.Salting;
using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationTool.Validation;
using ImageProcessing;
using AnnotationEditor;
using CanvasDisplayEngine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<IHashingFunctionProvider, SHA256Hashing>();
builder.Services.AddTransient<ISaltProvider, RngSalting>();
builder.Services.AddTransient<IHashGenerator, SaltedHashGenerator>();

builder.Services.AddTransient<IUserAccountsServiceProvider, UserAccountsServiceProvider>();
builder.Services.AddTransient<IAnnotatedImagesProjectDatabaseServiceProvider, AnnotatedImagesProjectDatabaseServiceProvider>();
builder.Services.AddTransient<ITeamServiceProvider, TeamServiceProvider>();
builder.Services.AddTransient<IProjectServiceProvider, ProjectServiceProvider>();
builder.Services.AddTransient<IJobsServiceProvider, JobsServiceProvider>();

builder.Services.AddTransient<SignUpFormDataValidation>();

builder.Services.AddTransient<IImageDetailsProvider, SixLaborsImageDetailsProvider>();

builder.Services.AddTransient<IColorProvider, RotationalColorProvider>(_ =>
{
    return new RotationalColorProvider(new()
    {
        ColorRGB.Red,
        ColorRGB.Green,
        ColorRGB.Blue,
        ColorRGB.Magenta,
        ColorRGB.Yellow,
        ColorRGB.Cyan,
    });
});

const string CONNECTION_STRING_KEY = "Default";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_STRING_KEY)
	?? throw new NullReferenceException($"No connection string with key={CONNECTION_STRING_KEY}");


builder.Services.AddDbContextFactory<ImageAnnotationToolContext>(options =>
{
    options.UseSqlServer(connectionString);
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
