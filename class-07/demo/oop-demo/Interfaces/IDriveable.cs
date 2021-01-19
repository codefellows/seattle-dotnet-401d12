using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Interfaces
{
  interface IDriveable
  {
    void Start();
    void Stop();
    void Accellerate();
    void Decellerate();
    void Steer();
  }
}
