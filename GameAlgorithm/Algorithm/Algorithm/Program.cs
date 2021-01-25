using System;

namespace Algorithm
{
  internal class Program
  {
    private const int waitTick = 1000 / 30;
    
    public static void Main(string[] args)
    {
      Console.CursorVisible = false;
      Board board = new Board(25);

      int lastTick = 0;
      
      while (true)
      {
        #region Frame Management
        int curTick = System.Environment.TickCount;
        if(curTick - lastTick < waitTick) continue;
        lastTick = curTick;
        #endregion

        Console.SetCursorPosition(0, 0);
        board.Render();
      }
    }
  }
}