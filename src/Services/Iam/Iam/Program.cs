
using BuildingBlocks.Infra;
using Iam.Repository;
using Iam.Repository.Interfaces;
using Iam.Repository.Repositories;
using Iam.Services.Interfaces;
using Iam.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServerDbContext<AppIamContext>(builder.Configuration);

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
}
MapsterConfiguration.ConfigureMapster();

app.UsePathBase("/iam");
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
