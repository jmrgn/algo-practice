using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T> where T: IComparable
    {
        public delegate void VisitDelegate(BinaryNode<T> node, StringBuilder builder);

        public BinaryNode<T> Root { get; set; }
        public BinaryTree(BinaryNode<T> root)
        {
            this.Root = root;
        }

        public BinaryTree()
        {
            this.Root = null;
        }
        public virtual void Clear()
        {
            Root = null;
        }

        public string DepthFirstTraversal()
        {
            if (Root == null)
                return string.Empty;
            
            return DepthFirstTraversal(Root);
        }
        
        
        private string DepthFirstTraversal(BinaryNode<T> node)
        {
            var item = string.Empty;

            if (node == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            item = Convert.ToString(node.Value);
            builder.Append(item);
            builder.Append(',');

            Debug.WriteLine(item);
            builder.Append(DepthFirstTraversal(node.Left));
            builder.Append(DepthFirstTraversal(node.Right));

            return builder.ToString();
        }

        public string BreadthFirstTraversal()
        {
            return BreadthFirstTraversal(VisitAction);
        }

        public void VisitLevel(BinaryNode<T> node, StringBuilder builder)
        {
            var item = Convert.ToString(node.Value);
            builder.Append(item);
            builder.Append(',');
            Debug.WriteLine(item); 
        }

        public void VisitAction(BinaryNode<T> node, StringBuilder builder)
        {
            var item = Convert.ToString(node.Value);
            builder.Append(item);
            builder.Append(',');
            Debug.WriteLine(item);
        }

        public string BreadthFirstTraversal(VisitDelegate visitAction)
        {
            var queue = new Queue<BinaryNode<T>>();
            if (Root == null)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                // visit a current node
                var current = queue.Dequeue();
                visitAction(current, builder);
                
                EnqueueChildren(queue, current);
            }
            return builder.ToString();
        }



        public void EnqueueChildren(Queue<BinaryNode<T>> queue, BinaryNode<T> current)
        {
            // enqueue currently visited children
            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            } 
        }
    }
}
