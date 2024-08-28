1 - Shoes discount

What's the output of the following code? Why?

namespace Test
{
  class Program
  {
    class Product
    {
      public required string Name { get; set; } // Added "required" to fix compiler warning
      public int Price { get; set; }
      public override string ToString() { return $"{Name} {Price}"; }
    }

    static void ApplyDiscount(Product shoes)
    {
      shoes = new Product { Name = "discounted shoes", Price = shoes.Price / 2 };
    }

    static void Main()
    {
      var shoes = new Product { Name = "my shoes", Price = 100 };
      ApplyDiscount(shoes);
      Console.WriteLine(shoes);
    }
  }
}

The above code outputs "my shoes 100".
That is because the method "ApplyDiscount" takes as an argument "shoes" by value, and not by reference, so the value of the variable "shoes" declared in main is not modified by the method, because the method does not have a direct reference to that variable, but just to its value,
so when printing shoes, the "ToString" method of the class is called, because the objects has to be cast to a string, in order to be printed, which optputs the name and price, separated by a space.
To make it so the discount is applied, the object should be passed by reference, not by value, by modifying the type of the parameter in the method like this:
 ApplyDiscount(ref Product shoes)
and the parameter passed when calling the method like this
ApplyDiscount(ref shoes);
This will then output:
"my shoes 50".

---

2 - String manipulator

Using the C# language, have the program take the string parameter being passed and return the largest word in the string.
If there are two or more words that are the same length, return the first word from the string with that length.
Ignore punctuation and assume string will not be empty.

Expose the feature as Web API endpoint returning JSON and as MVC Action that returns HTML containing the result.
Keep the program open for future extension allowing different string manipulation algorithm (shortest word for example).

General rules
• Code runs all the test
• Code does not contain duplication
• Code is expressive
• Code is small
• Code adheres to SOLID principles
