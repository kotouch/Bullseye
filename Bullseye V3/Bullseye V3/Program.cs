using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Runtime.Remoting.Messaging;
using Senparc.Weixin;

namespace Bullseye_V3
{
     static class Program
    {
        public static bool gameRunning = true;
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
                Console.WriteLine("What difficulty do you wanna play? Easy, Medium, Hard, or Hardest?");
                gameDifficulty = QuadQuestionConfirmation("easy", "medium", "hard", "hardest");
                Console.WriteLine("Do you want to see the scoreboard before we begin?");
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
                    System.Threading.Thread.Sleep(5000);
                    theGame();
                }
                else if (wannaPlay == "no" || wannaPlay == "n")
                {
                    theGame();
                }
                else
                {
                    
                }
            }
            else if (wannaPlay == "no" || wannaPlay == "n")
            {
                Console.Clear();
                Console.WriteLine("Cya");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            }
        }
        static void theGame()
        {
            Random rand = new Random();

            gameRunning = true;
            int x = 0;
            int playerX = 0;
            int playerY = 0;
            string playerClose = "uh oh";
            

            int findPointX = Convert.ToInt32(Math.Floor(Convert.ToDouble(rand.Next(1, 1921))));
            int findPointY = Convert.ToInt32(Math.Floor(Convert.ToDouble(rand.Next(1, 1081))));



            //Form1.UpdateBoxTwo("Wassup");
            var watch = new Stopwatch();
            watch.Start();
            Console.Clear();
            while (gameRunning = true)
            {




                playerX = Cursor.Position.X;
                playerY = Cursor.Position.Y;

                if (gameDifficulty == "hard" || gameDifficulty == "hardest")
                {
                    Console.Write("\r{0}                            ", $"The x and y of your cursor: ({playerX}, {playerY}). You're {playerClose}");
                }
                else if (gameDifficulty == "easy" || gameDifficulty == "medium")
                {
                    Console.Write("\r{0}                            ", $"The x and y of your cursor: ({playerX}, {playerY}). You're ({Math.Abs(playerX - findPointX)}, {Math.Abs(playerY - findPointY)}) away.");
                }
                //Console.Clear();
                if (Math.Abs(playerX - findPointX) >= 1600 || Math.Abs(playerY - findPointY) >= 900)
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
                else if (Math.Abs(playerX - findPointX) >= 1280 && Math.Abs(playerY - findPointY) >= 720 && Math.Abs(playerX - findPointX) <= 1600 && Math.Abs(playerY - findPointY) <= 900)
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
                else if (Math.Abs(playerX - findPointX) >= 960 && Math.Abs(playerY - findPointY) >= 540 && Math.Abs(playerX - findPointX) <= 1280 && Math.Abs(playerY - findPointY) <= 720)
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
                else if ((Math.Abs(playerX - findPointX) >= 640 || Math.Abs(playerY - findPointY) >= 360) && (Math.Abs(playerX - findPointX) <= 960 || Math.Abs(playerY - findPointY) <= 540))
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
                else if (Math.Abs(playerX - findPointX) >= 240 && Math.Abs(playerY - findPointY) >= 120 && Math.Abs(playerX - findPointX) <= 640 && Math.Abs(playerY - findPointY) <= 360 && (Math.Abs(playerX - findPointX) <= 40 && Math.Abs(playerY - findPointY) <= 20) != true)
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
                else if (Math.Abs(playerX - findPointX) <= 40 && Math.Abs(playerY - findPointY) <= 20)
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
                        Winner();
                    }
                    else if (gameDifficulty == "medium")
                    {
                        if (Math.Abs(playerX - findPointX) <= 30 && Math.Abs(playerY - findPointY) <= 15)
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
                    else if (gameDifficulty == "hard")
                    {
                        if (Math.Abs(playerX - findPointX) <= 10 && Math.Abs(playerY - findPointY) <= 10)
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
                        else if (Math.Abs(playerX - findPointX) == 1 && Math.Abs(playerY - findPointY) == 1)
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
                        else if (Math.Abs(playerX - findPointX) <= 4 && Math.Abs(playerY - findPointY) <= 4)
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
            gameRunning = false;
            Console.WriteLine($"Wowza, you won! And you did it all in {stopwtchTime} Would you like to record your score to the leaderboard?");
            string wannaPlay = QuadQuestionConfirmation("yes", "y", "no", "n");
            if (wannaPlay == "yes" || wannaPlay == "y")
            {
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write(Environment.NewLine);
                    //writer1.Write("scoreboard.txt");
                }
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write(playerName.ToString() + " ");
                    //writer1.Write("scoreboard.txt");
                }
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write("~~~");
                    //writer1.Write("scoreboard.txt");
                }
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write(gameDifficulty.ToString() + " ");
                    //writer1.Write("scoreboard.txt");
                }
                using (StreamWriter writer1 = new StreamWriter("scoreboard.txt", append: true))
                {
                    writer1.Write("~~~");
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
            else if (wannaPlay == "no" || wannaPlay == "n")
            {
                Console.WriteLine("Ahh, a humble man.");
            }
            Console.WriteLine("Would you like to play again under the same difficulty and name?");
            wannaPlay = QuadQuestionConfirmation("yes", "y", "no", "n");
            if (wannaPlay == "yes" || wannaPlay == "y")
            {
                theGame();
            }
            else
            {
                Console.WriteLine("OK bye");
                Environment.Exit(0);
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
