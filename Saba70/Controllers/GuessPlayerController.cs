using AutoMapper;
using Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Services;

namespace Saba70.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuessPlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GuessPlayerController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult> GetPlayers()
        {
            var players = await _unitOfWork.GueessPlayers.GetAll();

            var playersCount = players.Count();
            if (playersCount == 0)
                return NotFound("no players ");

            Random rnd = new Random();
            var randomNum = rnd.Next(1, playersCount +1);
            var player = await _unitOfWork.GueessPlayers.GetById(randomNum );

            return Ok(player);
        }
    }
}
