using System;
using System.Collections.Generic;
using System.Linq;

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

            bool[] visited = new bool[6];
            public void DFS(int start)
            {
                Console.WriteLine(start);
                visited[start] = true;

                for (int i = 0; i < adj.GetLength(0); i++)
                {
                    // 연결되어있지 않거나 방문한 노드라면 처리 안함.
                    if(adj[start, i] == 0 || visited[i]) continue;
                    DFS(i);
                }
            }

            public void DFSWithList(int start)
            {
                Console.WriteLine(start);
                visited[start] = true;

                foreach (var node in adj2[start].Where(node => !visited[node]))
                {
                    DFSWithList(node);
                }
            }

            public void SearchAllWithDFS()
            {
                visited = new bool[6];
                for (int i = 0; i < adj.GetLength(0); i++)
                {
                    if(!visited[i]) DFS(i);
                }
            }

            public void BFS(int start)
            {
                bool[] found = new bool[6];
                int[] parent = new int[6];
                int[] distance = new int[6];
                
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                found[start] = true;
                parent[start] = start;
                distance[start] = 0;

                while (queue.Count > 0)
                {
                    int now = queue.Dequeue();
                    Console.WriteLine(now);

                    for (int i = 0; i < adj.GetLength(0); i++)
                    {
                        // 연결되지 않았거나 이미 발견된 노드라면 스킵
                        if(adj[now, i] == 0 || found[i]) continue;
                        
                        queue.Enqueue(i);
                        found[i] = true;
                        parent[i] = now;
                        distance[i] = distance[now] + 1;
                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.BFS(0);
        }
    }
}