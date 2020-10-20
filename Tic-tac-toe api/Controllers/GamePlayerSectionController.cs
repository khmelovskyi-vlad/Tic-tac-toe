using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe_api.Data;
using Tic_tac_toe_api.Models;
using Tic_tac_toe_api.Models.EntityFramework;

namespace Tic_tac_toe_api.Controllers
{
    [Authorize]
    [EnableCors("_myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlayerSectionController : ControllerBase
    {
        private readonly Tic_tac_toeContext _context;

        public GamePlayerSectionController(Tic_tac_toeContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<bool> CreateGamePlayerSections(object sectionSectionPrototypesObj)
        {
            var sectionSectionPrototypes = JsonSerializer.Deserialize<List<SectionPrototype>>(sectionSectionPrototypesObj.ToString());
            var allSections = await _context.Sections.ToListAsync();
            foreach (var section in sectionSectionPrototypes)
            {
                var needSection = allSections.Where(sec => sec.XCoordinate == section.XCoordinate && sec.YCoordinate == section.YCoordinate)
                    .FirstOrDefault();
                if (needSection != null)
                {
                    _context.GamePlayerSections.Add(new GamePlayerSection() { SectionId = needSection.Id, GamePlayerId = section.GamePlayerId });
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        //public class GamePlayerSections
        //{
        //    public object SectionPrototype { get; set; }
        //}
        //private void Try(object obj)
        //{
        //    var sasd = obj.ToString();
        //    var lol = new { GamePlayerSections = new SectionPrototype() };
        //    try
        //    {
        //        var kasd = lol.GetType();
        //        var s = obj.ToString();
        //        var k = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    //try
        //    //{
        //    //    GamePlayerSections f = (GamePlayerSections)obj;
        //    //    var k = 0;
        //    //}
        //    //catch (Exception)
        //    //{

        //    //}
        //    try
        //    {
        //        List<SectionPrototype> f = (List<SectionPrototype>)obj;
        //        var k = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    try
        //    {
        //        SectionPrototype[] f = (SectionPrototype[])obj;
        //        var k = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    try
        //    {
        //        var s = obj.ToString();
        //        var r = JsonSerializer.Deserialize<List<SectionPrototype>>(s);
        //        var k = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    try
        //    {
        //        var s = obj.ToString();
        //        var r = JsonSerializer.Deserialize<SectionPrototype[]>(s);
        //        var k = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    try
        //    {
        //        var s = obj.ToString();
        //        var r = JsonSerializer.Deserialize<Array>(s);
        //        var k = 0;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
