using Microsoft.AspNetCore.SignalR.Client;
using System;

var connection = new HubConnectionBuilder()
.WithUrl("https://localhost:7276/chat")
.Build();

connection.On<string>("Receive", async message =>
{
    await Console.Out.WriteLineAsync($"[SERVER]: {message}");
});

await connection.StartAsync();


await Console.Out.WriteAsync("[CLIENT]: ");
var message = await Console.In.ReadLineAsync();
await connection.InvokeAsync("Send", message);
