﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB13.Loesung.SinglyLinkedListExample
{
    public class Node
    {
    public object Data { get; set; }
    public Node Link { get; set; }

    public override string ToString()
    {
      return Data.ToString();
    }

  }
}
