namespace MB14Test
{
  using MB14;
  using System.Diagnostics;


  [TestClass]
  public class BasicHashTableTest
  {
    [TestMethod]
    public void HashTable_Create_Empty()
    {
      // arrange
      var hashTable = new BasicHashTable<int>();

      // act

      // assert
      Assert.AreEqual(0, hashTable.Count);
    }

    [TestMethod]
    public void HashTable_Add_HundredElements()
    {
      // arrange
      var hashTable = CreateHashTable<long>(100);

      // act
      var nineteenNinth = hashTable["99_key"];

      int val = 0;
      foreach (var elem in hashTable)
      {
        var key = $"{val}_key";
        // assert
        Assert.AreEqual(val++, hashTable[key].Value);
      }

      Print(hashTable);
    }

    [TestMethod]
    public void HashTable_Remove_ThreeElements()
    {
      // arrange
      var hashTable = CreateHashTable<ulong>(10);

      // act
      Debug.WriteLine("before remove:");
      Print(hashTable);
      var result = hashTable.Remove("3_key");

      result = hashTable.Remove("5_key");
      result = hashTable.Remove("8_key");

      // assert
      Assert.IsTrue(result);
      Assert.IsFalse(hashTable.ContainsKey("3_key"));
      Debug.WriteLine("after remove:");
      Print(hashTable);
    }

    [TestMethod]
    public void HashTable_Clear_Ok()
    {
      // arrange
      var hashTable = CreateHashTable<int>(50);

      // act
      Debug.WriteLine("before clear:");
      Print(hashTable);
      hashTable.Clear();
      Debug.WriteLine("");
      Debug.WriteLine("after clear:");
      Print(hashTable);

      // assert
      Assert.AreEqual(0, hashTable.Count);
      Assert.AreEqual(10, hashTable.Capacity);

    }


    [TestMethod]
    public void HashTable_Add_TwelveItems()
    {
      // arrange
      var hashTable = new BasicHashTable<long>();

      // act
      hashTable.Add("one", 1);
      hashTable.Add("two", 2);
      hashTable.Add("three", 3);
      hashTable.Add("four", 4);
      hashTable.Add("five", 5);
      hashTable.Add("six", 6);
      hashTable.Add("seven", 7);
      hashTable.Add("eight", 8);
      hashTable.Add("nine", 9);
      hashTable.Add("ten", 10);
      hashTable.Add("eleven", 11);
      hashTable.Add("twelve", 12);

      var first = hashTable["one"];
      var second = hashTable["two"];
      var third = hashTable["three"];
      var fourth = hashTable["four"];
      var fifth = hashTable["five"];
      var sixth = hashTable["six"];
      var seventh = hashTable["seven"];
      var eighth = hashTable["eight"];
      var nineth = hashTable["nine"];
      var tenth = hashTable["ten"];
      var eleventh = hashTable["eleven"];
      var twelvth = hashTable["twelve"];

      Assert.AreEqual(1, first.Value);
      Assert.AreEqual(2, second.Value);
      Assert.AreEqual(3, third.Value);
      Assert.AreEqual(4, fourth.Value);
      Assert.AreEqual(5, fifth.Value);
      Assert.AreEqual(6, sixth.Value);
      Assert.AreEqual(7, seventh.Value);
      Assert.AreEqual(8, eighth.Value);
      Assert.AreEqual(9, nineth.Value);
      Assert.AreEqual(10, tenth.Value);
      Assert.AreEqual(11, eleventh.Value);
      Assert.AreEqual(12, twelvth.Value); 

      Print<long>(hashTable);

      // assert
      Assert.AreEqual("twelve", twelvth.Key);
      Assert.AreEqual(12, hashTable.Count);
      Assert.AreEqual(23, hashTable.Capacity);
    }

    private void Print<T>(BasicHashTable<T> hashtable)
    {
      Debug.WriteLine(hashtable.ToString());
      Debug.WriteLine($"Count = {hashtable.Count}");
      Debug.WriteLine($"Capacity = {hashtable.Capacity}");
      Debug.WriteLine($"Collisions = {hashtable.Collisions}");
      Debug.WriteLine($"FillFactor = {(int)(Math.Round(hashtable.FillFactor, 2) * 100)} %");
    }

    private BasicHashTable<T> CreateHashTable<T>(int count)
    {
      var hashTable = new BasicHashTable<T>();
      int data = 0;

      for (var i = 0; i < count; i++)
      {
        T item = (T)Convert.ChangeType(data++, typeof(T));
        hashTable.Add($"{i}_key", item);
      }

      return hashTable;
    }
  }
}
