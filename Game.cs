using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSPG;
using System.Threading;

namespace My_Game
{
    class Game
    {
        const int NumItems = 10;
        Player mPlayer;
        List<Items> mItems;
        int mScore;
        int mLives = 3;
        bool mGaveOver;

        public void Menu()
        {
            do
            {
                Utility.WriteCentered("1) Play!");
                Utility.WriteCentered("2) Exit!", 1);
                Utility.WriteCentered(" ", 2);
                int input = Utility.ReadInt();
                if (input == 1)
                    break;
                else if (input == 2)
                {
                    Console.Clear();
                    Utility.WriteCentered("  Goodbye.");
                    mGaveOver = true;
                }
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Press ENTER to continue.");
                Console.ReadLine();



            } while (!Utility.IsReadGood());
        }
        public void Init()
        {
            mPlayer = new Player(this);
            mItems = new List<Items>();
            for (int i = 0; i < NumItems; i++)
            {
                Items Tokens = new Items(this, Items.Type.Tokens,
                    Utility.Rand() % Console.WindowWidth,
                    Utility.Rand() % Console.WindowHeight,
                    Utility.Rand() % .1f / 100f + .01f);
                //Utility.Rand() % .70f / 50.0f);
                Items Bombs = new Items(this, Items.Type.Bombs,
                    Utility.Rand() % Console.WindowWidth,
                     Utility.Rand() % Console.WindowHeight,
                     Utility.Rand() % 10f / 100f + .01f);
                //Utility.Rand() % .70f / 50.0f);

                mItems.Add(Tokens);
                mItems.Add(Bombs);
            }
            mGaveOver = false;
            mScore = 0;
        }
        public void Run()
        {
            while (!mGaveOver)
            {
                if (Utility.GetKeyState(ConsoleKey.Escape))
                {
                    mGaveOver = true;
                    break;
                }
                Update();
                Draw();
                //Thread.Sleep(10);
            }
        }
        public void End()
        {
            bool win = false;
            if (mScore == NumItems * 100)
                win = true;
            //if (mScore == 800)
            //win = true;
            //if (mScore == 800 && mLives > 0)
            //    win = true;
            //if (mItems.Count <= 6)
            //    win = true;

            if (win)
            {
                Utility.WriteCentered("YOU WIN!");
            }
            else
            {
                Utility.WriteCentered("YOU LOST!");
            }
        }
        public Player GetPlayer()
        {
            return mPlayer;
        }
        private void Update()
        {
            mPlayer.Update();

            //if (!mPlayer.IsAlive())
            //{
            //    mGaveOver = true;
            //    return;
            //}           

            for (int i = 0; i < mItems.Count; i++)
            {
                mItems[i].Update();

                if (!mItems[i].IsAlive())
                    continue;

                if ((int)mItems[i].GetY() == (int)mPlayer.GetY())
                {
                    for (int x = (int)mPlayer.GetX(); x < mPlayer.GetX() + mPlayer.GetWidth(); ++x)
                    {
                        if ((int)mItems[i].GetX() == x)
                        {
                            mItems[i].Kill();

                            int[] color = new int[] { 1, 2, 3, 5, 8, 9 };
                            Console.BackgroundColor = (ConsoleColor)(color[Utility.Rand() % color.Length]);

                            if (mItems[i].GetItemType() == Items.Type.Tokens)
                            {
                                mScore += 100;                                                        
                            }

                            else
                            {
                               // mScore -= 100;
                                mLives--;
                            }
                            //if (mLives < 4)
                            //{                                
                            //    mPlayer.GetLives();
                            //    mGaveOver = true;

                            if (mLives == 0)
                                mGaveOver = true;
                            //else if (mScore == 800 && mLives > 0)
                            //    mGaveOver = true;
                            //else
                            break;                            
                        }  
                    }           
                }


                //if ((int)mItems[i].GetX() == (int)mPlayer.GetX() &&
                //    (int)mItems[i].GetY() == (int)mPlayer.GetY())

                //{

                //    mItems[i].Kill();
                //    mScore += 100; //Score bug because of reset on top
                //}

                //if (mItems.Count <= 0)
                //{
                if (mScore == NumItems * 100)
                    mGaveOver = true;
                //break;
                //}
            }
        }

        public void Draw()
        {
            Utility.LockConsole(true);
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.Clear();

            mPlayer.Draw();

            for (int i = 0; i < mItems.Count; i++)
                mItems[i].Draw();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 0);
            Console.Write("Score: " + mScore);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 1);
            Console.Write("Lives: " + mLives);

            Console.ForegroundColor = lastColor;
            Utility.LockConsole(false);
        }
    }
}
