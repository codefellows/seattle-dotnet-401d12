using oop_demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Classes
{
  class DeliveryPerson : Person, IDrive
  {
    public override string Name { get; set; }
    public override int Age { get; set; }
    public string StateLicense { get; set; }

    public string AdjustSettings()
    {
      return "My mirrors are good, and the seat is right.";
    }

    public string Deliver(IDriveable vehicle)
    {
      vehicle.Start();
      vehicle.Accellerate();
      vehicle.Steer();
      vehicle.Decellerate();
      vehicle.Stop();
      return "Package was delivered";
    }
  }
}
