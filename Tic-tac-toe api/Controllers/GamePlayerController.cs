using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tic_tac_toe_api.Data;
using Tic_tac_toe_api.Models;
using Tic_tac_toe_api.Models.EntityFramework;

namespace Tic_tac_toe_api.Controllers
{
    //[EnableCors("_myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamePlayerController : ControllerBase
    {
        private readonly Tic_tac_toeContext _context;

        public GamePlayerController(Tic_tac_toeContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<Guid> CreateGamePlayer(GamePlayerPrototype gamePlayerPrototype)
        {
            var gamePlayer = new GamePlayer()
            {
                Id = Guid.NewGuid(),
                Figure = gamePlayerPrototype.Figure == "x" ? FigureType.x : FigureType.o,
                IsWon = gamePlayerPrototype.IsWon,
                AspNetUserId = gamePlayerPrototype.PlayerId,
                GameId = gamePlayerPrototype.GameId
            };
            _context.GamePlayers.Add(gamePlayer);
            await _context.SaveChangesAsync();
            return gamePlayer.Id;
            //return Guid.NewGuid();
            //return CreatedAtAction(
            //    nameof(GetGamePlayer), gamePlayer.Id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamePlayer>> GetGamePlayer(Guid id)
        {
            var gamePlayer = await _context.GamePlayers.FindAsync(id);

            if (gamePlayer == null)
            {
                return NotFound();
            }

            return gamePlayer;
        }
    }
}
