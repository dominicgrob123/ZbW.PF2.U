namespace MB14Test.Research
{
  using MB14.QueueExample;
  using System;
  using System.Diagnostics;
  using System.Linq;

  [TestClass]
  public class QueueArrayTest
  {
    [TestMethod]
    public void Enqueue_IncreasesCount()
    {
      // arrange
      var queue = new QueueArray<int>();

      // act
      queue.Enqueue(1);
      queue.Enqueue(2);

      // assert
      Assert.AreEqual(2, queue.Count);
      Print(queue);

    }

    [TestMethod]
    public void Dequeue_ReturnsCorrectItemAndDecreasesCount()
    {
      // arrange
      var queue = new QueueArray<string>();
      
      // act
      queue.Enqueue("a");
      queue.Enqueue("b");
      queue.Enqueue("c");
      queue.Enqueue("d");
      queue.Enqueue("e");
      queue.Enqueue("f");
      Print(queue);

      var first = queue.Dequeue();
      var second = queue.Dequeue();
      Print(queue);

      queue.Enqueue("g");

      // assert
      Assert.AreEqual("a", first);
      Assert.AreEqual("b", second);
      Assert.AreEqual("c", queue.Peek());
      Assert.AreEqual(5, queue.Count);
      Print(queue);

    }

    //[TestMethod]
    public void Dequeue_Ring_ReturnsCorrectItemAndDecreasesCount()
    {
      // arrange
      var queue = new QueueArray<string>();

      // act
      queue.Enqueue("a");
      queue.Enqueue("b");
      queue.Enqueue("c");
      queue.Enqueue("d");
      queue.Enqueue("e");
      queue.Enqueue("f");
      var first = queue.Dequeue();
      var second = queue.Dequeue();
      queue.Enqueue("g");

      // assert
      Assert.AreEqual("a", first);
      Assert.AreEqual("b", second);
      Assert.AreEqual("c", queue.Peek());
      Assert.AreEqual(4, queue.Count);
      Print(queue);

    }

    [TestMethod]
    public void Peek_ReturnsNextItemWithoutRemovingIt()
    {
      // arrange
      var queue = new QueueArray<int>();

      // act
      queue.Enqueue(10);
      queue.Enqueue(20);
      var peeked = queue.Peek();

      // assert
      Assert.AreEqual(10, peeked);
      Assert.AreEqual(2, queue.Count);
      Print(queue);

    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Peek_ReturnsDefault_WhenQueueIsEmpty()
    {
      // arrange
      var queue = new QueueArray<string>();

      // act
     var peeked =  queue.Peek();

      Assert.AreEqual(default, peeked);
      Print(queue);

    }

    [TestMethod]
    public void Clear_ResetsQueue()
    {
      // arrange
      var queue = new QueueArray<int>();
      
      // act
      queue.Enqueue(1);
      queue.Enqueue(2);
      Assert.AreEqual(2, queue.Count);

      queue.Clear();

      // assert
      Assert.AreEqual(0, queue.Count);
      Print(queue);

    }

    [TestMethod]
    public void Enqueue_GrowsArray_WhenCapacityExceeded()
    {
      var queue = new QueueArray<int>();
      for (int i = 0; i < 22; i++)
      {
        queue.Enqueue(i);
      }

      Assert.AreEqual(40, queue.Capacity);
      Print(queue);

    }

    [TestMethod]
    public void ToString_ReturnsFormattedString()
    {
      var queue = new QueueArray<int>();
      queue.Enqueue(1);
      queue.Enqueue(2);

      var result = queue.ToString();

      Assert.IsTrue(result.Length > 0);
      Print(queue);
    }

    private void Print<T>(QueueArray<T> queue)
    {
      Debug.WriteLine(queue.ToString());
      Debug.WriteLine($"Count = {queue.Count}");
      Debug.WriteLine($"Capacity = {queue.Capacity}");
    }
  }
}
