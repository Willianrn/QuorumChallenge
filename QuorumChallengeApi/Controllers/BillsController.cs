using Microsoft.AspNetCore.Mvc;
using QuorumChallengeApi.Models;
using QuorumChallengeApi.Services;

namespace QuorumChallengeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillsController : ControllerBase
    {

        private readonly ILogger<BillsController> _logger;

        public BillsController(ILogger<BillsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BillApiModel> GetBills()
        {
            BillService billService = new BillService();
            return billService.GetBills();
        }
    }
}
