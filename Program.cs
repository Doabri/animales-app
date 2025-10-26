using Tarea_Unidad_3.Models.Entities;
using Tarea_Unidad_3.Repositories;
using Tarea_Unidad_3.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<AnimalesContext>();

builder.Services.AddScoped<EspeciesService>();
builder.Services.AddScoped<EspeciesRepository>();
builder.Services.AddScoped<ClaseRepository>();


var app = builder.Build();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapDefaultControllerRoute();

app.UseStaticFiles();

app.Run();




