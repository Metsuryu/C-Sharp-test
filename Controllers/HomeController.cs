using Microsoft.AspNetCore.Mvc;
using StringManipulator.Services;

namespace StringManipulator.Controllers
{
  public class HomeController : Controller
  {
    private readonly IStringManipulator _stringManipulator;

    public HomeController(IStringManipulator stringManipulator)
    {
      _stringManipulator = stringManipulator;
    }

    [HttpPost]
    public IActionResult LargestWord(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        return View("Error", "Input cannot be null or empty.");
      }

      var result = _stringManipulator.Manipulate(input);

      return View("Result", result);
    }
  }
}
