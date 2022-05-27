using System.Collections;

namespace _2_задание
{
    public class TreeNode 

    {

        public int Data { get; set; }
        public TreeNode Left { get;  set; }
        public TreeNode Right { get;  set; }
        public TreeNode Parrent { get; set; }
        public TreeNode(int data)
        {
            Data = data;
        }
        public TreeNode(int data, TreeNode left, TreeNode right, TreeNode parrent)
        {
            Data = data;
            Left = left;
            Right = right;
            Parrent = parrent;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
