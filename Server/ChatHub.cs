using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_Example.Server;

public class ChatHub : Hub
{
    public async Task Send(string message)
    {
        await this.Clients.All.SendAsync("Receive", message);
    }
}