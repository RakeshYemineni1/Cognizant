using Confluent.Kafka;

const string bootstrapServers = "localhost:9092";
const string topic = "chat-topic";

Console.WriteLine("Kafka Chat App");
Console.WriteLine("Press P to start Producer, C to start Consumer, Q to quit");

var key = Console.ReadKey(true).Key;

if (key == ConsoleKey.P)
{
    Console.WriteLine("Producer started. Type messages and press Enter to send. Type 'exit' to quit.");

    var config = new ProducerConfig { BootstrapServers = bootstrapServers };

    using var producer = new ProducerBuilder<Null, string>(config).Build();

    while (true)
    {
        var message = Console.ReadLine();
        if (message == "exit") break;

        await producer.ProduceAsync(topic, new Message<Null, string> { Value = message! });
        Console.WriteLine($"Sent: {message}");
    }
}
else if (key == ConsoleKey.C)
{
    Console.WriteLine("Consumer started. Listening for messages... Press Ctrl+C to stop.");

    var config = new ConsumerConfig
    {
        BootstrapServers = bootstrapServers,
        GroupId = "chat-group",
        AutoOffsetReset = AutoOffsetReset.Earliest
    };

    using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
    consumer.Subscribe(topic);

    var cts = new CancellationTokenSource();
    Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };

    try
    {
        while (!cts.Token.IsCancellationRequested)
        {
            var result = consumer.Consume(cts.Token);
            Console.WriteLine($"Received: {result.Message.Value}");
        }
    }
    catch (OperationCanceledException) { }
    finally
    {
        consumer.Close();
    }
}
