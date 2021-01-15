using System;
using Xunit;

using static LinkedLists.Program;

namespace CodeChallengesTests
{
  public class LinkedListTests
  {
    [Fact]
    public void Test1()
    {
      bool works = LinkListActivity();
      Assert.True(works);
    }
  }
}
