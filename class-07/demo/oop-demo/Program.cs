using System;

using oop_demo.Classes;
using oop_demo.Interfaces;

namespace oop_demo
{
  class Program
  {
    static void Main(string[] args)
    {
      Developer john = new Developer();
      Console.WriteLine($"John Made ${john.YearEnd()} with bounus added in 2020");

      DeliveryPerson allie = new DeliveryPerson() { Name = "Allie", StateLicense = "WA" };
      ValidateDriver(allie);

      Robot wall_e = new Robot() { StateLicense = "PLUTO" };
      ValidateDriver(wall_e);

      Boat titanic = new Boat() { BoatName = "Titanic" };

      allie.Deliver(wall_e);
    }

    public static void ValidateDriver(IDrive driver)
    {
      Console.WriteLine($"My License is from {driver.StateLicense}");
      Console.WriteLine($"I adjust the vehicle by: {driver.AdjustSettings()}");
    }
  }
}
