using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models
{
    public class PlayerMatches
    {
        public string Name { get; set; }
        public int GamesCount { get; set; }
        public int WonGamesCount { get; set; }
    }
}
