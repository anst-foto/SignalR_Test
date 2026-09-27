using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
.WithUrl("http://localhost:5278/chat")
.Build();

connection.On<string>("Receive", (message) =>
{
    Console.WriteLine(message);
});

await connection.StartAsync();

while(true)
{
    Console.Write("[USER]: ");
    var message = Console.ReadLine();

    if (message == "exit") return 0;

    await connection.InvokeAsync("Send", message);
}