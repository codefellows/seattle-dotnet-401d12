using oop_demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Classes
{
  class Robot : IDrive, IDriveable
  {
    public string StateLicense { get; set; }

    public void Accellerate()
    {
      Console.WriteLine("Get out of my way!");
    }

    public string AdjustSettings()
    {
      return "Settings adjust to me, I'm a robot!";
    }

    public void Decellerate()
    {
      Console.WriteLine("I mean it, get out of my way");
    }

    public void Start()
    {
      Console.WriteLine("Robots never sleep, I'm already on");
    }

    public void Steer()
    {
      Console.WriteLine("Seriously, get out of the way!");
    }

    public void Stop()
    {
      Console.WriteLine("I told you ... I don't stop");
    }
  }
}
