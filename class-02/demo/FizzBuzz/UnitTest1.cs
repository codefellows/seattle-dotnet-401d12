using System;
using Xunit;
using FizzBuzz;

namespace FizzBuzzTests
{
  public class Tests
  {
    [Fact]
    public void ReturnsFizzForThree()
    {

      // Assembly -- Set things up (create an array, etc)
      int numToTest = 3;

      // Act -- run our actual code
      string result = Program.Convert(numToTest);

      // Assertion(s) -- Did it work?
      Assert.Equal("Fizz", result);


    }

    [Fact]
    public void ReturnsBuzzForFive()
    {
      int numToTest = 5;
      string result = Program.Convert(numToTest);
      Assert.Equal("Buzz", result);
    }

    [Fact]
    public void ReturnsFizzBuzzForFifteen()
    {
      int numToTest = 15;
      string result = Program.Convert(numToTest);
      Assert.Equal("FizzBuzz", result);
    }

    [Fact]
    public void ReturnsValueIfOne()
    {
      int numToTest = 1;
      string result = Program.Convert(numToTest);
      string expected = numToTest.ToString();
      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    [InlineData(7, "7")]
    [InlineData(64, "64")]
    public void ReturnsValueIfNeither(int numToTest, string expected)
    {
      string actual = Program.Convert(numToTest);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(6, "Fizz")]
    [InlineData(9, "Fizz")]
    [InlineData(12, "Fizz")]
    [InlineData(18, "Fizz")]
    public void ReturnsFizzForMultiplesOfThree(int numToTest, string expected)
    {
      string actual = Program.Convert(numToTest);
      Assert.Equal(expected, actual);
    }
  }
}
