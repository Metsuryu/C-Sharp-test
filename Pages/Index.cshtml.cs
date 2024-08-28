using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StringManipulator.Services;

namespace StringManipulator.Pages
{
    public class LargestWordModel : PageModel
    {
        private readonly IStringManipulator _stringManipulator;

        public LargestWordModel(IStringManipulator stringManipulator)
        {
            _stringManipulator = stringManipulator;
        }

        [BindProperty]
        public required string InputString { get; set; }

        public string? LargestWord { get; private set; }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(InputString))
            {
                LargestWord = _stringManipulator.Manipulate(InputString);
            }
        }
    }
}
