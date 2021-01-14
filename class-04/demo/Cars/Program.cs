using System;


/*
 * OLD SCHOOL, JS CONSTRUCTOR
 * function Car( make, color, foo, bar, baz, bing, icecream) {
 *  this.Make = make;
 *  this.color = color;
 * }
 * 
 * var johnsFirstCar = new Car('Celica', 'Shit Brown');
 * johnsFirstCar.Year = 1976;
 * 
 */

namespace Cars
{
  class Program
  {
    static void Main(string[] args)
    {
      Car johnsFirstCar = new Car();
      johnsFirstCar.Color = "Yello";
      johnsFirstCar.Make = "Toyota Celica";
      Console.WriteLine("John Drives a {0} that is {1}", johnsFirstCar.Make, johnsFirstCar.Color);

      Car johnsSecondCar = new Car("VW Scirocco", "Black");
      Console.WriteLine("John Then Drove a {0} that is {1}", johnsSecondCar.Make, johnsSecondCar.Color);

      Car johnsThirdCar = new Car()
      {
        Make = "Toyota Tundra",
        Color = "Red"
      };
      Console.WriteLine("John Then Drove a {0} that is {1}", johnsThirdCar.Make, johnsThirdCar.Color);

      Console.WriteLine($"Engine On? {johnsThirdCar.EngineRunning.ToString()}, Current Speed: {johnsThirdCar.Speed.ToString()}");
      johnsThirdCar.Start();
      Console.WriteLine($"Engine On? {johnsThirdCar.EngineRunning.ToString()}, Current Speed: {johnsThirdCar.Speed.ToString()}");
      johnsThirdCar.Drive(50);
      Console.WriteLine($"Engine On? {johnsThirdCar.EngineRunning.ToString()}, Current Speed: {johnsThirdCar.Speed.ToString()}");
    }
  }
}
