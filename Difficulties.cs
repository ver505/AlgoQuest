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
    class Difficulties
    {


        private int SelectedModes;
        private string[] Modes;


        public Difficulties(string[] mode)
        {

            Modes = mode;
            SelectedModes = 0;
        }
        private void DisplayDiffWithColor()
        {

            // Console.Clear();
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
        public int DiffSelecting()
        {
            ConsoleKey keyPressed;


            do
            {
                

                Clear();
                Title myTitles = new Title();
                myTitles.printTitle();
                WriteLine("\t\t\t\t\t   << SELECT GAME MODE DIFFICULTIES >>");
                DisplayDiffWithColor();

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


            return SelectedModes;
        }




        public void SelectingSoundInModes(object soundFilePathObj)
        {
            string soundFilePath = (string)soundFilePathObj;

            try
            {


                // Using AudioFileReader to read the sound file and WaveOutEvent for playback
                using (var audioFile = new AudioFileReader(soundFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);  // Initialize the output device with the audio file
                    outputDevice.Play();  // Start playback

                    // Wait until the sound finishes (just to give time for playback)
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
