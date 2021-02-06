using System;
using System.Collections;
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
                {0, 15, 0, 35, 0, 0},
                {15, 0, 5, 10, 0, 0},
                {0, 5, 0, 0, 0, 0},
                {35, 10, 0, 0, 5, 0},
                {0, 0, 0, 5, 0, 5},
                {0, 0, 0, 0, 5, 0}
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

            public void Dijikstra(int start)
            {
                bool[] visited = new bool[6];
                int[] distance = new int[6];
                int[] parent = new int[6];

                for (int i = 0; i < distance.Length; i++) distance[i] = int.MaxValue;

                distance[start] = 0;
                parent[start] = start;
                
                while (true)
                {
                    int closest = int.MaxValue;
                    int now = -1;
                    for (int i = 0; i < distance.Length; i++)
                    {
                        // 이미 방문했거나, 거리 체크조차도 안됐거나, 기존 후보보다 멀리있으면 스킵.
                        if(visited[i] || distance[i] == int.MaxValue || distance[i] >= closest) continue;
                        
                        closest = distance[i];
                        now = i;
                    }

                    // 다음 후보가 없다. 즉, 연결이 단절됐거나 이미 모든 곳을 방문했다.
                    if (now == -1) break;

                    visited[now] = true;

                    for (int next = 0; next < distance.Length; next++)
                    {
                        if(adj[now, next] == 0 || visited[next]) continue;

                        int nextDistance = distance[now] + adj[now, next];
                        if (distance[next] > nextDistance)
                        {
                            distance[next] = nextDistance;
                            parent[next] = now;
                        }
                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.BFS(0);
            graph.Dijikstra(0);
        }
    }
}