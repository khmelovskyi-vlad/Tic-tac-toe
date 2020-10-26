using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.SignalRApp.Hubs
{
    public interface ITic_tac_toeClient
    {
        Task StartGameAsPlayer1(string playerName);
        Task StartGameAsPlayer2(string playerName);
        Task ReloadPage();
        Task ReceiveCoordinates(int i, int j);
    }
}
