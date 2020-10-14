using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe_api.Data;
using Tic_tac_toe_api.Models.EntityFramework;

namespace Tic_tac_toe_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly Tic_tac_toeContext _context;

        public PlayerController(Tic_tac_toeContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPlayer), player.Id);
        }

        [HttpGet/*("{id}")*/]
        public async Task<ActionResult<Player>> GetPlayer(string id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }
    }
}
