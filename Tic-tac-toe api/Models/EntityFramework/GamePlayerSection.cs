using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models.EntityFramework
{
    public class GamePlayerSection
    {
        public Guid SectionId { get; set; }
        public Section Section { get; set; }
        public Guid GamePlayerId { get; set; }
        public GamePlayer GamePlayer { get; set; }
    }
}
