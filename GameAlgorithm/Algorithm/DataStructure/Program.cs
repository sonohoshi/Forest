using System.Collections.Generic;

namespace DataStructure
{
    internal class Program
    {
        class Graph
        {
            private int[,] adj = new int[6, 6]
            {
                {0, 1, 0, 1, 0, 0},
                {1, 0, 1, 1, 0, 0},
                {0, 1, 0, 0, 0, 0},
                {1, 1, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 1},
                {0, 0, 0, 0, 1, 0}
            };

            private List<int>[] adj2 = new List<int>[]
            {
                new List<int>() {1, 3},
                new List<int>() {0, 2, 3},
                new List<int>() {1},
                new List<int>() {1, 4},
                new List<int>() {3, 5},
                new List<int>() {4}
            };
        }
        
        public static void Main(string[] args)
        {
            
        }
    }
}