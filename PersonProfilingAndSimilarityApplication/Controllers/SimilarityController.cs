using BusinessLayer.Services.Helpers;
using BusinessLayer.Services.Helpers.Abstarct;
using CoreLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace PersonProfilingAndSimilarityApplication.Controllers
{
    [Route("api/similarity")]
    [ApiController]
    public class SimilarityController : ControllerBase
    {
        private readonly ISimilarityAlgorithm _similarityAlgorithm;

        public SimilarityController(ISimilarityAlgorithm similarityAlgorithm)
        {
            _similarityAlgorithm = similarityAlgorithm;
        }

        [HttpPost("jarowinkler")]
        public IActionResult CalculateJaroWinkler(JaroWinklerRequestDto dto)
        {
            var similarity = SimilarityRatioCalculationHelper.CalculateSimilarity(dto.ProfiledData, dto.UnprofiledData, new JaroWinklerAdapter());

            return Ok(similarity.ToString("F4"));
        }
    }
}
