using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  public class Node
  {
    public int Value { get; set; }
    public Node Next { get; set; }

    /// <summary>
    /// Constructor for a node
    /// Usage: Node node = new Node(7);
    /// </summary>
    /// <param name="value"></param>
    public Node(int value)
    {
      Value = value;
    }
  }
}
