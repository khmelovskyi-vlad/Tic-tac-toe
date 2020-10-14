using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models.EntityFramework
{
    public class Game
    {
        public Guid Id { get; set; }
        public int LinesCount { get; set; }
        public int WinLine { get; set; }
        public DateTime GameTime { get; set; }


        public List<GamePlayer> GamePlayers { get; set; }
    }
}
