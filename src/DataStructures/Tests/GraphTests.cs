using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture]
    public class GraphTests
    {
        private Graph<string> graph;
        private GraphNode<string> startNode;
            
        [SetUp]
        public void SetUp()
        {
            graph = new Graph<string>();

            startNode = new GraphNode<string>("s");
            var a = new GraphNode<string>("a");
            var z = new GraphNode<string>("z");
            var x = new GraphNode<string>("x");
            var c = new GraphNode<string>("c");
            var v = new GraphNode<string>("v");
            var d = new GraphNode<string>("d");
            var f = new GraphNode<string>("f");
            graph.AddNode(startNode);
            graph.AddNode(a);
            graph.AddNode(z);
            graph.AddNode(x);
            graph.AddNode(c);
            graph.AddNode(v);
            graph.AddNode(d);
            graph.AddNode(f);
            /*
             * a - s   c - v  
             * |   | / | \ |
             * z   x - d - f
             */ 


            graph.AddUndirectedEdge(a, startNode, 1);
            graph.AddUndirectedEdge(a, z, 1);
            graph.AddUndirectedEdge(startNode, x, 1);
            graph.AddUndirectedEdge(x, d, 1);
            graph.AddUndirectedEdge(x, c, 1);
            graph.AddUndirectedEdge(d, c, 1);
            graph.AddUndirectedEdge(d, f, 1);
            graph.AddUndirectedEdge(c, f, 1);
            graph.AddUndirectedEdge(c, v, 1);
            graph.AddUndirectedEdge(f, v, 1);
        }


        [Test]
        public void BFSTest()
        {
            string result;
            result = graph.BreadthFirstTraversal(startNode);
        }

        [Test]
        public void DFSTest()
        {
            graph.DepthFirstSearch(startNode);
        }


    }
}
