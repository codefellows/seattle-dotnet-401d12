using System;

namespace DataStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      LinkedList myList = new LinkedList(5);
      myList.Insert(3);
      myList.Insert(6);
      myList.Insert(9);
      myList.Insert(12);
      myList.Insert(18);
      myList.Insert(22);

      myList.Print();
      myList.PrintR(myList.Head);
    }
  }
}
