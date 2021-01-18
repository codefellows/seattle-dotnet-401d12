using System;
using Xunit;

namespace Parties
{

  public abstract class Party
  {

    public int NumberOfGuests { get; set; }
    public string[] Guests { get; set; }
    public string Music { get; set; }
    public abstract bool Alcohol { get; set; }
    public abstract string Venue { get; set; }
    public abstract DateTime Date { get; set; }

    public virtual void SendInvites()
    {
      Console.WriteLine("Do the planning");
    }

    public abstract void Setup();
    public abstract void Teardown();

  }

  public class PartyTests
  {

    [Fact]
    public static void Can_Make_A_Party()
    {
    }
  }

}
