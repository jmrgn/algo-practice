using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDistance
{
    class Program
    {
        /// <summary>
        /// Document: A sequence of words
        /// Word: A sequence of alphanumeric characters
        /// D[W]: the number of occurrences of Word w in document D
        /// Distance: The number of shared words between to documents
        /// Think of this as a vector of all words, indexed by each word, each with a frequency of occurrences
        /// in a document.
        /// 
        /// 1. Split a document into words
        /// 2. Compute word frequencies
        /// 3. Compute dot product
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }
    }
}
