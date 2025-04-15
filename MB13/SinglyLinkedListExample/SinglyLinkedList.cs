using System.Text;

namespace MB13.SinglyLinkedListExample
{
  /// <summary>
  /// SinglyLinkedList - Demo 15.04.2025
  /// </summary>
  public class SinglyLinkedList
  {

    public Node _start;
    public Node _end;

    public int Count { get; set; }

    public SinglyLinkedList()
    {
      _start = null;
      _end = null;
    }
  
    public void Add(object data)
    {
      var node = new Node() { Data = data, Link = null };

      if (_start == null)
      {
        _start = node;
        _end = node;
      }
      else
      {
        _end.Link = node;
        _end = node;
      }

      Count++;
    }

    public bool Contains(object data)
    {
     return Find(data) != null;
    }

    public bool Remove(object data)
    {
      var success = false;

      if(_start != null && _start.Data.Equals(data))
      {
          _start = _start.Link;
          success =  true;
      }
      else
      {
        var current = _start.Link;
        Node previous = _start;

        while (current != null)
        {
          if (current.Data.Equals(data))
          {
            previous.Link = current.Link;
            success = true;
            break;
          }

          previous = current;
          current = current.Link;
        }
      }

      if (success)
      {
        Count--;
      }

      return success;
    }

    public object Find(object data)
    {
      var current = _start;

      while (current != null)
      {
        if (current.Data.Equals(data))
        {
          return current.Data;
        }

        current = current.Link;
      }

      return null;

    }

    public object this[int index]
    {
      get
      {
        return FindByIndex(index)?.Data;
      }

      set
      {
        var node = FindByIndex(index);
        if (node != null)
        {
          node.Data = value; 
        }
      }
    }

    private Node FindByIndex(int index)
    {
      if(index <= 0 || index >= Count)
      {
        throw new ArgumentOutOfRangeException("index");
      }

      var current = _start;
      var idx = 0;

      while (current != null)
      {
        if (idx == index)
        {
          return current;
        }

        current = current.Link;
        idx++;
      }

      return null;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      var current = _start;

      while (current != null)
      {
        sb.AppendLine(current.Data.ToString());
        current = current.Link;
      }

      return sb.ToString();
    }
  }
}
