using System;
using System.Collections.Generic;
using System.Text;

namespace oop_demo.Interfaces
{
  interface IDrive
  {
    string StateLicense { get; set; }

    /// <summary>
    /// Get ready to drive (mirrors, seat, etc)
    /// </summary>
    /// <returns></returns>
    string AdjustSettings();
  }

}
