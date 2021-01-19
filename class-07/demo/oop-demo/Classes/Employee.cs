using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Classes
{
  // : means "Extends"
  // What is "Employee"
  //   ... a sub-class of Person
  //   ... a concrete
  abstract class Employee : Person
  {
    public override string Name { get; set; }
    public override int Age { get; set; }
    public abstract int Salary { get; set; }
  }
}
