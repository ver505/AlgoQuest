using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlgoQuest;
using NAudio.Wave;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;
namespace AlgoQuest
{
    class modes
    {
         

        private int SelectedModes;
        private string[] Modes;


        public modes(string[] mode)
        {

            Modes = mode;
            SelectedModes = 0;
        }
        private void DisplayModesWithColor()
        {

        
            for (int i = 0; i < Modes.Length; i++)
            {
                string currentOption = Modes[i];

                if (i == SelectedModes)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.Yellow;



                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;

                }

                WriteLine(currentOption);
            }
            ResetColor();
        }

        private void DisplayStartWindowSelctWithColor()
        {

        
            for (int i = 0; i < Modes.Length; i++)
            {
                string currentOption = Modes[i];

                if (i == SelectedModes)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;



                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;

                }

                WriteLine(currentOption);
            }
            ResetColor();
        }
        public int ModesSelecting()
        {
            ConsoleKey keyPressed;


            do
            {
               
                Clear();
                Title myTitles = new Title();
                myTitles.printTitle();
                WriteLine("\t\t\t\t\t    << SELECT GAME SUBJECT MODES >>");
                WriteLine("\t\t\t  Remember : You Can't Select Subject Modes One's You already Selected One..\n\t\t\t\t  Read the ff. Rules in The Main Screen [\'How to Play\'].");             
                DisplayModesWithColor();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                string soundFilePath1 = @"C:\SelectingSound.wav";
                ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath1);

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedModes--;
                    if (SelectedModes == -1)
                    {
                        SelectedModes = 2;

                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedModes++;
                    if (SelectedModes == 3)
                    {
                        SelectedModes = 0;
                    }
                }


            } while (keyPressed != ConsoleKey.Enter);
            string soundFilePath2 = @"C:\selected.wav";
            ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath2);


            return SelectedModes;
        }

        
        public int ModesSelecting2()
        {
            ConsoleKey keyPressed;


            do
            {

                Clear();
                Title myTitles = new Title();
                myTitles.printTitle();
                WriteLine("\t\t\t\t\t    << SELECT GAME SUBJECT MODES >>");
                WriteLine("\t\t\t  Remember : You Can't Select Subject Modes One's You already Selected One..\n\t\t\t\t  Read the ff. Rules in The Main Screen [\'How to Play\'].");
                DisplayModesWithColor();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                string soundFilePath1 = @"C:\SelectingSound.wav";
                ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath1);

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedModes--;
                    if (SelectedModes == -1)
                    {
                        SelectedModes = 1;

                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedModes++;
                    if (SelectedModes == 2)
                    {
                        SelectedModes = 0;
                    }
                }


            } while (keyPressed != ConsoleKey.Enter);
            string soundFilePath2 = @"C:\selected.wav";
            ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath2);


            return SelectedModes;
        }

        public int ModesSelectingSolo()
        {
            ConsoleKey keyPressed;


            do
            {

                Clear();
                Title myTitles = new Title();
                myTitles.printTitle();
                WriteLine("\t\t\t\t\t    << SELECT GAME SUBJECT MODES >>");
                WriteLine("\t\t\t  Remember : You Can't Select Subject Modes One's You already Selected One..\n\t\t\t\t  Read the ff. Rules in The Main Screen [\'How to Play\'].");
                DisplayModesWithColor();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                string soundFilePath1 = @"C:\SelectingSound.wav";
                ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath1);

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedModes--;
                    if (SelectedModes == -1)
                    {
                        SelectedModes = 0;

                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedModes++;
                    if (SelectedModes == 1)
                    {
                        SelectedModes = 0;
                    }
                }


            } while (keyPressed != ConsoleKey.Enter);
            string soundFilePath2 = @"C:\selected.wav";
            ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath2);


            return SelectedModes;
        }


        public int forStartWindowSelection()
        {
            ConsoleKey keyPressed;


            do
            {

                Clear();
                Title myTitles = new Title();
                myTitles.startWindowTitle();
                DisplayStartWindowSelctWithColor();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                string soundFilePath1 = @"C:\SelectingSound.wav";
                ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath1);

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedModes--;
                    if (SelectedModes == -1)
                    {
                        SelectedModes = 1;

                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedModes++;
                    if (SelectedModes == 2)
                    {
                        SelectedModes = 0;
                    }
                }


            } while (keyPressed != ConsoleKey.Enter);
            string soundFilePath2 = @"C:\selected.wav";
            ThreadPool.QueueUserWorkItem(SelectingSoundInModes, soundFilePath2);


            return SelectedModes;
        }


        public void SelectingSoundInModes(object soundFilePathObj)
        {
            string soundFilePath = (string)soundFilePathObj;

            try
            {


 
                using (var audioFile = new AudioFileReader(soundFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);   
                    outputDevice.Play();  

                 
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(5);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "");
            }
        }







    }
}
