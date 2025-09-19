using CSC.NotesMgnt.Application.DTOs;
using CSC.NotesMgnt.Application.Interfaces;
using CSC.NotesMgnt.Application.Services;
using CSC.NotesMgnt.Domain.Entities;
using CSC.NotesMgnt.Domain.IRepository;
using CSC.NotesMgnt.Infrastructure;
using CSC.NotesMgnt.Infrastructure.Repositories;
using CSC.NotesMgnt.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Note, NoteDTO>();
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BaseDbContext>(options =>
 {
     options.UseSqlServer("Data Source=DESKTOP-V6PM2L6\\SQLEXPRESS;Initial Catalog=NotesDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
 }
 );

builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Notes/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notes}/{action=Index}/{id?}");

app.Run();
