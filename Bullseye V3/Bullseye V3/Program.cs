using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Bullseye_V3
{
     static class Program
    {
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
         static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            Application.Run(form1);
            
            int x = 0;
            int playerX;
            int playerY;
            Form1.UpdateBoxTwo("Wassup");
            while (true)
            {
                playerX = Cursor.Position.X;
                playerY = Cursor.Position.Y;

                Console.WriteLine($"The x of your cursor is: {playerX}.");
                Console.WriteLine($"The y of your cursor is: {playerY}.");
                Form1.UpdateBoxOne($"The x of your cursor is: {playerX}.");

                x++;
                if (x % 50 == 0)
                {
                    //Console.Clear();
                }
            }
        }
    }
}
