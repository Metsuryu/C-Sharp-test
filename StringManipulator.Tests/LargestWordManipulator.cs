using Xunit;
using StringManipulator.Services;

namespace StringManipulator.Tests
{
    public class LargestWordManipulatorTests
    {
        private readonly LargestWordManipulator _manipulator;

        public LargestWordManipulatorTests()
        {
            _manipulator = new LargestWordManipulator();
        }

        [Fact]
        public void Manipulate_ReturnsLargestWord()
        {
            var input = "This is a long sentence without punctuation";
            var result = _manipulator.Manipulate(input);
            Assert.Equal("punctuation", result);
        }

        [Fact]
        public void Manipulate_IgnoresPunctuation()
        {
            var input = "Hello, world! This is a test.";
            var result = _manipulator.Manipulate(input);
            Assert.Equal("Hello", result);
        }

        [Fact]
        public void Manipulate_ReturnsFirstWordWhenMultipleSameLength()
        {
            var input = "The cat dog cat";
            var result = _manipulator.Manipulate(input);
            Assert.Equal("The", result);
        }

        [Fact]
        public void Manipulate_IgnoresPunctuationWithinWord()
        {
            var input = "Long word with p,unct.uat!ion1 and without punctuation2.";
            var result = _manipulator.Manipulate(input);
            Assert.Equal("punctuation1", result);
        }

        [Fact]
        public void Manipulate_SpecialChars()
        {
            var input = "some@email.com #testing some chars すとりんぐ ";
            var result = _manipulator.Manipulate(input);
            Assert.Equal("someemailcom", result);
        }

        [Fact]
        public void Manipulate_ThrowsExceptionForEmptyInput()
        {
            Assert.Throws<ArgumentException>(() => _manipulator.Manipulate(""));
        }
    }
}