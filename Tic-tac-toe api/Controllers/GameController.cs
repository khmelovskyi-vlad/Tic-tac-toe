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
using Tic_tac_toe_api.Models.EntityFramework;

namespace Tic_tac_toe_api.Controllers
{
    [Authorize]
    [EnableCors("_myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly Tic_tac_toeContext _context;

        public GameController(Tic_tac_toeContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        //{
        //    return await _context.Games
        //        //.Select(x => ItemToDTO(x))
        //        .ToListAsync();
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateGame(Guid id, Game game)
        //{
        //    if (id != game.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var foundGame = await _context.Games.FindAsync(id);
        //    if (foundGame == null)
        //    {
        //        return NotFound();
        //    }

        //    foundGame.LinesCount = game.LinesCount;
        //    foundGame.WinLine = game.WinLine;
        //    foundGame.GameTime = game.GameTime;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException) when (!GameExists(id))
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
        //public class GamePrototype
        //{
        //    public int LinesCount { get; set; }
        //    public int WinLine { get; set; }
        //    public DateTime GameTime { get; set; }
        //}
        [HttpPost]
        public async Task<Guid> CreateGame(Game game)
        {
            game.Id = Guid.NewGuid();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
            //return CreatedAtAction(
            //    nameof(GetGame),game.Id);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGame(Guid id)
        //{
        //    var game = await _context.Games.FindAsync(id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Games.Remove(game);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool GameExists(Guid id) =>
        //     _context.Games.Any(e => e.Id == id);

        //private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
        //    new TodoItemDTO
        //    {
        //        Id = todoItem.Id,
        //        Name = todoItem.Name,
        //        IsComplete = todoItem.IsComplete
        //    };
    }
}
