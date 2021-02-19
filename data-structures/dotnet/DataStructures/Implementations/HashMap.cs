using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  class HashMap
  {

    // Buckets == a pre determined (size) array "Map"
    // The map is an array of linked lists of type key/value pair
    // So ... we always go to Map[7] or whatever to get the values
    private LinkedList<KeyValuePair<string, string>>[] Map { get; set; }

    public HashMap(int size)
    {
      Map = new LinkedList<KeyValuePair<string, string>>[size];
    }

    private int Hash(string key)
    {
      int hashValue = 0;

      char[] letters = key.ToCharArray();
      for (int i = 0; i < letters.Length; i++)
      {
        hashValue += letters[i];
      }

      hashValue = (hashValue * 599) % Map.Length;

      return hashValue;

    }

    // myHashMap.Set('zach', 22);
    public void Set(string key, string value)
    {

      int hashKey = Hash(key);

      if (Map[hashKey] == null)
      {
        Map[hashKey] = new LinkedList<KeyValuePair<string, string>>();
      }

      KeyValuePair<string, string> entry = new KeyValuePair<string, string>(key, value); // {zach:22}

      Map[hashKey].Insert(entry);

    }

    // myHashMap.Get('zach'); // returns 22
    public string Get(string key)
    {
      // What bucket is the key in?
      // Hash(key) will give us an index of the map

      // At that Map[index], traverse  the linked list
      // (if it's there)

      // Examine the nodes one by one and if the key of that node matches the key we'er looking for
      // return the value
      return "";
    }

    // myHashMap.Has('zach'); // returns true
    public bool Has(string key)
    {

      // What bucket is the key in?
      // Hash(key) will give us an index of the map

      // At that Map[index], traverse  the linked list
      // (if it's there)

      // Examine the nodes one by one and if the key of that node matches the key we'er looking for
      // return true/false if we found it

      return false;
    }

    public void Remove(string key)
    {
    }

    public void Print()
    {
      for (int i = 0; i < Map.Length; i++)
      {
        if (Map[i] == null)
        {
          Console.WriteLine($"Bucket {i}: EMPTY");
        }
        else
        {
          Console.Write($"Bucket {i}: ");

          Node<KeyValuePair<string, string>> current = Map[i].Head;
          while (current != null)
          {
            Console.Write($"[{current.Value.Key} : {current.Value.Value}] => ");
            current = current.Next;
          }

          Console.WriteLine();
        }
      }
    }

  }
}
