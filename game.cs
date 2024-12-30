using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AlgoQuest;
using MySql.Data.MySqlClient;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

using System.Data.SqlClient;
using Google.Protobuf.WellKnownTypes;
using System.Net.Sockets;
using Google.Protobuf;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading;
using NAudio.Wave;
using System.Media;
using System.IO;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using Mysqlx.Crud;
using System.Collections;
using MySqlX.XDevAPI.Common;
using NAudio.CoreAudioApi;

namespace AlgoQuest
{
    class game
    {

        int id = 0;
        string modes = "";

        int holderPoints = 0;
        int Eattempt = 1, Mattempt = 1, Hattempt = 1;
        string isSelected = "";
        string check = " ";
        int easyPoints = 0, mediumPoints = 0, hardPoints = 0;
        int easyCounter = 0, mediumCounter = 0, hardCounter = 0;

        string[] options2 = { "\n\n\n\t\t\tEasy", "\t\t\tMedium", "\t\t\tHard" };


        string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, uint extraInfo);

        const byte ALT_KEY = 0x12;
        const byte ENTER_KEY = 0x0D;
        const uint KEY_PRESS = 0x0000;
        const uint KEY_RELEASE = 0x0002;

        //-------------------------------------- CALLING OTHER CLASS -------------------------------------------------



        Title myTitles = new Title();

        



        //---------------------------------------------------------------------------------------


        public void Start()
        {

            System.Console.OutputEncoding = System.Text.Encoding.Unicode;
            RunFirstMenu();

        }



        public void RunFirstMenu()
        {
            ForegroundColor = ConsoleColor.Red;


            string title = @" 

                         █████╗ ██╗      ██████╗  ██████╗  ██████╗ ██╗   ██╗███████╗███████╗████████╗
                        ██╔══██╗██║     ██╔════╝ ██╔═══██╗██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
                        ███████║██║     ██║  ███╗██║   ██║██║   ██║██║   ██║█████╗  ███████╗   ██║   
                        ██╔══██║██║     ██║   ██║██║   ██║██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   
                        ██║  ██║███████╗╚██████╔╝╚██████╔╝╚██████╔╝╚██████╔╝███████╗███████║   ██║   
                        ╚═╝  ╚═╝╚══════╝ ╚═════╝  ╚═════╝  ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   
                                                                       ";

            Console.WriteLine(title);
            Console.WriteLine("\t\t\t\t\t      PRESS ANY KEY TO REVEAL MENU.");
            ConsoleKeyInfo keyPressed = ReadKey();
            string[] options = { "\n\n\n\t\t\tNew Game", "\t\t\tLoad Game", "\t\t\tHow to Play", "\t\t\tLeaderboards", "\t\t\tExit" };
            Menu mainMenu = new Menu(options);
            int selectedMenu = mainMenu.Run();

            string soundFilePath2 = @"C:\selected.wav";
     
            switch (selectedMenu)
            {
                case 0:
                    ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);

                    NewGame ng = new NewGame();
                    ng.SelectedNewGame();
                    break;
                case 1:
                    ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);

