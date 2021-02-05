using System;

namespace Algorithm
{
    internal class Program
    {
        private const int waitTick = 1000 / 30;
    
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Board board = new Board();
            Player player = new Player();
            
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            int lastTick = 0;
      
            while (true)
            {
                #region Frame Management
                int curTick = System.Environment.TickCount;
                if(curTick - lastTick < waitTick) continue;
                var deltaTick = curTick - lastTick;
                lastTick = curTick;
                #endregion
                
                #region Logic
                player.Update(deltaTick);
                #endregion

                #region Rendering
                Console.SetCursorPosition(0, 0);
                board.Render();
                #endregion
            }
        }
    }
}