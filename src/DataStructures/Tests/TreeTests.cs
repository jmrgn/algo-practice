using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture]
    public class TreeTests
    {
        private BinaryTree<int> tree;
        private BinaryTree<int> orderedTree;
        private AVL<int> avl;
        
        [SetUp]
        public void SetUp()
        {
            /*
             *                      1
             *                  2       3              
             *              4               5
             *                  6               7
             *                                      8
             * 
             */
            // NOTE: levels will be incorrect when constructed this way. Make a method in binary tree that sets levels, weights correctly
            // and add an insert function. Maybe make the setters protected?

            tree = new BinaryTree<int>();
            tree.Root = new BinaryNode<int>(1);
            tree.Root.And.SetLeft(new BinaryNode<int>(2));
            tree.Root.And.SetRight( new BinaryNode<int>(3));

            tree.Root.Left.And.SetLeft(new BinaryNode<int>(4));
            tree.Root.Right.And.SetRight (new BinaryNode<int>(5));

            tree.Root.Left.Left.And.SetRight(new BinaryNode<int>(6));
            tree.Root.Right.Right.And.SetRight(new BinaryNode<int>(7));

            tree.Root.Right.Right.Right.And.SetRight(new BinaryNode<int>(8));

            /*
             *                      5
             *                  2       6              
             *               1   4        8
             *                  3        7       
             *                   3                   
             * 
             */
            orderedTree = new BinaryTree<int>();
            orderedTree.Root = new BinaryNode<int>(5);
            orderedTree.Root.Insert(new BinaryNode<int>(2));
            orderedTree.Root.Insert(new BinaryNode<int>(6));
            orderedTree.Root.Insert(new BinaryNode<int>(8));
            orderedTree.Root.Insert(new BinaryNode<int>(1));
            orderedTree.Root.Insert(new BinaryNode<int>(4));
            orderedTree.Root.Insert(new BinaryNode<int>(3));
            orderedTree.Root.Insert(new BinaryNode<int>(7));
            orderedTree.Root.Insert(new BinaryNode<int>(3));

            avl = new AVL<int>();
            avl.Root = new BinaryNode<int>(5);
            avl.Root.Insert(new BinaryNode<int>(2));
            avl.Root.Insert(new BinaryNode<int>(6));
            avl.Root.Insert(new BinaryNode<int>(8));
            avl.Root.Insert(new BinaryNode<int>(1));
            avl.Root.Insert(new BinaryNode<int>(4));
            avl.Root.Insert(new BinaryNode<int>(3));
            avl.Root.Insert(new BinaryNode<int>(7));
            avl.Root.Insert(new BinaryNode<int>(3));

        }

        [Test]
        public void DepthFirstTraversal()
        {
            var expected = "5,2,1,4,3,3,3,6,8,7,";
            Console.WriteLine("Printing depth first");
            var result = orderedTree.DepthFirstTraversal();
            Debug.WriteLine("Finished printing");
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void BreadthFirstTraversal()
        {
            var expected = "1,2,3,4,5,6,7,8,";
            Console.WriteLine("Printing breadth first");
            var result = orderedTree.BreadthFirstTraversal();
            Debug.WriteLine("Finished printing");
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateWeight()
        {
            Assert.That(orderedTree.Root.WeightDirection, Is.EqualTo(-2));
            Assert.That(orderedTree.Root.Right.WeightDirection, Is.EqualTo(2));
            Assert.That(orderedTree.Root.Right.Right.WeightDirection, Is.EqualTo(-1));
            Assert.That(orderedTree.Root.Right.Right.Left.WeightDirection, Is.EqualTo(0));
            Assert.That(orderedTree.Root.Left.WeightDirection, Is.EqualTo(2));
            Assert.That(orderedTree.Root.Left.Left.WeightDirection, Is.EqualTo(0));

            Assert.That(orderedTree.Root.Left.Right.WeightDirection, Is.EqualTo(-2));
            Assert.That(orderedTree.Root.Left.Right.Left.WeightDirection, Is.EqualTo(1));
            Assert.That(orderedTree.Root.Left.Right.Left.Left.WeightDirection, Is.EqualTo(0));



        
        }

        [Test]
        public void AVLDeleteTest()
        {
            

            avl.Delete(4, avl.Root, null);

           
        }
    }
}
