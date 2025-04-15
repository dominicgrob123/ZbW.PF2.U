using MB13.SinglyLinkedListExample;
using System.Collections.Generic;
using System.Diagnostics;

namespace MB13Test.SinglyLinkedListExample
{
  [TestClass]
  public sealed class SinglyLinkedListTest
  {
    [TestMethod]
    public void ListCreate_Empty()
    {
      // arrange
      var list = new SinglyLinkedList();

      // assert
      Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void ListCreate_One_Element()
    {
      // arrange
      var startNode = new Node();
      startNode.Data = "zero";
      var list = new SinglyLinkedList();
      list.Add(startNode);
      // act
      var count = list.Count;

      // assert
      Assert.AreEqual(1, count);
      Print(list);
    }

    [TestMethod]
    public void ListCreate_Three_Elements()
    {
      // arrange
      var list = CreateList(3);

      // act
      var count = list.Count;

      // assert
      Assert.AreEqual(3, count);
      Print(list);
    }

    [TestMethod]
    public void ListContains_True()
    {
      // arrange
      var list = CreateList(3);

      // act
      var contains = list.Contains("3");

      // assert
      Assert.IsTrue(contains);
    }

    [TestMethod]
    public void ListRemove_Item_Start()
    {
      // arrange
      var list = CreateList(5);

      // act
      list.Remove("1");
      var contains = list.Contains("1");

      // assert
      Assert.IsFalse(contains);
      Assert.AreEqual(4, list.Count);
      Print(list);
    }

    [TestMethod]
    public void ListRemove_Item_Middle()
    {
      // arrange
      var list = CreateList(5);

      // act
      list.Remove("3");
      var contains = list.Contains("3");

      // assert
      Assert.IsFalse(contains);
      Assert.AreEqual(list.Count, 4);
      Print(list);

    }

    [TestMethod]
    public void ListRemove_Item_End()
    {
      // arrange
      var list = CreateList(5);

      // act
      list.Remove("5");
      var contains = list.Contains("5");


      // assert
      Assert.IsFalse(contains);
      Assert.AreEqual(list.Count, 4);
      Print(list);

    }

    [TestMethod]
    public void List_UseIndexer_ValueChanged()
    {
      // arrange
      var list = CreateList(10);
      var data = "eight";

      // act
      list[8] = data;
      var found = list.Contains(data);

      // assert
      Assert.IsTrue(found);
      Assert.IsTrue(list[8].Equals(data));
      Print(list);
    }

    private SinglyLinkedList CreateList(int count)
    {
      var list = new SinglyLinkedList();
      int data = 1;
      for (int i = 0; i < count; i++)
      {
        list.Add($"{data++}");
      }
      return list;
    }

    private void Print(SinglyLinkedList list)
    {
      Debug.WriteLine(list.ToString());
      Debug.WriteLine($"Count = {list.Count}");
    }
  }
}
