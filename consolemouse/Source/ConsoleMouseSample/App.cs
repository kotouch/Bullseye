//jmedved.com

using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleMouseSample {
    class App {
        
        public static string userInput = "k";
        public static bool gameRunning = true;
        public static string gameDifficulty;
        static void Main(string[] args) {
            Random rand = new Random();
            var handle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);
            //Josh Code
            Console.WriteLine("Welcome to Bullseye! The objective of the game is to try to hit the bullseye with hot and cold indicators helping.");
            Console.WriteLine("Before we start, make sure that your console is in full screen.");
            int findPointX = Convert.ToInt32(Math.Floor(Convert.ToDouble(rand.Next(1, 237))));
            int findPointY = Convert.ToInt32(Math.Floor(Convert.ToDouble(rand.Next(1, 64))));
            Console.WriteLine($"EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE {findPointX} and {findPointY}");









            //Josh Code
            int mode = 0;
            if (!(NativeMethods.GetConsoleMode(handle, ref mode))) { throw new Win32Exception(); }

            mode |= NativeMethods.ENABLE_MOUSE_INPUT;
            mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE;
            mode |= NativeMethods.ENABLE_EXTENDED_FLAGS;

            if (!(NativeMethods.SetConsoleMode(handle, mode))) { throw new Win32Exception(); }

            var record = new NativeMethods.INPUT_RECORD();
            uint recordLen = 0;
            while (true) {
                if (!(NativeMethods.ReadConsoleInput(handle, ref record, 1, ref recordLen))) { throw new Win32Exception(); }
                Console.SetCursorPosition(0, 0);
                switch (record.EventType) {
                    case NativeMethods.MOUSE_EVENT: {

                            Console.WriteLine(string.Format("    X ...............:   {0,4:0}  ", record.MouseEvent.dwMousePosition.X));
                            Console.WriteLine(string.Format("    Y ...............:   {0,4:0}  ", record.MouseEvent.dwMousePosition.Y));
                            Console.WriteLine(string.Format("    dwButtonState ...: 0x{0:X4}  ", record.MouseEvent.dwButtonState));
                            Console.WriteLine(string.Format("    dwControlKeyState: 0x{0:X4}  ", record.MouseEvent.dwControlKeyState));
                            Console.WriteLine(string.Format("    dwEventFlags ....: 0x{0:X4}  ", record.MouseEvent.dwEventFlags));
                        } break;

                    case NativeMethods.KEY_EVENT: {


                            if (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Escape) { return; }
                        } break;
                }
                //positives
                if ((record.MouseEvent.dwMousePosition.X - findPointX) >= 200  && (record.MouseEvent.dwMousePosition.Y - findPointY) >= 60 && (record.MouseEvent.dwMousePosition.X - findPointX) > 0)
                {
                    Console.WriteLine("Cold!");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= 160 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= 50 && (record.MouseEvent.dwMousePosition.X - findPointX) > 0)
                {
                    Console.WriteLine("Warmer?");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= 120 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= 40 && (record.MouseEvent.dwMousePosition.X - findPointX) > 0)
                {
                    Console.WriteLine("Warm");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= 80 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= 30 && (record.MouseEvent.dwMousePosition.X - findPointX) > 0)
                {
                    Console.WriteLine("Hot");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= 40 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= 20 && (record.MouseEvent.dwMousePosition.X - findPointX) > 0)
                {
                    Console.WriteLine("RED HOT!");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= 20 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= 10 && (record.MouseEvent.dwMousePosition.X - findPointX) > 0)
                {
                    Console.WriteLine("IT BURNS!!!");
                }
                //negatives
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= -200 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= -100 && (record.MouseEvent.dwMousePosition.X - findPointX) < 0)
                {
                    Console.WriteLine("Warmer?");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= -160 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= -50 && (record.MouseEvent.dwMousePosition.X - findPointX) < 0)
                {
                    Console.WriteLine("Warmer?");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= -120 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= -40 && (record.MouseEvent.dwMousePosition.X - findPointX) < 0)
                {
                    Console.WriteLine("Warm");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= -80 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= -30 && (record.MouseEvent.dwMousePosition.X - findPointX) < 0)
                {
                    Console.WriteLine("Hot");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= -40 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= -20 && (record.MouseEvent.dwMousePosition.X - findPointX) < 0)
                {
                    Console.WriteLine("RED HOT!");
                }
                else if ((record.MouseEvent.dwMousePosition.X - findPointX) >= -20 && (record.MouseEvent.dwMousePosition.Y - findPointY) >= -10 && (record.MouseEvent.dwMousePosition.X - findPointX) < 0)
                {
                    Console.WriteLine("IT BURNS!!!");
                } 
                else if (record.MouseEvent.dwMousePosition.X == findPointX && record.MouseEvent.dwMousePosition.Y == findPointY)
                {
                    Console.WriteLine("YOU GOT IT!");
                }
                else
                {

                }
            }
            
        }


        private class NativeMethods {

            public const Int32 STD_INPUT_HANDLE = -10;

            public const Int32 ENABLE_MOUSE_INPUT = 0x0010;
            public const Int32 ENABLE_QUICK_EDIT_MODE = 0x0040;
            public const Int32 ENABLE_EXTENDED_FLAGS = 0x0080;

            public const Int32 KEY_EVENT = 1;
            public const Int32 MOUSE_EVENT = 2;


            [DebuggerDisplay("EventType: {EventType}")]
            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT_RECORD {
                [FieldOffset(0)]
                public Int16 EventType;
                [FieldOffset(4)]
                public KEY_EVENT_RECORD KeyEvent;
                [FieldOffset(4)]
                public MOUSE_EVENT_RECORD MouseEvent;
            }

            [DebuggerDisplay("{dwMousePosition.X}, {dwMousePosition.Y}")]
            public struct MOUSE_EVENT_RECORD {
                public COORD dwMousePosition;
                public Int32 dwButtonState;
                public Int32 dwControlKeyState;
                public Int32 dwEventFlags;
            }

            [DebuggerDisplay("{X}, {Y}")]
            public struct COORD {
                public UInt16 X;
                public UInt16 Y;
            }

            [DebuggerDisplay("KeyCode: {wVirtualKeyCode}")]
            [StructLayout(LayoutKind.Explicit)]
            public struct KEY_EVENT_RECORD {
                [FieldOffset(0)]
                [MarshalAsAttribute(UnmanagedType.Bool)]
                public Boolean bKeyDown;
                [FieldOffset(4)]
                public UInt16 wRepeatCount;
                [FieldOffset(6)]
                public UInt16 wVirtualKeyCode;
                [FieldOffset(8)]
                public UInt16 wVirtualScanCode;
                [FieldOffset(10)]
                public Char UnicodeChar;
                [FieldOffset(10)]
                public Byte AsciiChar;
                [FieldOffset(12)]
                public Int32 dwControlKeyState;
            };


            public class ConsoleHandle : SafeHandleMinusOneIsInvalid {
                public ConsoleHandle() : base(false) { }

                protected override bool ReleaseHandle() {
                    return true; //releasing console handle is not our business
                }
            }


            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean GetConsoleMode(ConsoleHandle hConsoleHandle, ref Int32 lpMode);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            public static extern ConsoleHandle GetStdHandle(Int32 nStdHandle);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean ReadConsoleInput(ConsoleHandle hConsoleInput, ref INPUT_RECORD lpBuffer, UInt32 nLength, ref UInt32 lpNumberOfEventsRead);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean SetConsoleMode(ConsoleHandle hConsoleHandle, Int32 dwMode);

        }
        //Josh Code
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
            else if(userInput.ToLower() == optionFour.ToLower())
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
        //Josh Code
    }
}