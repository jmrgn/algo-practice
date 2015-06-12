using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Graph<T>
    {
        private GraphNodeList<T> nodeSet;

        public Graph() : this(null) { }
        public Graph(GraphNodeList<T> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new GraphNodeList<T>();
            else
                this.nodeSet = nodeSet;
        }

        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            // adds a node to the graph
            nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public GraphNodeList<T> Nodes
        {
            get
            {
                return nodeSet;
            }
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }


        public string DepthFirstSearchVisit(Node<T> start, Dictionary<Node<T>, Node<T>> parent, Dictionary<Node<T>, bool> visited)
        {
            
            foreach (var v in start.Neighbors)
            {
                // if !visited
                if (!visited.ContainsKey(v))
                {
                    Debug.WriteLine("Visiting: {0}", v.Value); 
                    visited.Add(v, true);

                    if (!parent.ContainsKey(v))
                    {
                        parent.Add(v, start);
                    }
                    DepthFirstSearchVisit(v, parent, visited);
                }
            }
            return string.Empty;

        }



        /// <summary>
        /// for a set of vertices, visit everything
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        public void DepthFirstSearch(Node<T> start)
        {
            var parent = new Dictionary<Node<T>, Node<T>>();
            var visited = new Dictionary<Node<T>, bool>();
            Debug.WriteLine("Visiting: {0}", start.Value); 
            parent[start] = null;
            visited.Add(start, true);
            DepthFirstSearchVisit(start, parent, visited);
        }


        // start at the first node
        public string BreadthFirstTraversal()
        {
            
            if (this.Nodes == null || this.Nodes.Count == 0)
            {
                return string.Empty;
            }

            return BreadthFirstTraversal(this.Nodes[0]);

        }

        public string BreadthFirstTraversal(Node<T> start)
        {
            var parent = new Dictionary<Node<T>, Node<T>>();
            var visited = new Dictionary<Node<T>, int>();
            StringBuilder builder = new StringBuilder();

            var frontier = new List<Node<T>>() {start};
            visited[start] = 0;
            parent[start] = null;
            int i = 1;
            while (frontier.Count > 0)
            {
                var next = new List<Node<T>>() {};
                foreach(var u in frontier)
                {
                    Debug.WriteLine("Visiting: {0} at level {1}", u.Value, i - 1);
                    builder.Append(u.Value.ToString());
                    builder.Append(','); 
                    foreach (var v in u.Neighbors)
                    {
                        if (!visited.ContainsKey(v))
                        {
                            visited[v] = i;
                            parent[v] = u;
                            next.Add(v);
                           
                        }
                    }
                }
                frontier = next;
                i++;
            }
            return builder.ToString();
        }

        public string DijskraTraversal(Node<T> start)
        {
            var parent = new Dictionary<Node<T>, Node<T>>();
            var visited = new Dictionary<Node<T>, int>();
            StringBuilder builder = new StringBuilder();

            var frontier = new List<Node<T>>() { start };
            visited[start] = 0;
            parent[start] = null;
            int i = 1;
            while (frontier.Count > 0)
            {
                var next = new List<Node<T>>() { };
                foreach (var u in frontier)
                {
                    Debug.WriteLine("Visiting: {0} at level {1}", u.Value, i - 1);
                    builder.Append(u.Value.ToString());
                    builder.Append(',');
                    foreach (var v in u.Neighbors)
                    {
                        if (!visited.ContainsKey(v))
                        {
                            visited[v] = i;
                            parent[v] = u;
                            next.Add(v);

                        }
                    }
                }
                frontier = next;
                i++;
            }
            return builder.ToString();
        }
    }
}
