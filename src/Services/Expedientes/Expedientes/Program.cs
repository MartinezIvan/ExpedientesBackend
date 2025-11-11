using BuildingBlocks.Infra;
using Expedientes.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServerDbContext<AppExpedientesContext>(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddRabbitMqMassTransit(
    builder.Configuration,
    endpointPrefix: "svc-expedientes",
    registerConsumers: x =>
    {
        // x.AddConsumer<UsuarioCreadoConsumer>();
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
