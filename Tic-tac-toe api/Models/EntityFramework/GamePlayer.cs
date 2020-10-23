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
        public AspNetUser AspNetUser { get; set; }
        public string AspNetUserId { get; set; }
        public Game Game { get; set; }
        public Guid GameId { get; set; }
    }
}
