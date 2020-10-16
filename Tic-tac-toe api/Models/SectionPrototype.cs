using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models
{
    public class SectionPrototype
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Guid GamePlayerId { get; set; }
    }
}
