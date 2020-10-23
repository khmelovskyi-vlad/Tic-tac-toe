using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe_api.Data;
using Tic_tac_toe_api.Models;

namespace Tic_tac_toe_api.Controllers
{
    //[EnableCors("_myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerMatchesController : ControllerBase
    {
        private readonly Tic_tac_toeContext _context;

        public PlayerMatchesController(Tic_tac_toeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<PlayerMatches[]> GetPlayerMatches()
        {
            var result = (await _context.AspNetUsers
                .OrderByDescending(player => player.GamePlayers.Where(gamePlayer => gamePlayer.IsWon).Count())
                .Take(10)
                .Select(player => new PlayerMatches()
                {
                    Name = player.Id,
                    GamesCount = player.GamePlayers.Count(),
                    WonGamesCount = player.GamePlayers.Where(gamePlayer => gamePlayer.IsWon).Count()
                })
                .ToArrayAsync());
            return result;

            //if (gamePlayer == null)
            //{
            //    return NotFound();
            //}

            //return gamePlayer;
        }
    }
}
