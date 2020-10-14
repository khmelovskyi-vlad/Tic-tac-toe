using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models.EntityFramework
{
    public class GamePlayer
    {
        public Guid Id { get; set; }
        public FigureType Figure { get; set; }
        public bool IsWon { get; set; }

        public List<GamePlayerSection> GamePlayerSections { get; set; }
        public Player Player { get; set; }
        public string PlayerId { get; set; }
        public Game Game { get; set; }
        public Guid GameId { get; set; }
    }
}
