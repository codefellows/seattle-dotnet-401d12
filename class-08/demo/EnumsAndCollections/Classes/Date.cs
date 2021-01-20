using System;
using System.Collections.Generic;
using System.Text;

namespace EnumsAndCollections.Classes
{
  class Date
  {
    public int DayOfMonth { get; set; }
    public DayOfWeek Day { get; set; }
  }

  enum DayOfWeek
  {
    Sunday, // 0
    Monday, // 1
    Tuesday, // ...
    Wednesday,
    Thursday,
    Friday,
    Saturday
  }

  enum Months : byte
  {
    Jan,
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Nov,
    Dec
  }
}
