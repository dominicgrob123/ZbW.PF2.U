using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace MB13.SinglyLinkedListExample
{
    /// <summary>
    /// SinglyLinkedList
    /// </summary>
    public class SinglyLinkedList
    {
        private Node start;
        private Node end;
        public int Count { get; private set; }
        public void Add(object data)
        {
            var newItem = new Node() { Data = data, Link = null }; 
            if(start == null) 
             {
                   start = newItem;
                   end = newItem;
               }
            else
               {
                   end.Link = newItem;

                   end = newItem;
               }
            Count++;
            }
        public bool Contains(object data)
        {
            return Find(data) != null;
        }
        private Node Find(object data)
        {
            var node = start;
            while (node != null) 
            {
                if (node.Data.Equals(data)) 
                {
                    return node;
                }
                node = node.Link;
            }
            return null;
        }
        public bool Remove(object data) 
        {
            var node = Find(data);

            if (node == null)
            {
                return false;
            }
            var previousNode = FindPrivious(data);
            if (previousNode != null) 
            {
                previousNode.Link = node.Link;
                if (node == end)
                {
                    end = previousNode;
                }
            }
            else 
            {
                start = node.Link;
                if (start == null) 
                {
                    end = null;
                }
            }
            Count--;
            return true;

        }
        private Node FindPrivious(object data)
        {
            var node = start;
            while (node != null)
            {
                if (node.Link.Equals(data))
                {
                    return node;
                }
                node = node.Link;
            }
            return null;
        }
        public object FindByIndex(int index)
        {
            var node = start;
            int i = 0;
            while (node != null)
            {
                if (i == index)
                {
                    return node;
                }
                i++;
                node = node.Link;
            }
            return null;
        }

    } 
}

