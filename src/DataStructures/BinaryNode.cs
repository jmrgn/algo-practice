using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    
    /// <summary>
    /// A simple Binary Node. 
    /// 
    /// Define weight direction by: right node height - left node height
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryNode<T> : Node<T> where T : IComparable
    {

        public int Height { get; protected set; }

        public int WeightDirection
        {
            get
            {
                int leftSize = 0;
                var rightSize = 0;
                if (Left != null)
                {
                    leftSize = Left.Size;
                }
                if (Right != null)
                {
                    rightSize = Right.Size;
                }
                return rightSize - leftSize;
            }
        }

        public BinaryNode() : base()
        {
            Neighbors = new NodeList<T>(2);
        }

        public BinaryNode(T data)
        {
            this.Value = data;
            Neighbors = new NodeList<T>(2);
            SetSize();

        }
        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;


            base.Neighbors = children;
            Height = CalculateHeight();
            SetSize();
        }

        private int CalculateHeight()
        {
            // null children default to height of -1
            int max = -1;
            
            if (Left != null)
            {
                max = Left.Height;
            }

            if (Right != null && Right.Height > max)
            {
                max = Right.Height;
            }

            return max + 1;
        }

        public BinaryNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryNode<T>)base.Neighbors[0];
            }
        }

        public BinaryNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryNode<T>)base.Neighbors[1];
            }
        }

        // Semi-Fuent interface to make things a bit easier
        public BinaryNode<T> And { get { return this; } }

        public BinaryNode<T> SetLeft(BinaryNode<T> left)
        {
            Neighbors[0] = left;
            Height = CalculateHeight();
            SetSize();
            return this;
        }

        public BinaryNode<T> SetRight(BinaryNode<T> right)
        {
            Neighbors[1] = right;
            Height = CalculateHeight();
            SetSize();
            return this;
        }

        public void DeleteLeft()
        {
            Neighbors[0] = null;
            Height = CalculateHeight();
            SetSize();
        }

        public void DeleteRight()
        {
            Neighbors[1] = null;
            Height = CalculateHeight();
            SetSize();
        }

        /// <summary>
        /// Inserts the given node in order, recalculating height in the process
        /// TODO: refactor this into the Binary Tree class
        /// </summary>
        /// <param name="toAdd"></param>
        public void Insert(BinaryNode<T> toAdd)
        {
            // Value is greater than the node we're adding. Insert it to the left 
            if (Value.CompareTo(toAdd.Value) > 0)
            {
                if (Left == null)
                {
                    SetLeft(toAdd);
                }
                else
                {
                    Left.Insert(toAdd);
                    Height = CalculateHeight();
                    SetSize();
                }
            }
            else
            {
                if (Right == null)
                {
                    SetRight(toAdd);
                }
                else
                {
                    Right.Insert(toAdd);
                    Height = CalculateHeight();
                    SetSize();
                }
            }
        }
    }
}
