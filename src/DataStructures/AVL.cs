using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// TODO: ****UNFINISHED***
    /// A standard AVL tree implementation
    /// 
    /// Assume: at the lowest node violating AVL,
    /// Assume: x.right is right heavy t (i.e. right child weight is heavy)
    ///         
    /// case 1: if x's right child is right-heavy or balanced
    ///         Rotate left (x)
    /// case 2: else  x's right child is left-heavy
    ///         Rotate Right(x.right)
    ///         Rotate Left(x)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVL<T> : BinaryTree<T> where T: IComparable
    {

        public void Rebalance(BinaryNode<T> toRotate)
        {
            if (toRotate.WeightDirection > 1)
            {
                
            }
        }

        /// <summary>
        ///       x
        ///     a   y
        ///        b  c
        /// 
        /// becomes
        ///         y
        ///     x     c
        ///    a b
        /// </summary>
        /// <param name="toAdd"></param>
        public void LeftRotate(BinaryNode<T> toRotate)
        {

            if (toRotate.Right != null)
            {
                var right = toRotate.Right;
                var tempLeft = toRotate.Right.Left;
                toRotate.SetRight(tempLeft);
                right.SetLeft(toRotate);
            }

        }


        /// <summary>
        ///         y
        ///     x     c
        ///    a b
        /// becomes
        ///       x
        ///     a   y
        ///        b  c
        /// 
        /// </summary>
        /// <param name="toRotate"></param>
        public void RightRotate(BinaryNode<T> toRotate)
        {

            if (toRotate.Left != null)
            {
                var left = toRotate.Left;
                var tempLeft = toRotate.Left.Right;
                toRotate.SetLeft(tempLeft);
                left.SetRight(toRotate);
            }

        }

        public void Insert(BinaryNode<T> toAdd)
        {
           Insert(toAdd, this.Root); 
        }


        /// <summary>
        /// Perform a binary search
        /// </summary>
        /// <param name="value"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryNode<T> Search(T value, BinaryNode<T> node)
        {
            var comparison = node.Value.CompareTo(value);
            if (comparison == 0)
            {
                return node;
            }
            else if (comparison > 0 && node.Left != null)
            {
                return Search(value, node.Left);
            }
            else if (comparison < 0 && node.Right != null)
            {
                return Search(value, node.Right);
            }

            // Not found
            return null;
        }

        protected BinaryNode<T> Lift(BinaryNode<T> currentNode)
        {
            // case 1: node is a leaf
            if (currentNode.Left == null && currentNode.Right == null)
            {
                return null;
            }

            // case 2: node has one child
            if (currentNode.Right == null)
            {
                return currentNode.Left;
            }
            else if (currentNode.Left == null)
            {
                return currentNode.Right;
            }


            // case 3a: right.left has a value
            // case 3b. right.left has no value. Replace with left
            if (currentNode.Right.Left == null)
            {
                currentNode.Right.SetLeft(currentNode.Left);
                return currentNode.Right;
            }
            else
            {
                // This assumes the tree is ordered. Walk down the left of the new parent node
                // until a free leaf is found since by definition all right-hand nodes are larger
                // than left-hand.
                var findReplace = currentNode.Right.Left;
                var replaced = false;
                while (!replaced)
                {
                    if (findReplace.Left == null)
                    {
                        findReplace.SetLeft(currentNode.Left);
                        replaced = true;
                    }
                    
                    findReplace = findReplace.Left;

                }
                return currentNode.Right;
            }

        }



        public bool Delete(T valueToDelete)
        {
            if (Root == null)
                return false;

            return Delete(valueToDelete, Root, null);
        }

        public bool Delete(T valueToDelete, BinaryNode<T> currentNode, BinaryNode<T> parent)
        {

            var compare = currentNode.Value.CompareTo(valueToDelete);
            if (compare == 0)
            {
                var lifted = Lift(currentNode);
                if (parent == null)
                {
                    Root = lifted;
                    
                }
                else
                {
                    if (parent.Left != null && parent.Left.Value.CompareTo(currentNode.Value) == 0)
                    {
                        parent.SetLeft(lifted);
                    }
                    else
                    {
                        parent.SetRight(lifted);
                    }
                }
                return true;
            }
            if (compare > 0 && currentNode.Left != null)
            {
                return Delete(valueToDelete, currentNode.Left, currentNode);
            }
            
            if (compare < 0 && currentNode.Right != null)
            {
                return Delete(valueToDelete, currentNode.Right, currentNode);
            }

            return false;
        }

        public void Insert(BinaryNode<T> toAdd, BinaryNode<T> currentNode )
        {
            // Value is greater than the node we're adding. Insert it to the left 
            if (currentNode.Value.CompareTo(toAdd.Value) > 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.SetLeft(toAdd);
                }
                else
                {
                   Insert(toAdd, currentNode.Left);
 
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.SetRight(toAdd);
                }
                else
                {
                   Insert(toAdd, currentNode.Right); 
                }
            }
        }
    }

    public static class BinaryNodeExtensions
    {
        public static bool IsAvl<T>(this BinaryNode<T> node) where T: IComparable
        {
            return node.WeightDirection > 1 || node.WeightDirection < -1;
        }
    }
}
