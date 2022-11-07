// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Azure Service Bus Message Consumer");

string connectionString = "AzureServiceBusConnectionString";
string queueName = "QueueName";

await using var client = new ServiceBusClient(connectionString);
ServiceBusReceiver receiver = client.CreateReceiver(queueName);
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

string body = receivedMessage.Body.ToString();
Console.WriteLine(body);
