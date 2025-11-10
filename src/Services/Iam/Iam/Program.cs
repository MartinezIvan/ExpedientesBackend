
using BuildingBlocks.Infra;
using Iam.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServerDbContext<AppIamContext>(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddRabbitMqMassTransit(
    builder.Configuration,
    endpointPrefix: "svc-iam",
    registerConsumers: x =>
    {
        // x.AddConsumer<UsuarioCreadoConsumer>();
    });
builder.Services.AddApiSwagger("IAM API");

var app = builder.Build();
await app.Services.ApplyMigrationsAsync<AppIamContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
