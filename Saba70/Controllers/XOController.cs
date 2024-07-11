using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Saba70.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XOController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public XOController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult> GetPlayers()
        {
            var colPlayers = await _unitOfWork.XOImagesColmns.GetAll();
            var rowPlayers = await _unitOfWork.XOImagesRows.GetAll();

            if (colPlayers == null || rowPlayers == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }

            var colplayersCount = colPlayers.Count();
            var rowplayersCount = rowPlayers.Count();

            if (colplayersCount < 3 || rowplayersCount < 3)
            {
                return NotFound("Not enough players.");
            }

            Random rnd = new Random();

            var rowList = new List<XOImagesRows>();
            List<int> rowNumbers = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                int rowRndnum;
                do
                {
                    rowRndnum = rnd.Next(1, rowplayersCount + 1);
                } while (rowNumbers.Contains(rowRndnum));
                rowNumbers.Add(rowRndnum);

                var row = await _unitOfWork.XOImagesRows.GetById(rowRndnum);
                if (row == null)
                {
                    return NotFound($"Row player with ID {rowRndnum} not found.");
                }
                rowList.Add(row);
            }

            var colList = new List<XOImagesColmns>();
            List<int> colNumbers = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                int colRndnum;
                do
                {
                    colRndnum = rnd.Next(1, colplayersCount + 1);
                } while (colNumbers.Contains(colRndnum));
                colNumbers.Add(colRndnum);

                var col = await _unitOfWork.XOImagesColmns.GetById(colRndnum);
                if (col == null)
                {
                    return NotFound($"Column player with ID {colRndnum} not found.");
                }
                colList.Add(col);
            }

            var imgs = new List<string>();

            foreach (var row in rowList)
            {
                if (row.ImgSrc == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Row player image source is null.");
                }
                imgs.Add(row.ImgSrc.ToString());
            }

            foreach (var col in colList)
            {
                if (col.ImgSrc == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Column player image source is null.");
                }
                imgs.Add(col.ImgSrc.ToString());
            }

            return Ok(imgs);
        }

    }
}
