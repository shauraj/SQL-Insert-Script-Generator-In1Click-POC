using SQL_InsertScriptGenerator_In1Click.Data;
using SQL_InsertScriptGenerator_In1Click.Interfaces;
using SQL_InsertScriptGenerator_In1Click.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISQLInsertScriptGeneratorService, SQLInsertScriptGeneratorService>();
builder.Services.AddScoped<SQLInsertScriptGeneratorDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Sql/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sql}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
