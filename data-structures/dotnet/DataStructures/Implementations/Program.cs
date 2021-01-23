using System;
using System.Collections.Generic;

namespace DataStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      // LinkedListFun();
      StackFun();
    }

    static void LinkedListFun()
    {
      LinkedList<int> myNumbers = new LinkedList<int>(1);
      myNumbers.Insert(2);
      myNumbers.Insert(3);
      myNumbers.Insert(4);
      myNumbers.Insert(5);
      myNumbers.Insert(6);
      myNumbers.Insert(7);
      myNumbers.Insert(8);

      myNumbers.Print();
      myNumbers.PrintR(myNumbers.Head);

      LinkedList<string> myFamily = new LinkedList<string>();
      myFamily.Insert("John");
      myFamily.Insert("Cathy");
      myFamily.Insert("Zach");
      myFamily.Insert("Allie");
      myFamily.Print();
    }

    static void StackFun()
    {
      Stack<string> myFamily = new Stack<string>();
      myFamily.Push("John");
      myFamily.Push("Cathy");
      myFamily.Push("Zach");
      myFamily.Push("Allie");

      while (myFamily.Peek())
      {
        Node<string> person = myFamily.Pop();
        Console.WriteLine(person.Value);
      }

    }
  }
}
