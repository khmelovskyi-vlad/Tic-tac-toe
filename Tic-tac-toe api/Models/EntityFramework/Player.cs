using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models.EntityFramework
{
    public class Player
    {
        public string Id { get; set; }

        public List<GamePlayer> GamePlayers { get; set; }
        //public List<Game> Games { get; set; }
    }
}
