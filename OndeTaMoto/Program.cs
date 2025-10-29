using OndeTaMotoBusiness;
using OndeTaMotoData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
 
builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API OndeTáMoto",
        Version = "v1",
        Description = "Documentação da API OndeTáMoto usando Swagger"
    });
});
 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EstabelecimentoService>();
builder.Services.AddScoped<SetorService>();
 
var app = builder.Build();
 

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var loggerFactory = services.GetService<ILoggerFactory>();
        loggerFactory?.CreateLogger("Program").LogError(ex, "Failed to apply database migrations. Check connection string and DB credentials.");
      
    }
}
 
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API OndeTáMoto v1");
    c.RoutePrefix = "swagger";
});
 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
 
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();