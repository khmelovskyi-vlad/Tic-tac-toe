using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models
{
    public class GamePlayerPrototype
    {
        public Guid Id { get; set; }
        public string Figure { get; set; }
        public bool IsWon { get; set; }
        public string PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}
