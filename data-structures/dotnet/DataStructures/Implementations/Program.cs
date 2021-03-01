using System;
using System.Collections.Generic;

namespace DataStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      // LinkedListFun();
      // StackFun();
      // HashMapFun();
      GraphFun();
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

    static void HashMapFun()
    {
      HashMap ht = new HashMap(50);

      ht.Set("John", "Dad");
      ht.Set("Cathy", "Mom");
      ht.Set("Zach", "Son");
      ht.Set("Allie", "Daughter");
      ht.Set("Rosie", "Dog");
      ht.Set("Gerald", "Father In Law");
      ht.Set("Linda", "Mother In Law");
      ht.Set("Ameilia", "Student");
      ht.Set("JP", "Student");
      ht.Set("Alan", "Student");
      ht.Set("Mike", "Student");
      ht.Set("Jordan", "Student");
      ht.Set("Scott", "Student");
      ht.Set("David", "Student");
      ht.Set("Matthew", "Student");
      ht.Set("Krystian", "Expecting Mom!");

      ht.Print();
    }

    static void GraphFun()
    {
      Graph<string> graph = new Graph<string>();

      Vertex<string> a = graph.AddVertex("Washington");
      Vertex<string> b = graph.AddVertex("Montana");
      Vertex<string> c = graph.AddVertex("North Dakota");

      graph.AddDirectedEdge(a, b);
      graph.AddDirectedEdge(b, c);

      graph.Print();

    }
  }
}
