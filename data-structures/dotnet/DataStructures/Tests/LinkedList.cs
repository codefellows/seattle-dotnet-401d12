using System;
using Xunit;

using DataStructures;

namespace DataStructureTests
{
  public class LinkListTests
  {
    [Fact]
    public void Linked_List_Created_With_A_Value_Has_Correct_Head()
    {
      int value = 2;

      LinkedList testList = new LinkedList(value);

      Assert.Equal(testList.Head.Value, value);

    }

    [Fact]
    public void After_Insert_New_Node_Is_Head()
    {
      LinkedList testList = new LinkedList(1);
      // H(2) -> (1)
      testList.Insert(2);

      Assert.Equal(2, testList.Head.Value);
    }

    [Fact]
    public void After_Insert_New_Head_Next_is_Old_Head()
    {
      // H(1)
      LinkedList testList = new LinkedList(1);
      Node oldHead = testList.Head;

      // H(2) -> (1)
      testList.Insert(2);

      Assert.Equal(oldHead, testList.Head.Next);

    }
  }
}
