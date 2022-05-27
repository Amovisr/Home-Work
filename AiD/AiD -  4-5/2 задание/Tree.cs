namespace _2_задание
{
    public class Tree

    {
        public TreeNode Root { get; set; }
        public int Count { get; set; }

        private IComparer<int> _comparer = Comparer<int>.Default;

        public Tree() { }

        public TreeNode GetNodeByValue(int value)
        {
            var node = Root;

            while (node != null)
            {
                if (value > node.Data)
                {
                    if (node.Right != null)
                    {
                        node = node.Right;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Числа {value} не содержится в дереве");
                        return Root;
                    }
                }
                else if (value < node.Data)
                {
                    if (node.Left != null)
                    {
                        node = node.Left;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Числа {value} не содержится в дереве");
                        return Root;
                    }
                }
                else if (value == node.Data)
                {
                    Console.WriteLine($"Найден нод который содержит {node.Data}");
                    break;
                }
            }
            return Root;

        }
        public bool AddItem(int data)
        {
            var root = new TreeNode(data);
            if (Count == 0)
            {
                Root = root;
                root.Parrent = null;
                Count = 1;
                return true;
            }
            else
            {
                return Add_Sub(Root, data);
            }
            bool Add_Sub(TreeNode Node, int data)
            {
                if (_comparer.Compare(Node.Data, data) < 0)
                {
                    if (Node.Right == null)
                    {
                        Node.Right = new TreeNode(data);
                        Node.Right.Parrent = Node;
                        Count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.Right, data);
                    }
                }
                else if (_comparer.Compare(Node.Data, data) > 0)
                {
                    if (Node.Left == null)
                    {
                        Node.Left = new TreeNode(data);
                        Node.Left.Parrent = Node;
                        Count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.Left, data);
                    }
                }
                else
                {
                    return false;
                }
            }


        }
        /// <summary>
        ///  DFS
        /// </summary>
        /// <param name="node"></param>
        public void preOrder(TreeNode node)
        {
            if (node == null)
                return;
            Console.WriteLine($"{node.Data} ");
            preOrder(node.Left);
            preOrder(node.Right);
        }
        public void postOrder(TreeNode node)
        {
            if (node == null)
                return;
            postOrder(node.Left);
            postOrder(node.Right);
            Console.WriteLine($"{node.Data} ");
        }
        public void inOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            inOrder(node.Left);
            Console.WriteLine($"{node.Data} ");
            inOrder(node.Right);
        }
        public void BFS()
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(this.Root);
            while (q.Count > 0)
            {
                TreeNode n = q.Dequeue();
                Console.Write($"{n.Data} ");
                if (n.Left != null)
                    q.Enqueue(n.Left);
                if (n.Right != null)
                    q.Enqueue(n.Right);
            }

        }
        public interface ITree
        {
            TreeNode GetRoot();
            void AddItem(int value); // добавить узел
            void RemoveItem(int value); // удалить узел по значению
            TreeNode GetNodeByValue(int value); //получить узел дерева по значению
            void PrintTree(); //вывести дерево в консоль
        }

    }
}