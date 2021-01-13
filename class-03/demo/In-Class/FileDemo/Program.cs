using System;
using System.IO;

namespace FileDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      string path = "../../../data.txt";
      ReadRawFile(path);
      ReadFileText(path);
      ReadFileLines(path);

      OverwriteFile(path);
      ReadFileLines(path);
    }

    static public void ReadRawFile(string path)
    {
      byte[] bytes = File.ReadAllBytes(path);
      foreach (byte character in bytes)
      {
        Console.Write($"{character} ");
      }
    }

    static void ReadFileText(string path)
    {
      string textFromFile = File.ReadAllText(path);
      Console.WriteLine(textFromFile);
    }

    static void ReadFileLines(string path)
    {
      string[] lines = File.ReadAllLines(path);
      foreach (var line in lines)
      {
        Console.WriteLine(line);
      }
    }

    static void OverwriteFile(string path)
    {
      string words = "This is new\nStuff in the file\nAdded by John";
      string[] lines = new string[] { "line 1", "line 2" };

      File.WriteAllText(path, words);
    }
  }
}
