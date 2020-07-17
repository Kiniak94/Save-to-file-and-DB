using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Models;
using RecruitmentTask.Services;

namespace RecruitmentTask.Controllers
{
    [Route("api/[action]")]
    public class FancyTextsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IAsyncFileWriter _writer;

        public FancyTextsController(ApiContext context, IAsyncFileWriter writer)
        {
            _context = context;
            _writer = writer;
        }

        // GET api/gettexts
        [HttpGet]
        public async Task<IActionResult> GetTexts()
        {
            var texts = await _context.FancyTexts.ToArrayAsync();

            return Ok(texts);
        }

        // POST api/firstaction/{value}
        [HttpPost("{value}")]
        public async Task<IActionResult> FirstAction(string value)
        {
            try
            {
                await _writer.WriteToFile(value);

                FancyText text = new FancyText() { Text = value };
                await _context.FancyTexts.AddAsync(text);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            return Ok(value);
        }

        // POST api/secondaction/{value}
        [HttpPost("{value}")]
        public async Task<IActionResult> SecondAction(string value)
        {
            try
            {
                await _writer.WriteToFile(value);

                FancyText text = new FancyText() { Text = value };
                await _context.FancyTexts.AddAsync(text);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(value);
        }
    }
}
