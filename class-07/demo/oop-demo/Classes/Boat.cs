using oop_demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Classes
{
  class Boat : IDriveable
  {
    public string BoatName { get; set; }

    public void Accellerate()
    {
      Console.WriteLine("Throttle Down");
    }

    public void Decellerate()
    {
      Console.WriteLine("Hands off the lever!");
    }

    public void Start()
    {
      Console.WriteLine("Turn the key");
    }

    public void Steer()
    {

      Console.WriteLine("Turn the Wheel");
    }

    public void Stop()
    {
      Console.WriteLine("We're in water, no stopping...");
    }
  }
}
