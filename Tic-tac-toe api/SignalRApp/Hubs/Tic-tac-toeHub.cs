using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.SignalRApp.Hubs
{
    [Authorize]
    [EnableCors("_myPolicy")]
    public class Tic_tac_toeHub : Hub<ITic_tac_toeClient>
    {
        public async Task AddToGroup(string groupName, string playerName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).StartGameAsPlayer1(playerName);
        }
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task SendPlayerName(string groupName, string playerName)
        {
            await Clients.OthersInGroup(groupName).StartGameAsPlayer2(playerName);
        }
        public async Task SendReloadPage(string groupName)
        {
            await Clients.Group(groupName).ReloadPage();
        }
        public async Task SendCoordinates(string groupName, int i, int j)
        {
            await Clients.OthersInGroup(groupName).ReceiveCoordinates(i,j);
        }
    }
}
