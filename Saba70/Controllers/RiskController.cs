using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Saba70.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public RiskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Risks.GetAll();

            var categoriesCount = categories.Count();
            if (categoriesCount < 4)
                return NotFound("no categories ");

            var categoriesList = new List<Risk>();

            Random rnd = new Random();
            int rndnum = 0;
            List<int> numbers = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    rndnum = rnd.Next(1, categoriesCount + 1);
                } while (numbers.Contains(rndnum));
                numbers.Add(rndnum);
            }
            foreach (int number in numbers)
            {
                var category = await _unitOfWork.Risks.GetById(number);
                categoriesList.Add(category);
            }

            return Ok(categoriesList);
        }
    }
}
