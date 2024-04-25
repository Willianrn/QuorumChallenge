using Microsoft.AspNetCore.Mvc;
using QuorumChallengeApi.Models;
using QuorumChallengeApi.Services;

namespace QuorumChallengeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LegislatorsController : ControllerBase
    {

        private readonly ILogger<LegislatorsController> _logger;

        public LegislatorsController(ILogger<LegislatorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LegislatorApiModel> GetLegislators()
        {
            LegislatorService legislatorService = new LegislatorService();
            return legislatorService.GetLegislators();
        }
    }
}
