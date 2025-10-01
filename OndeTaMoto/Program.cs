using OndeTaMotoBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
 
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
 
// A sua string de conexão deve estar no appsettings.json ou em variáveis de ambiente
builder.Services.AddDbContext<DbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EstabelecimentoService>();
builder.Services.AddScoped<SetorService>();
 
var app = builder.Build();
 
// --- CORREÇÃO APLICADA AQUI ---
// Habilita o Swagger e a UI do Swagger em TODOS os ambientes.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API OndeTáMoto v1");
    // Garante que a UI do Swagger esteja na raiz do /swagger
    c.RoutePrefix = "swagger";
});
 
// O bloco 'if' agora pode ser usado para outras coisas específicas de desenvolvimento
if (app.Environment.IsDevelopment())
{
    // Por exemplo, uma página de erro mais detalhada para desenvolvedores.
    app.UseDeveloperExceptionPage();
}
 
 
app.UseCors("AllowAll");
 
app.UseHttpsRedirection();
 
app.UseAuthorization();
 
app.MapControllers();
 
app.Run();
