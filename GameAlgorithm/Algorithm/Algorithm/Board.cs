using System;

namespace Algorithm
{
    public class Board
    {
        private const char circle = '\u25cf';
        private static Random rand = new Random();
        private enum TileType : int
        {
            Empty = 0,
            Wall = 1
        }

        public int[,] tile;
        public int size;

        public Board(int size)
        {
            if (size % 2 == 0)
            {
                throw new Exception("Size can not even number.");
            }
            
            tile = new int[size, size];
            this.size = size;

            //GenerateMazeByBinaryTree();
            GenerateMazeBySideWinder();
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.ForegroundColor = GetTileColor((TileType) tile[j, i]);
                    Console.Write(circle);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        private void GenerateMazeBySideWinder()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j % 2 == 0 || i % 2 == 0)
                        tile[i, j] = (int) TileType.Wall;
                    
                    else
                        tile[i, j] = (int) TileType.Empty;
                }
            }
            
            for (int i = 0; i < size; i++)
            {
                int cnt = 1;
                for (int j = 0; j < size; j++)
                {
                    if ((j % 2 == 0 || i % 2 == 0) || (i == size - 2 && i == j))
                        continue;
                    
                    if (i == size - 2)
                    {
                        tile[i, j + 1] = (int) TileType.Empty;
                        continue;
                    }
                    
                    if (j == size - 2)
                    {
                        tile[i + 1, j] = (int) TileType.Empty;
                        continue;
                    }

                    if (GetRandomBoolean())
                    {
                        tile[i, j + 1] = (int) TileType.Empty;
                        cnt++;
                    }
                    else
                    {
                        int randIndex = rand.Next(0, cnt);
                        tile[i + 1, j - randIndex] = (int) TileType.Empty;
                        cnt = 1;
                    }
                }
            }
        }

        private void GenerateMazeByBinaryTree()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j % 2 == 0 || i % 2 == 0)
                        tile[j, i] = (int) TileType.Wall;
                    
                    else
                        tile[j, i] = (int) TileType.Empty;
                }
            }
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((j % 2 == 0 || i % 2 == 0) || (j == size - 2 && i == j))
                        continue;
                    if (j == size - 2)
                    {
                        tile[j, i + 1] = (int) TileType.Empty;
                        continue;
                    }
                    
                    if (i == size - 2)
                    {
                        tile[j + 1, i] = (int) TileType.Empty;
                        continue;
                    }

                    if (GetRandomBoolean())
                    {
                        tile[j, i + 1] = (int) TileType.Empty;
                    }
                    else
                    {
                        tile[j + 1, i] = (int) TileType.Empty;
                    }
                }
            }
        }

        private ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty: return ConsoleColor.Cyan;
                case TileType.Wall: return ConsoleColor.Red;
                
                default: return ConsoleColor.White;
            }
        }

        private bool GetRandomBoolean()
        {
            return rand.NextDouble() < 0.5;
        }
    }
}