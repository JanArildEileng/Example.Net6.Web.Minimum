using MediatR;

namespace  ExampleMeditor;

public class Ping : INotification { }

public class Pong1 : INotificationHandler<Ping>
{
    private readonly ILogger<Pong1> logger;

    public Pong1(ILogger<Pong1> logger)
    {
        this.logger = logger;
    }

    public Task Handle(Ping notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Pong 1");
        return Task.CompletedTask;
    }
}

public class Pong2 : INotificationHandler<Ping>
{
    private readonly ILogger<Pong2> logger;

    public Pong2(ILogger<Pong2> logger)
    {
        this.logger = logger;
    }

    public Task Handle(Ping notification, CancellationToken cancellationToken)
    {
         logger.LogInformation("Pong 2");
        return Task.CompletedTask;
    }
}