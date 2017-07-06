using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSPG;

namespace My_Game
{
    class Items
    {
        public enum Type
        {
            Tokens,
            Bombs,
        }
        Game mGame;
        Type mType;
        float mX;
        float mY;
        float mSpeed;
        bool mIsAlive;

        public Items(Game game, Type type, float X,float Y,float speed)
        {
            mGame = game;
            mType = type;
            mX = X;
            mY = Y;
            mSpeed = speed;

            mIsAlive = true;
        }
        public Type GetItemType()
        {
            return mType;
        }

        public float GetX()
        {
            return mX;
        }
        public float GetY()
        {
            return mY;
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

            switch (mType)
            {
                case Type.Tokens:
                    mY += mSpeed;
                    if (mY >= Console.WindowHeight)
                        mY = 0;
                    
                    break;
                case Type.Bombs:
                    mY += mSpeed;
                    if (mY >= Console.WindowHeight)
                        mY = 0;
                    
                    break;
                default:
                    break;
            }
        }
        public void Draw()
        {
            if (!mIsAlive)
                return;
            Console.SetCursorPosition((int)mX, (int)mY);
            switch (mType)
            {
                case Type.Tokens:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("o");
                    break;
                case Type.Bombs:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('x');
                    break;
                default:
                    break;
            }
        }
    }
}
