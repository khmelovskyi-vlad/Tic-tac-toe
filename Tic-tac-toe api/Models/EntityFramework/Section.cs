using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Models.EntityFramework
{
    public class Section
    {
        public Guid Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public List<GamePlayerSection> GamePlayerSections { get; set; }
    }
}
