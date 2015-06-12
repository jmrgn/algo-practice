using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GraphNode<T> : Node<T>
    {
        private List<int> costs;

        public GraphNode() : base()
        {
            Neighbors = new NodeList<T>();
        }

        public GraphNode(T value) : base(value)
        {
            Neighbors = new NodeList<T>();
        }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();

                return costs;
            }
        }
    }
}
