using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XDemo.Models;
using XDemo.Services;

namespace XDemo.ViewModels
{
  public class HomeViewModel : INotifyPropertyChanged
  {

    public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

    public event PropertyChangedEventHandler PropertyChanged;


    //private Item item;
    //public Item Item
    //{
    //  get { return item; }
    //  set
    //  {
    //  }
    //}

    private string text = string.Empty;

    // SHORTCUT
    //public string Text
    //{
    //  get => text;
    //  set => SetProperty(ref text, value);
    //}

    public string Text
    {
      get { return text; }

      // i.e. Text="foobar"  C# does this: Text.set("foobar");
      set
      {
        if (text == value)
        {
          return;
        }
        text = value;
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Confirmation));
      }
    }

    public string Confirmation => $"You Typed: {Text}";

    public ObservableCollection<Item> Items { get; set; }

    public HomeViewModel()
    {
      Items = new ObservableCollection<Item>();
    }

    public async void Save()
    {
      Item newItem = new Item()
      {
        Id = 0,
        Text = Text,
      };

      await DataStore.AddItemAsync(newItem);
      await GetAllItems();

    }

    public async Task GetAllItems()
    {
      try
      {
        Items.Clear();
        var items = await DataStore.GetItemsAsync();
        foreach (var item in items)
        {
          Items.Add(item);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    void OnPropertyChanged(string text)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
    }

  }
}
