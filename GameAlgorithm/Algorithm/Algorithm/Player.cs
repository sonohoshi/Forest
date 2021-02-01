using System;

namespace Algorithm
{
    public class Player
    {
        private static Random rand;
        
        private Board board;
        
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

            
        }
        
        private const int moveTick = 100;
        private int sumTick = 0;
        public void Update(int deltaTick)
        {
            sumTick += deltaTick;
            if (sumTick >= moveTick)
            {
                sumTick = 0;

                int randValue = rand.Next(0, 4);
                switch (randValue)
                {
                    case 0:
                        if (y - 1 >= 0 && board.Tile[y - 1, x] == (int) Board.TileType.Empty)
                        {
                            y -= 1;
                        }
                        break;
                    case 1:
                        if (y + 1 < board.Size - 1 && board.Tile[y + 1, x] == (int) Board.TileType.Empty)
                        {
                            y += 1;
                        }
                        break;
                    case 2:
                        if (x - 1 >= 0 && board.Tile[y, x - 1] == (int) Board.TileType.Empty)
                        {
                            x -= 1;
                        }
                        break;
                    case 3:
                        if (x + 1 < board.Size - 1 && board.Tile[y, x + 1] == (int) Board.TileType.Empty)
                        {
                            x += 1;
                        }
                        break;
                }
            }
        }
    }
}