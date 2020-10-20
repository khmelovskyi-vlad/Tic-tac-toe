using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.SignalRApp.Hubs
{
    [EnableCors("_myPolicy")]
    public class Tic_tac_toeHub : Hub
    {
        public async Task AddToGroup(string groupName, string playerName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("StartGameAsPlayer1", playerName);
        }
        public async Task SendPlayerName(string groupName, string playerName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("StartGameAsPlayer2", playerName);
        }
        public async Task SendReloadPage(string groupName)
        {
            await Clients.Group(groupName).SendAsync("ReloadPage");
        }
        public async Task SendCoordinates(string groupName, int i, int j)
        {
            await Clients.OthersInGroup(groupName).SendAsync("ReceiveCoordinates", i, j);
        }
    }
}
