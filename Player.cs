using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSPG;

namespace My_Game
{
    class Player
    {
        const float PlayerSpeed = 0.1f;
        Game mGame;
        float mX;
        float mY;
        int mLives = 3;
        bool mIsAlive;
        int playerWidth = 5;
         

        public Player(Game game)
        {
            mGame = game;
            
            mX = Console.WindowWidth / 2;
            mY = Console.WindowHeight - 2;
            mIsAlive = true;
        }
        public int GetLives()
        {
            return mLives;
        }
        public float GetX()
        {
            return mX;
        }

        public float GetY()
        {
            return mY;
        }

        public int GetWidth()
        {
            return playerWidth;
        }

        public bool IsAlive()
        {
            return mIsAlive;
        }

        public void Kill()
        {
            mIsAlive = false;
        }

        public void Update()
        {
            if (!mIsAlive)
                return;

            if (Utility.GetKeyState(ConsoleKey.LeftArrow))
                mX -= PlayerSpeed;
            else if (Utility.GetKeyState(ConsoleKey.RightArrow))
                mX += PlayerSpeed;

            if (mX < 0)
                mX = Console.WindowWidth - 1;
            else if (mX >= Console.WindowWidth)
                mX = 0;
        }
        public void Draw()
        {
            if (!mIsAlive)
                return;
           
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)mX, (int)mY);
            //make collision detection on symbol instead of cursor
            for(int i = 0; i < playerWidth; ++i)     
                Console.Write("▄");
            //Console.SetCursorPosition((int)mX -1, (int)mY);
            //Console.Write('▄');
            //Console.SetCursorPosition((int)mX +1, (int)mY);
            //Console.Write('▄');
            Console.ForegroundColor = lastColor;
        }
    }
}
