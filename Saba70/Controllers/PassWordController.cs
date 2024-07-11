using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Saba70.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassWordController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PassWordController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult> GetPlayer()
        {
            var players = await _unitOfWork.PassWords.GetAll();

            var playersCount = players.Count();
            if (playersCount < 10)
                return NotFound("no players ");

            var PlayersList = new List<PassWord>();

            Random rnd = new Random();
            int rndnum = 0;
            List<int> numbers = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    rndnum = rnd.Next(1, playersCount + 1);
                } while (numbers.Contains(rndnum));
                numbers.Add(rndnum);
            }
            foreach (int number in numbers)
            {
                var player = await _unitOfWork.PassWords.GetById(number);
                PlayersList.Add(player);
            }
            
            return Ok(PlayersList);
        }
    }
}
