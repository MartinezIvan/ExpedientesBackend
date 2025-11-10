namespace BuildingBlocks.Infra.Options;
public sealed class RabbitMqOptions
{
    public string Host { get; set; } = "rabbitmq";
    public string VirtualHost { get; set; } = "/";
    public string Username { get; set; } = "guest";
    public string Password { get; set; } = "guest";
}