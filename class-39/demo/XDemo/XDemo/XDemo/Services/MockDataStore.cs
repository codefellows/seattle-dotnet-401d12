﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDemo.Models;

namespace XDemo.Services
{
  public class MockDataStore : IDataStore<Item>
  {
    readonly List<Item> items;


    public async Task<bool> AddItemAsync(Item item)
    {
      items.Add(item);

      return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(Item item)
    {
      var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
      items.Remove(oldItem);
      items.Add(item);

      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
      var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
      items.Remove(oldItem);

      return await Task.FromResult(true);
    }

    public async Task<Item> GetItemAsync(int id)
    {
      return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
    }

    public async Task<List<Item>> GetItemsAsync(bool forceRefresh = false)
    {
      return await Task.FromResult(items);
    }
  }
}