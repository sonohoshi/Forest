using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace Algorithm
{
    class Position
    {
        public int x, y;
        
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    public class Player
    {
        private enum Direction
        {
            Up = 0,
            Left = 1,
            Right = 2,
            Down = 3,
        }
        
        private static Random rand;
        
        private Board board;
        private int dir = (int) Direction.Up;
        private List<Position> positions = new List<Position>();
        
        public int x { get; private set; }
        public int y { get; private set; }

        public void Initialize(int x, int y, Board board)
        {
            this.x = x;
            this.y = y;
            this.board = board;

            if (rand == null)
            {
                rand = new Random();
            }

            int[] frontY = new[] {-1, 0, 1, 0};
            int[] frontX = new[] {0, -1, 0, 1};
            int[] rightY = new[] {0, -1, 0, 1};
            int[] rightX = new[] {1, 0, -1, 0};

            positions.Add(new Position(x, y));
            
            while (x != board.DestX || y != board.DestY)
            {
                if (board.Tile[y + rightY[dir], x + rightX[dir]] == (int) Board.TileType.Empty)
                {
                    dir = (dir - 1 + 4) % 4;
                    x += frontX[dir];
                    y += frontY[dir];
                    
                    positions.Add(new Position(x, y));
                }
                else if(board.Tile[y + frontY[dir], x + frontX[dir]] == (int) Board.TileType.Empty)
                {
                    x += frontX[dir];
                    y += frontY[dir];
                    
                    positions.Add(new Position(x, y));
                }
                else
                {
                    dir = (dir + 1 + 4) % 4;
                }
            }
        }
        
        private const int moveTick = 100;
        private int sumTick = 0;
        private int lastIndex = 0;
        public void Update(int deltaTick)
        {
            if (lastIndex >= positions.Count) return;
            
            sumTick += deltaTick;
            if (sumTick >= moveTick)
            {
                sumTick = 0;

                int randValue = rand.Next(0, 4);
                y = positions[lastIndex].y;
                x = positions[lastIndex].x;

                lastIndex++;
            }
        }
    }
}