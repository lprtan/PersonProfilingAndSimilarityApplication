using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using CoreLayer.Dtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PersonProfilingAndSimilarityApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualDataController : ControllerBase
    {
        private readonly IInvidualDataService _invidualDataService;

        public IndividualDataController(IInvidualDataService invidualDataService)
        {
            _invidualDataService = invidualDataService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndividualData(IndividualData individualData)
        {
            if (individualData == null)
            {
                return BadRequest("Individual data cannot be null.");
            }
            var result = await _invidualDataService.CreateIndividualDataAsync(individualData);
            if (result.StatusCode == 201)
            {
                return CreatedAtAction(nameof(CreateIndividualData), new { id = result.Data.Id }, result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndividualData()
        {
            ResponseDto<List<IndividualData>> result = await _invidualDataService.GetAllIndividualDataAsync();

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
