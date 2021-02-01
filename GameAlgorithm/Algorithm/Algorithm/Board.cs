using System;

namespace Algorithm
{
    public class Board
    {
        public enum TileType : int
        {
            Empty = 0,
            Wall = 1
        }
        private const char circle = '\u25cf';
        private static Random rand = new Random();

        private Player player; 

        public int[,] Tile { get; private set; }
        public int Size { get; private set; }

        public void Initialize(int size,Player player)
        {
            this.player = player;
            
            if (size % 2 == 0)
            {
                throw new Exception("Size can not even number.");
            }
            
            Tile = new int[size, size];
            this.Size = size;

            //GenerateMazeByBinaryTree();
            GenerateMazeBySideWinder();
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == player.y && j == player.x)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ForegroundColor = GetTileColor((TileType) Tile[i, j]);
                    }
                    Console.Write(circle);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        private void GenerateMazeBySideWinder()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j % 2 == 0 || i % 2 == 0)
                        Tile[i, j] = (int) TileType.Wall;
                    
                    else
                        Tile[i, j] = (int) TileType.Empty;
                }
            }
            
            for (int i = 0; i < Size; i++)
            {
                int cnt = 1;
                for (int j = 0; j < Size; j++)
                {
                    if ((j % 2 == 0 || i % 2 == 0) || (i == Size - 2 && i == j))
                        continue;
                    
                    if (i == Size - 2)
                    {
                        Tile[i, j + 1] = (int) TileType.Empty;
                        continue;
                    }
                    
                    if (j == Size - 2)
                    {
                        Tile[i + 1, j] = (int) TileType.Empty;
                        continue;
                    }

                    if (GetRandomBoolean())
                    {
                        Tile[i, j + 1] = (int) TileType.Empty;
                        cnt++;
                    }
                    else
                    {
                        int randIndex = rand.Next(0, cnt);
                        Tile[i + 1, j - randIndex] = (int) TileType.Empty;
                        cnt = 1;
                    }
                }
            }
        }

        private void GenerateMazeByBinaryTree()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j % 2 == 0 || i % 2 == 0)
                        Tile[j, i] = (int) TileType.Wall;
                    
                    else
                        Tile[j, i] = (int) TileType.Empty;
                }
            }
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if ((j % 2 == 0 || i % 2 == 0) || (j == Size - 2 && i == j))
                        continue;
                    if (j == Size - 2)
                    {
                        Tile[j, i + 1] = (int) TileType.Empty;
                        continue;
                    }
                    
                    if (i == Size - 2)
                    {
                        Tile[j + 1, i] = (int) TileType.Empty;
                        continue;
                    }

                    if (GetRandomBoolean())
                    {
                        Tile[j, i + 1] = (int) TileType.Empty;
                    }
                    else
                    {
                        Tile[j + 1, i] = (int) TileType.Empty;
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