using BuildingBlocks.Contracts.Usuarios;
using BuildingBlocks.Infra;
using Expedientes.Repository;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Repositories;
using Expedientes.Services.Interfaces;
using Expedientes.Services.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServerDbContext<AppExpedientesContext>(builder.Configuration);

builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IExpedienteService, ExpedienteService>();
builder.Services.AddScoped<IFojaService, FojaService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();

builder.Services.AddRabbitMqMassTransit(
    builder.Configuration,
    endpointPrefix: "svc-expedientes",
    registerConsumers: x =>
    {
        // x.AddConsumer<UsuarioCreadoConsumer>();
        x.AddRequestClient<GetSectorRequest>();

    });
builder.Services.AddApiSwagger("Expedientes API");

var app = builder.Build();
await app.Services.ApplyMigrationsAsync<AppExpedientesContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
MapsterConfiguration.ConfigureMapster();

app.UsePathBase("/expedientes");
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
