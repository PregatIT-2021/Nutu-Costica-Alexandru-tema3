using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pregatit.MonkeyFinder.Services.Dto;
using Pregatit.MonkeyFinder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pregatit.MonkeyFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonkeyController : ControllerBase
    {
        private readonly ILogger<MonkeyController> _logger;
        private readonly IMonkeyService _monkeyService;
        public MonkeyController(ILogger<MonkeyController> logger, IMonkeyService monkeyService)
        {
            _logger = logger;
            _monkeyService = monkeyService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> GetMonkeyAsync()
        {
            //_logger.LogInformation("Monkeys were retrieved successfully. Mounkeys count : {@count}", result.Count());

            var result = await _monkeyService.GetMonkeysAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> GetMonkeyByIDAsync(int id)
        {
            var result = await _monkeyService.GetMonkeyAsyncByID(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateMonkeyAsync([FromBody] MonkeyDto monkeyDto)
        {
            var result = await _monkeyService.CreateMonkeyAsync(monkeyDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMonkeyByIDAsync(int id)
        {
            var result = await _monkeyService.DeleteMonkeyByIDAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateMonkeyByIDAsync([FromBody] MonkeyDto monkey, int id)
        {
            var result = await _monkeyService.UpdateMonkeyByIDAsync(monkey, id);
            return Ok(result);
        }

        

    }
}
