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

        class Tree<T>
        {
            public T Data { get; set; }
            public List<Tree<T>> Children { get; set; } = new List<Tree<T>>();
        }

        private static Tree<string> MakeTree()
        {
            Tree<string> root = new Tree<string> {Data = "R1 개발실"};
            {
                {
                    Tree<string> node = new Tree<string> {Data = "디자인팀"};
                    node.Children.Add(new Tree<string>{Data = "전투"});
                    node.Children.Add(new Tree<string>{Data = "경제"});
                    node.Children.Add(new Tree<string>{Data = "스토리"});
                    root.Children.Add(node);
                }
                {
                    Tree<string> node = new Tree<string> {Data = "프로그래밍팀"};
                    node.Children.Add(new Tree<string>{Data = "서버"});
                    node.Children.Add(new Tree<string>{Data = "클라이언트"});
                    node.Children.Add(new Tree<string>{Data = "엔진"});
                    root.Children.Add(node);
                }
                {
                    Tree<string> node = new Tree<string> {Data = "아트팀"};
                    node.Children.Add(new Tree<string>{Data = "배경"});
                    node.Children.Add(new Tree<string>{Data = "캐릭터"});
                    root.Children.Add(node);
                }
            }

            return root;
        }

        private static void PrintTree(Tree<string> root)
        {
            Console.WriteLine(root.Data);
            foreach (var child in root.Children)
            {
                PrintTree(child);
            }
        }

        class QuadTree
        {
            public KeyValuePair<int, int> Data { get; set; }
            public List<QuadTree> Children { get; set; }
            
            public QuadTree()
            {
                Data = new KeyValuePair<int, int>();
                Children = new List<QuadTree>();
            }
            
            public QuadTree(int n, int m)
            {
                Data = new KeyValuePair<int, int>(n, m);
                Children = new List<QuadTree>();
            }

            private static int x = 0;
            public void InOrderTraversal(QuadTree tree, int y)
            {
                if (tree == null) return;
                if (tree.Children.Count == 0)
                {
                    //Console.WriteLine(tree.Data);
                    Console.WriteLine($"[{++x}, {y}]");
                    return;
                }

                InOrderTraversal(tree.Children[0], y - 1);
                InOrderTraversal(tree.Children[1], y - 1);
                //Console.WriteLine(tree.Data);
                Console.WriteLine($"[{++x}, {y}]");
                InOrderTraversal(tree.Children[2], y - 1);
                InOrderTraversal(tree.Children[3], y - 1);
            }
        }

        private static QuadTree MakeQuadTree()
        {
            var root = new QuadTree(7, 0);
            {
                root.Children.Add(new QuadTree(1, -1));
                root.Children.Add(new QuadTree(4, -1));
                root.Children.Add(new QuadTree(10, -1));
                root.Children.Add(new QuadTree(13, -1));
            }
            {
                root.Children[1].Children.Add(new QuadTree(2, -2));
                root.Children[1].Children.Add(new QuadTree(3, -2));
                root.Children[1].Children.Add(new QuadTree(5, -2));
                root.Children[1].Children.Add(new QuadTree(6, -2));
            }
            {
                root.Children[2].Children.Add(new QuadTree(8, -2));
                root.Children[2].Children.Add(new QuadTree(9, -2));
                root.Children[2].Children.Add(new QuadTree(11, -2));
                root.Children[2].Children.Add(new QuadTree(12, -2));
            }

            return root;
        }

        private static int GetHeight<T>(Tree<T> root)
        {
            int height = 0;

            foreach (var child in root.Children)
            {
                int newHeight = GetHeight<T>(child) + 1;
                height = Math.Max(height, newHeight);
            }
            
            return height;
        }
        
        public static void Main(string[] args)
        {
            /*
            Graph graph = new Graph();
            graph.BFS(0);
            graph.Dijikstra(0);
            */

            /*
            var root = MakeTree();
            PrintTree(root);
            Console.WriteLine(GetHeight(root));
            */

            var quadTree = MakeQuadTree();
            quadTree.InOrderTraversal(quadTree, 0);
        }
    }
}