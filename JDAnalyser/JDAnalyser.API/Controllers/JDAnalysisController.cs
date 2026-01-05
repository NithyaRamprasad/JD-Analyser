using JDAnalyser.Application.Services.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace JDAnalyser.API.Controllers
{
    public class JDAnalysisController(JDAnalysisService service) : Controller
    {
        private readonly JDAnalysisService _service = service;
        [HttpGet("Get")]
        public async Task<ActionResult> Get(int userId) 
        {
            var result = await _service.GetJobDescriptionSummaryList(userId);
            return Ok(result);
        }
    }
}
