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
        private Stack<Position> positionsByBFS = new Stack<Position>();
        
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

            //SolveByRightHandRule();
            BFS();
        }

        private void BFS()
        {
            int[] deltaY = new[] {-1, 0, 1, 0};
            int[] deltaX = new[] {0, -1, 0, 1};
            
            bool[,] found = new bool[board.Size, board.Size];
            Position[,] parents = new Position[board.Size, board.Size];
                
            Queue<Position> queue = new Queue<Position>();
            queue.Enqueue(new Position(x, y));
            found[y, x] = true;
            parents[y, x] = new Position(x, y);

            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                int nowX = pos.x;
                int nowY = pos.y;

                for (int i = 0; i < 4; i++)
                {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];

                    if (nextX < 0 || nextX >= board.Size || nextY < 0 || nextY >= board.Size) continue;
                    if (board.Tile[nextY, nextX] == (int) Board.TileType.Wall || found[nextY, nextX]) continue;

                    queue.Enqueue(new Position(nextX, nextY));
                    found[nextY, nextX] = true;
                    parents[nextY, nextX] = new Position(nowX, nowY);
                }
            }

            int destY = board.DestY;
            int destX = board.DestX;

            while (parents[destY, destX].y != destY || parents[destY, destX].x != destX)
            {
                positionsByBFS.Push(new Position(destX, destY));
                var pos = parents[destY, destX];
                destY = pos.y;
                destX = pos.x;
            }

            positionsByBFS.Push(new Position(destX, destY));
        }

        private void SolveByRightHandRule()
        {
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
            // if (lastIndex >= positions.Count) return;
            if (positionsByBFS.Count <= 0) return;
            
            sumTick += deltaTick;
            if (sumTick >= moveTick)
            {
                sumTick = 0;

                y = positionsByBFS.Peek().y;
                x = positionsByBFS.Peek().x;
                positionsByBFS.Pop();
                
                lastIndex++;
            }
        }
    }
}