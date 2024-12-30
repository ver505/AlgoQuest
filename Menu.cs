using System;
using System.Media;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlgoQuest;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
namespace AlgoQuest

{
     class Menu
    {

        

        private int SelectedMenu;
        private string[] Options;


        public Menu(string[] options)
        {

            Options = options;                   
            SelectedMenu = 0;
        }
        private void DisplayOptions()
        {
            // Console.Clear();
            for (int i = 0; i < Options.Length; i++)
            {
                
                string currentOption = Options[i];

                if (i == SelectedMenu)
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



        public int Run()
        {
            ConsoleKey keyPressed;

           

            do
                {
                    // Console.BackgroundColor = ConsoleColor.Yellow;

                    Clear();
                    Title myTitles = new Title();
                    myTitles.printTitle();
                    DisplayOptions();

                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;



                string soundFilePath1 = @"C:\SelectingSound.wav";
                ThreadPool.QueueUserWorkItem(SelectingSound, soundFilePath1);



                if (keyPressed == ConsoleKey.UpArrow)
                    {
                        SelectedMenu--;
                        if (SelectedMenu == -1)
                        {
                            SelectedMenu = 4;

                        }
                   
                }
                    else if (keyPressed == ConsoleKey.DownArrow)
                    {
                        SelectedMenu++;
                        if (SelectedMenu == 5)
                        {
                            SelectedMenu = 0;
                        }
                    
                }


             

            }
           while (keyPressed != ConsoleKey.Enter);
            




            return SelectedMenu;
        }



        public void SelectingSound(object soundFilePathObj)
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
                Console.WriteLine(ex+"");
            }
        }



    }
}
