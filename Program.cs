using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSPG;

namespace My_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.SetupWindow("My Game", 80, 32);
            Utility.EOLWrap(false);

            Game game = new Game();
            game.Menu();
            game.Init();
            game.Run();
            game.End();
            


            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
