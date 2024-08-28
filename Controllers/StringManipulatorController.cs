using Microsoft.AspNetCore.Mvc;
using StringManipulator.Services;

namespace StringManipulator.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StringManipulatorController : ControllerBase
  {
    private readonly IStringManipulator _stringManipulator;

    public StringManipulatorController(IStringManipulator stringManipulator)
    {
      _stringManipulator = stringManipulator;
    }

    public class InputModel
    {
      public required string Input { get; set; }
    }

    [HttpPost("largest-word")]
    public IActionResult GetLargestWord([FromBody] InputModel model)
    {
      if (string.IsNullOrEmpty(model?.Input))
      {
        return BadRequest("Input cannot be null or empty.");
      }

      var result = _stringManipulator.Manipulate(model.Input);

      return Ok(new { largestWord = result });
    }
  }
}
