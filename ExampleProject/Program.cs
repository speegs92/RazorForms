using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorForms.Materialize.Options;
using RazorForms.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// builder.Services.UseRazorFormsWithMaterialize<MaterializeOptions>(MaterializeSetup);

// builder.Services.UseRazorFormsWithBulma<RazorFormsOptions>(BulmaSetup);

builder.Services.UseRazorFormsWithBootstrap5();
// builder.Services.UseRazorFormsWithBootstrap5FloatingLabels<RazorFormsOptions>(Bootstrap5Setup);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
