using System;
using System.Threading;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        // Consumer configuration
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "chat-consumers", // A unique name for the consumer group
            AutoOffsetReset = AutoOffsetReset.Earliest // Start reading from the beginning of the topic
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            // Subscribe to the topic
            consumer.Subscribe("chat-message");
            Console.WriteLine("Listening for chat messages... (Press Ctrl+C to exit)");

            // CancellationToken to gracefully shut down
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };

            try
            {
                // Start the consuming loop
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cts.Token);
                        // Print the received message to the console
                        Console.WriteLine($"Received message: {consumeResult.Message.Value}");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consume error: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                consumer.Close();
                Console.WriteLine("Shutting down consumer.");
            }
        }
    }
}