using System;
using System.Linq;

namespace StringManipulator.Services
{
  public class LargestWordManipulator : IStringManipulator
  {
    public string Manipulate(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
      {
        throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
      }

      var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(word => new string(word.Where(c => !char.IsPunctuation(c)).ToArray()));

      return words.OrderByDescending(w => w.Length).First();
    }
  }
}
