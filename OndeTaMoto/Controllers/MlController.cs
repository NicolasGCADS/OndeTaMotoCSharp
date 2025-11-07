using Microsoft.AspNetCore.Mvc;
using OndeTaMotoTrainer;

namespace OndeTaMotoApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MlController : ControllerBase
{
    private readonly MlService _mlService;

    public MlController(MlService mlService)
    {
        _mlService = mlService;
    }

    public class PredictRequest
    {
        public float Kilometers { get; set; }
        public float AgeYears { get; set; }
    }

    [HttpPost("predict")]
    public IActionResult Predict([FromBody] PredictRequest req)
    {
        if (req == null) return BadRequest();

        var pred = _mlService.Predict(req.Kilometers, req.AgeYears);
        return Ok(new
        {
            NeedsService = pred.PredictedLabel,
            Probability = pred.Probability,
            Score = pred.Score
        });
    }
}