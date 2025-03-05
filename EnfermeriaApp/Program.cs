using EnfermeriaApp.Repositories;
using EnfermeriaApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<AsignaturaRepository>();
builder.Services.AddSingleton<AsignaturaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Asignaturas/Error"); 
}

app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Asignaturas}/{action=Index}/{id?}");
});

app.Run();
