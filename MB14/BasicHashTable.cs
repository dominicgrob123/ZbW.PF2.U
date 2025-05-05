using System.Collections;
using System.Text;

namespace MB14
{

  public class BasicHashTable<T> : IEnumerable<Element<T>>
  {
    private Element<T>[] values;

    private int defaultCapacity = 10;

    private double maxFillFactor = 0.8;

    public double FillFactor { get; private set; }


    public int Collisions { get; private set; }

    public int Capacity { get; private set; }

    public int Count { get; private set; }

    public BasicHashTable() 
    {
      int length = CalcPrimeLength(defaultCapacity);
      values = new Element<T>[length];
      Capacity = length;
    }

    public void Add(string key, T value)
    {
      if (ContainsKey(key))
      {
        throw new ArgumentException("Hashtable already contains this key!");
      }

      Grow();

      AddItem(values, key, value);
    }

    public bool Remove(string key)
    {
      var index = GetIndex(values, key);

      while(values[index] != null)
      {
        if(values[index].Key.Equals(key) && !values[index].IsDeleted)
        {
          values[index].IsDeleted = true;
          Count--;
          return true;
        }

        ++index;
        index %= values.Length;
      }

      return false;
    }


    public void Clear()
    {
      values = new Element<T>[defaultCapacity];
      Count = 0;
      FillFactor = 0;
      Capacity = defaultCapacity;
      Collisions = 0;
    }

    private void Grow()
    {
      int itemCountDefault = 0;

      Array.ForEach(values, a => {
        if (a == null)
        { 
          itemCountDefault++;
        }
      });

      FillFactor = (values.Length - itemCountDefault) / (double) values.Length;

      if(FillFactor >= maxFillFactor)
      {
        int length = CalcPrimeLength(values.Length * 2);
        Element<T>[] newValues = new Element<T>[length];

        Count = 0;
        foreach(Element<T> item in values)
        {
          if(item != null)
          { 
            AddItem(newValues, item);
          }
        }

        values = newValues;
        Capacity = newValues.Length;
      }
    }

    public Element<T> this[string key]
    {
      get
      {
        var index = GetIndex(values, key);

        if(index < 0 || index >= values.Length)
        {
          throw new IndexOutOfRangeException();
        }

        while (values[index] != null)
        {
          if(values[index].Key.Equals(key) && !values[index].IsDeleted)
          {
            return values[index];
          }

          ++index;
          index %= values.Length;
        }

        throw new ArgumentException("Key not found");
      }
    }

    private int GetIndex(Element<T>[] values, string key)
    {
      var index = Math.Abs(key.GetHashCode()) % values.Length;
      return index;
    }

    public bool ContainsKey(string key)
    {
      var index = GetIndex(values, key);

      while(values[index] != null && !values[index].IsDeleted)
      {
        if(values[index].Key.Equals(key))
        {
          return true;
        }

        ++index;
        index = index % values.Length;
      }

      return false;
    }

    private void AddItem(Element<T>[] values, string key, T item)
    {
      var index = GetIndex(values, key);

      // linear probing
      while (values[index] != null && !values[index].IsDeleted)
      {
        ++index;
        index %= values.Length;
        Collisions++;
      }

      values[index] = new Element<T>(key, item);
      Count++;
    }

    private void AddItem(Element<T>[] values, Element<T> element)
    {
      AddItem(values, element.Key, element.Value);
    }

    private int CalcPrimeLength(int length)
    {
      while (!IsPrime(++length))
        ;

      return length;
    }

    private bool IsPrime(int number)
    {
      for (int i = 2; i <= number / 2; i++)
        if (number % i == 0)
          return false;

      return true;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      for (var i = 0; i < values.Length; i++)
      {
        sb.AppendLine($"| {(values[i] != null ? values[i].Key : "null")} - {(values[i] != null ? values[i].Value : "null")} - deleted:  {(values[i] != null ? values[i].IsDeleted ? "yes" : "no" : "N/A")} |");
      }
      return sb.ToString();
    }

    public IEnumerator<Element<T>> GetEnumerator()
    {
      for(var i = 0; i < Capacity; i++)
      {
        if (values[i] != null && !values[i].IsDeleted)
        {
          yield return values[i];
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
