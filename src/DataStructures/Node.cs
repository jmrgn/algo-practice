using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbors = null;

     
        public int Size { get; set; }
         

        public Node()
        {
            SetSize();
        }

        public Node(T data) : this(data, null)
        {
            
        }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
            SetSize();
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected void SetSize()
        {
            var count = 1;
            if (neighbors != null)
            {
                foreach (var neighbor in neighbors)
                {
                    if (neighbor != null)
                    {
                        count += neighbor.Size;
                    }
                }
            }
            Size = count;
        }

        public NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
}
