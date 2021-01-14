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
  class Car
  {
    // PROPS AND FIELDs
    private string color;

    public string Make { get; set; }
    public bool EngineRunning { get; set; }
    public int Speed { get; set; }

    public string Color
    {
      get { return color; }
      set
      {
        if (value == "red")
        {
          color = "Brown";
        }
        else
        {
          color = value;
        }
      }
    }

    // CONSTRUCTORS
    public Car()
    {
      Console.WriteLine("I am in the default constructor");
    }

    public Car(string make, string color)
    {
      Console.WriteLine("I am in the overloaded constructor");
      Make = make;
      Color = color;
    }

    // METHODS
    public void Start()
    {
      EngineRunning = true;
    }

    public void Drive(int mph)
    {
      if (EngineRunning) { Speed = mph; }
    }

  }
}
