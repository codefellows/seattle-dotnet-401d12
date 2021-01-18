using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Parties
{
  abstract class Birthday : Party
  {

    public abstract int Age { get; set; }
    public abstract string Cake { get; set; }
    public abstract bool IsSurprise { get; set; }
    public string SongName { get; set; } = "Happy Birthday";
    public string[] Presents { get; set; }
    public string[] Decorations { get; set; }
    public override bool Alcohol { get; set; }
    public override string Venue { get; set; }
    public override DateTime Date { get; set; }

    public void OpenPresents()
    {

    }
    public void SingingTheSong()
    {

    }

    public override void Setup()
    {
      Console.WriteLine("Bake the cake");
    }

    public override void Teardown()
    {
      Console.WriteLine("Clean the mess");
    }
  }

  class KidsParty : Birthday
  {
    public string Theme { get; set; }
    public string[] Activities { get; set; }
    public override bool Alcohol { get => false; set => base.Alcohol = value; }
    public override int Age { get; set; }
    public override string Cake { get; set; }
    public override bool IsSurprise { get; set; }

    public override void Setup()
    {
      base.Setup();
      Console.WriteLine("Put up decorations");
    }


  }

  public class BirthdayPartyTests
  {
    [Fact]
    public void Birthday_Is_A_Party()
    {
      Birthday johnsDay = new KidsParty();
      johnsDay.Setup();
      Console.WriteLine("Hi");
      Assert.False(johnsDay.Alcohol);
    }

  }
}
