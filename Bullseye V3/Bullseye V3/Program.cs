﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Bullseye_V3
{
     static class Program
    {
        public static string gameDifficulty = "hard";
        public static string playerName = "boob";
        public static string userInput = "null";
        public static string stopwtchTime;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
         static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form1 form1 = new Form1();
            //Application.Run(form1);
            Console.WriteLine("Hello Player! What is your name?");
            playerName = Console.ReadLine();
            Console.WriteLine($"Nice to meet you {playerName}. Would you like to start the game? Yes or No?");
            string wannaPlay = QuadQuestionConfirmation("yes", "y", "no", "n");
            if (wannaPlay == "yes" || wannaPlay == "y")
            {
                Console.WriteLine("What difficulty do you wanna play? Easy, Medium, Hard, or Hardest? FYI: Hardest as of now is the only truely functioning difficulty.");
                gameDifficulty = QuadQuestionConfirmation("easy", "medium", "hard", "hardest");
                theGame();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cya");
            }
        }
        static void theGame()
        {
            Random rand = new Random();

            bool gameRunning = true;
            int x = 0;
            int playerX = 0;
            int playerY = 0;
            string playerClose = "uh oh";
            

            int findPointX = Convert.ToInt32(Math.Floor(Convert.ToDouble(rand.Next(1, 1921))));
            int findPointY = Convert.ToInt32(Math.Floor(Convert.ToDouble(rand.Next(1, 1081))));



            //Form1.UpdateBoxTwo("Wassup");
            var watch = new Stopwatch();
            watch.Start();

            while (gameRunning = true)
            {

                
                

                playerX = Cursor.Position.X;
                playerY = Cursor.Position.Y;

                
                Console.Write("\r{0}                            ", $"{findPointX} {findPointY} The x and y of your cursor: ({playerX}, {playerY}). You're {playerClose}");

                //Console.Clear();
                if (Math.Abs(playerX - findPointX) >= 1600 || Math.Abs(playerX - findPointX) >= 900)
                {
                    if (Math.Abs(playerX - findPointX) > Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Cold! Too far left or right.";
                    }
                    else if (Math.Abs(playerX - findPointX) < Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Cold! Too far up or down.";
                    }
                    else
                    {
                        playerClose = "Cold!";
                        
                    }
                }
                else if (Math.Abs(playerX - findPointX) >= 1280 && Math.Abs(playerX - findPointX) >= 720)
                {
                    if (Math.Abs(playerX - findPointX) > Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Warmish? Too far left or right.";
                    }
                    else if (Math.Abs(playerX - findPointX) < Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Warmish? Too far up or down.";
                    }
                    else
                    {
                        playerClose = "Warmish?";

                    }
                }
                else if (Math.Abs(playerX - findPointX) >= 960 && Math.Abs(playerX - findPointX) >= 540)
                { 
                    if (Math.Abs(playerX - findPointX) > Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Warm. Too far left or right.";
                    }
                    else if (Math.Abs(playerX - findPointX) < Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Warm. Too far up or down.";
                    }
                    else
                    {
                        playerClose = "Warm";

                    }
                }
                else if (Math.Abs(playerX - findPointX) >= 640 && Math.Abs(playerX - findPointX) >= 360)
                {
                    if (Math.Abs(playerX - findPointX) > Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Hot. Too far left or right.";
                    }
                    else if (Math.Abs(playerX - findPointX) < Math.Abs(playerY - findPointY))
                    {
                        playerClose = "Hot. Too far up or down.";
                    }
                    else
                    {
                        playerClose = "Hot";

                    }
                }
                else if (Math.Abs(playerX - findPointX) >= 240 && Math.Abs(playerX - findPointX) >= 120)
                {
                    if (Math.Abs(playerX - findPointX) > Math.Abs(playerY - findPointY))
                    {
                        playerClose = "RED HOT! Too far left or right.";
                    }
                    else if (Math.Abs(playerX - findPointX) < Math.Abs(playerY - findPointY))
                    {
                        playerClose = "RED HOT! Too far up or down.";
                    }
                    else
                    {
                        playerClose = "RED HOT!";

                    }
                    
                }
                else if (Math.Abs(playerX - findPointX) >= 40 && Math.Abs(playerX - findPointX) >= 20)
                {
                    if (gameDifficulty == "easy")
                    {
                        playerClose = "You got it!";
                        gameRunning = false;
                        watch.Stop();
                        TimeSpan ts = watch.Elapsed;
                        stopwtchTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    }
                    else if (gameDifficulty == "medium")
                    {
                        if (Math.Abs(playerX - findPointX) >= 30 && Math.Abs(playerX - findPointX) >= 15)
                        {
                            playerClose = "You got it!";
                            gameRunning = false;
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            stopwtchTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        }
                    }
                    else if (gameDifficulty == "hard")
                    {
                        if (Math.Abs(playerX - findPointX) >= 10 && Math.Abs(playerX - findPointX) >= 5)
                        {
                            playerClose = "You got it!";
                            gameRunning = false;
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            stopwtchTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                            Winner();
                        }
                    }
                    else if (gameDifficulty == "hardest")
                    {
                        if (playerX == findPointX && playerY == findPointY)
                        {
                            playerClose = "You got it!";
                            gameRunning = false;
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            stopwtchTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                            Winner();
                        }
                        else if (Math.Abs(playerX - findPointX) == 1 || Math.Abs(playerX - findPointX) == 1)
                        {
                            playerClose = "You got it!";
                            gameRunning = false;
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            stopwtchTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                            Winner();
                        }
                        else if (Math.Abs(playerX - findPointX) <= 8 || Math.Abs(playerX - findPointX) <= 8)
                        {
                            playerClose = "You got it!";
                            gameRunning = false;
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            stopwtchTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                            Winner();
                        }
                    }
                }

                x++;
                if (x % 10 == 0)
                {
                    //Console.Clear();
                }
            }
            playerClose = "a winner!";
            Console.ReadLine();
        }
        static void Winner()
        {
            Console.Clear();
           
            Console.WriteLine($"Wowza, you won! And you did it all in {stopwtchTime} Would you like to record your score to the leaderboard?");
            string wannaPlay = QuadQuestionConfirmation("yes", "y", "no", "n");
            if (wannaPlay == "yes" || wannaPlay == "y")
            {
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write(playerName.ToString() + " ");
                    //writer1.Write("scoreboard.txt");
                }
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write(gameDifficulty.ToString() + " ");
                    //writer1.Write("scoreboard.txt");
                }
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write(stopwtchTime.ToString() + " ");
                    //writer1.Write("scoreboard.txt");
                }
               
                Console.WriteLine("Do you want to see the current scoreboard?");
                wannaPlay = QuadQuestionConfirmation("yes", "y", "no", "n");
                if (wannaPlay == "yes" || wannaPlay == "y")
                {
                    int counter = 0;
                    string line;

                    // Read the file and display it line by line.  
                    System.IO.StreamReader file =
                        new System.IO.StreamReader("scoreboard.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        System.Console.WriteLine(line);
                        counter++;
                    }

                    file.Close();
                }
                

                // write a line of text to the file
                
            }
            else
            {
                Console.WriteLine("Ahh, a humble man.");
            }
        }

        public static string QuadQuestionConfirmation(string optionOne, string optionTwo, string optionThree, string optionFour)
        {
            userInput = Console.ReadLine();
            if (userInput.ToLower() == optionOne.ToLower())
            {

                return optionOne;
            }
            else if (userInput.ToLower() == optionTwo.ToLower())
            {

                return optionTwo;
            }
            else if (userInput.ToLower() == optionThree.ToLower())
            {

                return optionThree;
            }
            else if (userInput.ToLower() == optionFour.ToLower())
            {

                return optionFour;
            }
            else if (userInput.ToLower() != optionOne.ToLower() || userInput.ToLower() != optionTwo.ToLower() || userInput.ToLower() != optionThree.ToLower() || userInput.ToLower() != optionFour.ToLower())
            {

                Console.WriteLine("Please input a valid answer.");
                //QuestionConfirmationStopper = true;
                QuadQuestionConfirmation(optionOne, optionTwo, optionThree, optionFour);
                return "error";
            }
            else
            {
                return "error";
            }

        }
     }
}
