using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemo.Models
{
  public class PostVm
  {
    public Blog blog { get; set; }
    public Person author { get; set; }
  }
}
