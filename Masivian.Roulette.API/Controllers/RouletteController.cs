using EasyCaching.Core;
using Masivian.Roulette.DTO.Roulette;
using Masivian.Roulette.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masivian.Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private IRouletteService _rouletteService;

        public RouletteController(IRouletteService rouletteService) 
        {
            this._rouletteService = rouletteService;
        }

        [HttpGet("new")]
        public IActionResult CreateRoulette()
        {
            return Ok(_rouletteService.CreateRoulette());
        }

        [HttpPut("open/{id}")]
        public IActionResult OpenRoulette(string id)
        {
            return Ok(_rouletteService.OpenRoulette(new OpenRouletteRequestDTO { Id = id}));
        }

        [HttpPost("bet")]
        public IActionResult PlaceBet([FromHeader(Name = "id-user")] string UserId, PlaceBetRequestDTO placeBetRequestDTO)
        {
            placeBetRequestDTO.IdUser = UserId;
            return Ok(_rouletteService.PlaceBet(placeBetRequestDTO));
        }

        [HttpPut("close/{id}")]
        public IActionResult CloseBet([FromRoute(Name = "id")] string id)
        {
            return Ok(_rouletteService.CloseRoulette(new CloseRouletteRequestDTO { Id = id}));
        }

        [HttpGet("get")]
        public IActionResult GetAllRoulette()
        {
            return Ok(_rouletteService.GetAllRoulette());
        }


    }
}