                    LoadGame ld = new LoadGame();
                    ld.SelectedLoadGame();
                    break;
                case 2:
                    ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);

                    SelectedHowToPlay();
                    break;
                case 3:
                    ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);

                    leaderboards lb = new leaderboards();
                    lb.Leaderboards();
                    break;
                case 4:
                    SelectedExit();
                    break;


            }
        }


 


        private void SelectedHowToPlay()
        {
            Clear();
            WriteLine("\t\t\t Game has 3 Modes : [History of Programming]  [Debugging]  [Guess The Output]");
            WriteLine("\n\t\t\t Each Modes have 3 Correspanding Difficulties : [Easy]  [Medium]  [Hard]\n");
            //WriteLine("\nThere are :\n\t\t 6 Questions in Easy\n\t\t 5 Questions in Medium\n\t\t 4 Questions in Easy\n");
            WriteLine("\t\t\t\t   Required Points To Unlock Next Difficulties \n\n\t\t\t\t   6 points for Easy To Unlock Medium\n\t\t\t\t   8 points for Medium To Unlock Hard\n\t\t\t\t   12 points for Hard to Passed The Selected Mode \n\t\t\t\t   And Be Able To Choose modes You Want Again.\n");
            WriteLine("\t\t\t\t\t\t    << REMEMBER >>  \n\n\t\t\t\t   When You Select The Modes You Want, You Need To Finish it\n\t\t\t\t      After That You Can Choose The Remaining Modes Again\n");

            //////// in game rules erp
            WriteLine("\t\t\t\t\t\t  << INGAME RULES >>\n");
            WriteLine("\t\t\t\t\t\t      - POINTS -");
            WriteLine("\t\t\t\t      In Every Correct Answer You Will Receive :\n" +
                " \n\t\t\t\t      Easy - 1 Points For Each Correct Answer" +
                " \n\t\t\t\t      Medium - 2 Points For Each Correct Answer" +
                " \n\t\t\t\t      Hard - 3 Points For Each Correct Answer");

            Write("\n\n\t\t\t\t  << PRESS ANY KEY TO GO BACK TO THE MAIN SCREEN! >>");

            ReadKey(true);
            Console.Clear();
            RunFirstMenu();




        }

        public void loadingScreen()
        {
            Thread.Sleep(500);

            string soundFilePath2 = @"C:\loadingSound.wav";
            ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
            //  Console.BackgroundColor = ConsoleColor.White;
            string[] loadingChars = { "/", "-", "\\", "|" };
            int index = 0;
            int loadingLength = 60;

            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            Console.Clear();


            // Center the initial message

            Console.ForegroundColor = ConsoleColor.Red;
            int paddingX = (consoleWidth - "   THE GAME WILL START...".Length) / 2;
            Console.SetCursorPosition(paddingX, consoleHeight / 4); // Vertically center
            Console.WriteLine("   THE GAME WILL START...");

            // Center the loading bar and percentage
            for (int i = 0; i < loadingLength; i++)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, consoleHeight / 2); // Vertically center
                int percentagePadding = (consoleWidth - ("Loading... " + (i + 1) * 100 / loadingLength).Length) / 2;
                Console.SetCursorPosition(percentagePadding, consoleHeight / 2);
                int completed = (i + 1) * 100 / loadingLength;

                Console.ForegroundColor = ConsoleColor.Yellow;

                if (completed >= 100)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Completed... {0,3}%", completed);

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // Replace the "THE GAME WILL START..." message with "PRESS ANY KEY TO START."
                    string completedMessage = "   PRESS ANY KEY TO START.";
                    int finalMessagePadding = (consoleWidth - completedMessage.Length) / 2;
                    Console.SetCursorPosition(finalMessagePadding, consoleHeight / 4); // Vertically center



                    Console.WriteLine("   PRESS ANY KEY TO START.");

                    while (true)
                    {
                        var key = Console.ReadKey(intercept: true);  // intercept prevents the key from being displayed
                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }





                    }

                }
                else
                {
                    Console.WriteLine("Loading... {0,3}%", completed);


                }




                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, consoleHeight / 2 + 1);
                string loadingBar = "▓".PadRight(i + 1, '▓') + " " + loadingChars[index];
                int loadingBarPadding = (consoleWidth - loadingBar.Length) / 2;
                Console.SetCursorPosition(loadingBarPadding, consoleHeight / 2 + 1);
                Console.WriteLine(loadingBar);

                index = (index + 1) % loadingChars.Length;

                Thread.Sleep(50);


            }


        }


        public void SelectedExit()
        {
            Console.Write("\n\t\t\tPress any Key to Exit....");
            ReadKey(true);
            Environment.Exit(0);

            Console.ReadKey();


        }


        public void fullscreen()
        {
            keybd_event(ALT_KEY, 0, KEY_PRESS, 0);
            keybd_event(ENTER_KEY, 0, KEY_PRESS, 0);
            keybd_event(ENTER_KEY, 0, KEY_RELEASE, 0);
            keybd_event(ALT_KEY, 0, KEY_RELEASE, 0);
        }











         


        //-------------------------------------------------------------  QUESTIONAIRE BASE ON MODES AND DIFFICULTIES    -------------------------------------------------------------------------------------------



        public void HistoryGAme()
        {
            string updateQuery = "UPDATE tbinsert SET MODES = @newModes, DIFFICULTIES = @newDiff WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

            using (MySqlConnection myConn = new MySqlConnection(mycon))
            {
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                myConn.Open();
                updateCommand.Parameters.AddWithValue("@newModes", "History of Programming");
                updateCommand.Parameters.AddWithValue("@newDiff", "Easy");
              

                updateCommand.ExecuteNonQuery();
            }
            Clear();
            fullscreen();
            loadingScreen();


            myTitles.actualGameTitle();

            History_of_Programming_Questionare HistoryQ = new History_of_Programming_Questionare();
            HistoryQ.actualGameHistory();

            string soundFilePath2 = @"C:\ingameSound.wav";
            ThreadPool.QueueUserWorkItem(methodSoundsLoop, soundFilePath2);


        
                HistoryQ.easyHistoryQuestionaire();

        


        }



        public void SpotGAme()
        {


            string updateQuery = "UPDATE tbinsert SET MODES = @newModes, DIFFICULTIES = @newDiff WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

            using (MySqlConnection myConn = new MySqlConnection(mycon))
            {
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                myConn.Open();
                updateCommand.Parameters.AddWithValue("@newModes", "Spot The Error");
                updateCommand.Parameters.AddWithValue("@newDiff", "Easy");
 
                
                updateCommand.ExecuteNonQuery();
            }

            Clear();
            fullscreen();
            loadingScreen();
           

            myTitles.actualGameTitle();

            Spot_The_Error_Questionare SpotQ = new Spot_The_Error_Questionare();
            SpotQ.actualGameSpot();

            string soundFilePath2 = @"C:\ingameSound.wav";
            ThreadPool.QueueUserWorkItem(methodSoundsLoop, soundFilePath2);


          
                SpotQ.easySpotQuestionaire();

           
            


        }


        public void GuessGAme()
        {

            string updateQuery = "UPDATE tbinsert SET MODES = @newModes, DIFFICULTIES = @newDiff WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

            using (MySqlConnection myConn = new MySqlConnection(mycon))
            {
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                myConn.Open();
                updateCommand.Parameters.AddWithValue("@newModes", "Guess The Output");
                updateCommand.Parameters.AddWithValue("@newDiff", "Easy");

                updateCommand.ExecuteNonQuery();
            }

            Clear();
            fullscreen();
            loadingScreen();


            myTitles.actualGameTitle();
            Guess_The_Output_Questionare GuessQ = new Guess_The_Output_Questionare();
            GuessQ.actualGameGuess();
            string soundFilePath2 = @"C:\ingameSound.wav";
            ThreadPool.QueueUserWorkItem(methodSoundsLoop, soundFilePath2);


           
                GuessQ.easyGuessQuestionaire();
      


        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        public void actualGame()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            myTitles.actualGameTitle();

            int points = 0;



            try
            {
                string query = "SELECT ID, USER, MODES, DIFFICULTIES, POINTS FROM tbinsert WHERE ID = (SELECT MAX(ID) FROM tbinsert)";
                string mycon2 = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                using (MySqlConnection myConn = new MySqlConnection(mycon2))
                {
                    MySqlCommand myCommand = new MySqlCommand(query, myConn);
                    myConn.Open();

                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row is returned
                        {
                            // Retrieve values from the row
                            id = Convert.ToInt32(reader["ID"]);
                            string username = reader["USER"].ToString();
                            string modes = reader["MODES"].ToString();
                            string difficulties = reader["DIFFICULTIES"].ToString();
                            points = Convert.ToInt32(reader["POINTS"]);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            WriteLine("\n\n\t\t\t| USERNAME: " + username);
                            WriteLine("\t\t\t| USER ID: " + id);
                            WriteLine("\n\n\t\t\t| MODE: " + modes);
                            WriteLine("\t\t\t| DIFFICULTY: " + difficulties);


                            
                            reader.Close();  
                        }
                        else
                        {
                            Console.WriteLine("No data found in the table.");
                            return;
                        }
                    }

               


                    if (isSelected.Equals(""))
                    {
                        if (Eattempt >= 2)
                        {
                            easyPoints -= 1;
                            Eattempt--;

                        }

                        if (easyPoints == 0)
                        {
                            holderPoints = points;  
                            WriteLine("\n\n\t\t\t| POINTS: " + holderPoints);
                        }
                        else
                        {
                            holderPoints = points + easyPoints;
                            WriteLine("\n\n\t\t\t| POINTS: " + holderPoints);
                            Eattempt++;
                        }
                    }
                    else if (isSelected.Equals("Medium"))
                    {

                        if (Mattempt >= 2)
                        {
                            mediumPoints -= 2;
                            Mattempt--;
                            
                        }

                        if (mediumPoints == 0)
                        {
                            holderPoints = points;
                            WriteLine("\n\n\t\t\t| POINTS: " + holderPoints);


                        }
                        else

                        {


                            holderPoints = points + mediumPoints;

                            WriteLine("\n\n\t\t\t| POINTS: " + holderPoints);
                            Mattempt++;
                        }


                    }
                    else if (isSelected.Equals("Hard"))
                    {
                        if (Hattempt >= 2)
                        {
                            hardPoints -= 3;
                            Hattempt--;

                        }

                        if (hardPoints == 0)
                        {
                            holderPoints = points;
                            WriteLine("\n\n\t\t\t| POINTS: " + holderPoints);


                        }
                        else

                        {


                            holderPoints = points + hardPoints;

                            WriteLine("\n\n\t\t\t| POINTS: " + holderPoints);
                            Hattempt++;
                        }
                    }

                    // Now update the points in the database
                    string updateQuery = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn))
                    {
                        // Use the calculated holderPoints for updating
                        updateCommand.Parameters.AddWithValue("@newPoints", holderPoints);
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void ForEnteringTheNameSounds(object soundFilePathObj)
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


        static void methodSoundsLoop(object soundFilePath)
        {
            string filePath = (string)soundFilePath;
            SoundPlayer soundPlayer = new SoundPlayer(filePath);

            // Loop the sound
            while (true)
            {
                try
                {
                    soundPlayer.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error playing sound: " + ex.Message);
                    break;
                }
            }

        }

       



    }
}
