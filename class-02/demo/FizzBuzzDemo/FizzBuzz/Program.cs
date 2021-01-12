using System;

namespace FizzBuzz
{
  public class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Give Me a Number");
      string num = Console.ReadLine();

    }

    /// <summary>
    /// Return a string (Fizz/Buzz/FizzBuzz/Value) depending on the number sent
    /// </summary>
    /// <param name="v">Number to convert</param>
    /// <returns>
    /// If number % 3 -- Fizz
    /// If number % 5 -- Buzz
    /// If number % 3 & 5 -- FizzBuzz
    /// Otherwise the number
    /// </returns>
    public static string Convert(int v)
    {

      if (v % 15 == 0)
      {
        return "FizzBuzz";

      }

      if (v % 3 == 0)
      {
        return "Fizz";
      }

      if (v % 5 == 0)
      {
        return "Buzz";
      }

      return v.ToString();
    }
  }
}
