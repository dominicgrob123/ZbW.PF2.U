using System.Text;

namespace MB14.QueueExample
{
  public class QueueArray<T>
  {
    private T[] items;

    private int initialSize = 10;

    public int Count { get; private set; }

    public int Capacity { get; private set; }

    public QueueArray()
    {
      items = new T[initialSize];
      Capacity = initialSize;
    }

    public void Enqueue(T item)
    {
      Grow();

      items[Count] = item;

      Count++;
    }

    public object Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("No items in queue.");
      }

      return items[0]!;
    }

    public T Dequeue()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("No items in queue.");
      }

      T item  = items[0];

      Array.Copy(items, 1, items, 0, Count - 1);

      items[Count - 1] = default!;

      Count--;

      return item;
    }

    public void Clear()
    {
      items = new T[initialSize];
      Count = 0;
    }

    private void Grow()
    {
      if (items.Length >= Count + 1)
        return;

      int newLength = items.Length * 2;

      Array.Resize(ref items, newLength);
      Capacity = newLength;
    }

    public override string ToString()
    {
      if (Count == 0)
      {
        return "Queue is empty";
      }

      return GetBox(items);
    }

    private string GetBox(T[] i)
    {
      var maxLength = i.Where(a => a != null).Max(a => a.ToString().Length);
      var totalLength = maxLength + 4;
      var sb = new StringBuilder();
      var end = 0;

      Array.ForEach(i, a =>
      {
        sb.Append("+").Append('-', totalLength);
        if (end++ == i.Length - 1)
        {
          sb.Append("+");
        }
      });
      sb.AppendLine();

      foreach (var item in i)
      {

        int padding = totalLength - (item != null ? item.ToString().Length : 0);
        int padLeft = padding / 2;
        int padRight = padding - padLeft;
        sb.Append("|")
          .Append('\u0020', padLeft)
          .Append(item)
          .Append('\u0020', padRight);
      }
      sb.Append("|");
      sb.AppendLine();
      end = 0;

      Array.ForEach(i, a =>
      {
        sb.Append("+").Append('-', totalLength);
        if (end++ == i.Length - 1)
        {
          sb.Append("+");
        }
      });

      return sb.ToString();
    }
  }
}
