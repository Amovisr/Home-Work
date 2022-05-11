using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementNode
{
    public class Node
    {
        public int Data { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int data)
        {
            Data = data;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}