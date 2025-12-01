using ClinicaParaiso.API.Helpers;
using ClinicaParaiso.Application.Concreta;
using ClinicaParaiso.Application.Helpers;
using ClinicaParaiso.Application.Interface;
using ClinicaParaiso.Persistence.Concreta;
using ClinicaParaiso.Persistence.Data;
using ClinicaParaiso.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ClinicaParaisoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaParaisoConnection"))
);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(ClinicaParaisoProfile).Assembly);
});
//builder.Services.AddAutoMapper(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddScoped<IDefaultPersistence, DefaultPersistence>();
builder.Services.AddScoped<IPacientePersistence, PacientePersistence>();
builder.Services.AddScoped<IEspecialidadePersistence, EspecialidadePersistence>();
builder.Services.AddScoped<IAtendimentoPersistence, AtendimentoPersistence>();

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();
builder.Services.AddScoped<ITriagemService, TriagemService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
})
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context => null!;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

public partial class Program { }