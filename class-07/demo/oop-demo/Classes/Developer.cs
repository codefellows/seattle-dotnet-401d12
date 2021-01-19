using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Classes
{
  class Developer : Employee
  {
    public override int Salary { get; set; }

    private decimal Bonus { get; set; }

    public Developer()
    {
      Salary = 125000;
      Bonus = .10m;
    }

    public decimal YearEnd()
    {
      return (Salary * Bonus) + Salary;
    }
  }
}
