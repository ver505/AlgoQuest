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
     class ProcessOfModesSelection
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




        //-------------------------------------- CALLING OTHER CLASS -------------------------------------------------


        
        Title myTitles = new Title();

        game myGame = new game();



        //---------------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void ModesSelectionCondition()
        {

            string read = "SELECT HISTORYCOUNTER, SPOTCOUNTER, GUESSCOUNTER, DONE FROM tbinsert WHERE ID = (SELECT MAX(ID) FROM tbinsert)";
            string done = "";
            string username = "";
            int historyCounter = 0, spotCounter = 0, guessCounter = 0;

            using (MySqlConnection myConn = new MySqlConnection(mycon))
            {
                MySqlCommand myCommand = new MySqlCommand(read, myConn);
                myConn.Open();

                using (MySqlDataReader reader = myCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Retrieve the values from the columns
                        username = reader["DONE"].ToString();
                        done = reader["DONE"].ToString();
                        historyCounter = Convert.ToInt32(reader["HISTORYCOUNTER"]);
                        spotCounter = Convert.ToInt32(reader["SPOTCOUNTER"]);
                        guessCounter = Convert.ToInt32(reader["GUESSCOUNTER"]);




                        //----------------------------------- end of the game


                        if (done.Equals("SELECT_H") && historyCounter == 1 && spotCounter == 1 && guessCounter == 1)
                        {

                            myTitles.finishedAll();
                            Write("\n\n\t\t\t\t\t\t\t\t\t\t\t  << PRESS ANY KEY TO GO BACK TO THE MAIN SCREEN >>");
                            ReadKey(true);
                            Console.Clear();
                            myGame.fullscreen();
                            myGame.RunFirstMenu();


                            //----------------------------------- SpotAndGuess

                        }
                        else if (done.Equals("SELECT_H") && spotCounter == 1)
                        {
                            GuessOnly();
                        }
                        else if (done.Equals("SELECT_H") && guessCounter == 1)
                        {
                            SpotOnly();
                        }
                        else if (done.Equals("SELECT_H"))
                        {
                            SpotAndGuess();
                        }





                        //----------------------------------- end of the game


                        if (done.Equals("SELECT_S") && historyCounter == 1 && spotCounter == 1 && guessCounter == 1)
                        {
                            myTitles.finishedAll();
                            Write("\n\n\t\t\t\t\t\t\t\t\t\t\t  << PRESS ANY KEY TO GO BACK TO THE MAIN SCREEN >>");
                            ReadKey(true);
                            Console.Clear();
                            myGame.fullscreen();
                            myGame.RunFirstMenu();

                            //-----------------------------------  HistoryAndGuess 

                        }
                        else if (done.Equals("SELECT_S") && historyCounter == 1)
                        {
                            GuessOnly();
                        }
                        else if (done.Equals("SELECT_S") && guessCounter == 1)
                        {
                            HistoryOnly();
                        }
                        else if (done.Equals("SELECT_S"))
                        {
                            HistoryAndGuess();
                        }






                        //----------------------------------- end of the game


                        if (done.Equals("SELECT_G") && historyCounter == 1 && spotCounter == 1 && guessCounter == 1)
                        {
                            myTitles.finishedAll();
                            Write("\n\n\t\t\t\t\t\t\t\t\t\t\t  << PRESS ANY KEY TO GO BACK TO THE MAIN SCREEN >>");
                            ReadKey(true);
                            Console.Clear();
                            myGame.fullscreen();
                            myGame.RunFirstMenu();

                            //----------------------------------- HistoryAndSpot


                        }
                        else if (done.Equals("SELECT_G") && historyCounter == 1)
                        {
                            SpotOnly();
                        }
                        else if (done.Equals("SELECT_G") && spotCounter == 1)
                        {
                            HistoryOnly();
                        }
                        else if (done.Equals("SELECT_G"))
                        {
                            HistoryAndSpot();
                        }

                        //-----------------------------------
                        //-----------------------------------









                    }
                }
            }
        }




        //--------------------------------------------------------------SELECTING MODES AGAIN 2 OPTION --------------------------------------------------------------------------------------

        string[] options2_1 = { "\n\n\n\t\t\tSpot the Error", "\t\t\tGuess the Output" };


        public void SpotAndGuess()
        {
            myGame.fullscreen();
            Console.Clear();
            myTitles.printTitle();

            try
            {
                string soundFilePath2 = @"C:\selected.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);



                modes mainModes = new modes(options2_1);
                int selectedMode = mainModes.ModesSelecting2();


                if (selectedMode == 0)
                {
                    modes = "Spot The Error";
                }
                else if (selectedMode == 1)
                {
                    modes = "Guess The Output";
                }

                Console.Clear();


                while (true)
                {
                    Console.Clear();
                    myTitles.printTitle();
                    Difficulties mainDiff = new Difficulties(options2);
                    int selectedDiff = mainDiff.DiffSelecting();

                    if (selectedDiff == 0)
                    {
                        if (modes.Equals("Spot The Error"))
                        {

                            isSelected = "SpotEasy";

                        }
                        else if (modes.Equals("Guess The Output"))
                        {

                            isSelected = "GuessEasy";

                        }

                        soundFilePath2 = @"C:\selected.wav";
                        ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);


                    }
                    else if (selectedDiff == 1)
                    {
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy Mode To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;

                    }
                    else if (selectedDiff == 2)
                    {

                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy & Medium Modes To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;

                    }

                    if (modes.Equals("Spot The Error"))
                    {
                        myGame.SpotGAme();


                    }
                    else if (modes.Equals("Guess The Output"))
                    {
                        myGame.GuessGAme();

                    }


                    Console.ReadKey(true);
                    Console.Clear();
                }






            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadKey();
        }




        string[] options2_2 = { "\n\n\n\t\t\tHistory of Programming", "\t\t\tGuess The Output" };


        public void HistoryAndGuess()
        {

            myGame.fullscreen();
            Console.Clear();
            myTitles.printTitle();


            try
            {
                string soundFilePath2 = @"C:\selected.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);

                modes mainModes = new modes(options2_2);
                int selectedMode = mainModes.ModesSelecting2();


                if (selectedMode == 0)
                {
                    modes = "History of Programming";


                }
                else if (selectedMode == 1)
                {
                    modes = "Guess The Output";

                }

                Console.Clear();




                while (true)
                {

                    Console.Clear();
                    myTitles.printTitle();
                    Difficulties mainDiff = new Difficulties(options2);
                    int selectedDiff = mainDiff.DiffSelecting();

                    if (selectedDiff == 0)
                    {
                        if (modes.Equals("History of Programming"))
                        {
                            isSelected = "HistoryEasy";

                        }
                        else if (modes.Equals("Guess The Output"))
                        {
                            isSelected = "GuessEasy";

                        }

                        soundFilePath2 = @"C:\selected.wav";
                        ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                    }
                    else if (selectedDiff == 1)
                    {
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy Mode To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                    }
                    else if (selectedDiff == 2)
                    {
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy & Medium Modes To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;



                    }

                    if (modes.Equals("History of Programming"))
                    {
                        myGame.HistoryGAme();


                    }
                    else if (modes.Equals("Guess The Output"))
                    {
                        myGame.GuessGAme();

                    }


                    Console.ReadKey(true);
                    Console.Clear();




                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
            }



            Console.ReadKey();

        }




        string[] options2_3 = { "\n\n\n\t\t\tHistory of Programming", "\t\t\tSpot The Error" };


        public void HistoryAndSpot()
        {

            myGame.fullscreen();
            Console.Clear();
            myTitles.printTitle();


            try
            {
                string soundFilePath2 = @"C:\selected.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);

                modes mainModes = new modes(options2_3);
                int selectedMode = mainModes.ModesSelecting2();


                if (selectedMode == 0)
                {
                    modes = "History of Programming";


                }
                else if (selectedMode == 1)
                {
                    modes = "Spot The Error";

                }

                Console.Clear();




                while (true)
                {

                    Console.Clear();
                    myTitles.printTitle();
                    Difficulties mainDiff = new Difficulties(options2);
                    int selectedDiff = mainDiff.DiffSelecting();

                    if (selectedDiff == 0)
                    {
                        if (modes.Equals("History of Programming"))
                        {
                            isSelected = "HistoryEasy";

                        }
                        else if (modes.Equals("Spot The Error"))
                        {
                            isSelected = "SpotEasy";

                        }

                        //diff = "Easy";
                        soundFilePath2 = @"C:\selected.wav";
                        ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                        //break;
                    }
                    else if (selectedDiff == 1)
                    {
                        //isSelected = "HistoryMedium";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy Mode To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Medium";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;


                    }
                    else if (selectedDiff == 2)
                    {

                        //isSelected = "HistoryHard";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy & Medium Modes To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Hard";continue;
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;



                    }

                    if (modes.Equals("History of Programming"))
                    {
                        myGame.HistoryGAme();


                    }
                    else if (modes.Equals("Spot The Error"))
                    {
                        myGame.SpotGAme();

                    }


                    Console.ReadKey(true);
                    Console.Clear();




                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
            }



            Console.ReadKey();

        }

        //--------------------------------------------------------------SELECTING MODE AGAIN 1 OPTION --------------------------------------------------------------------------------------

        //------------------------------------------------------------ (SOLO) REMAINING MODES-------------------------------------------------------------------------------------------

        string[] OnlyHistoryOption = { "\n\n\n\t\t\tHistory of Programming" };


        public void HistoryOnly()
        {

            myGame.fullscreen();
            Console.Clear();
            myTitles.printTitle();


            try
            {
                string soundFilePath2 = @"C:\selected.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);


                modes mainModes = new modes(OnlyHistoryOption);
                int selectedMode = mainModes.ModesSelectingSolo();


                if (selectedMode == 0)
                {
                    modes = "History of Programming";


                }

                Console.Clear();




                while (true)
                {

                    Console.Clear();
                    myTitles.printTitle();
                    Difficulties mainDiff = new Difficulties(options2);
                    int selectedDiff = mainDiff.DiffSelecting();

                    if (selectedDiff == 0)
                    {

                        isSelected = "HistoryEasy";




                        //diff = "Easy";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;
                    }
                    else if (selectedDiff == 1)
                    {
                        //isSelected = "HistoryMedium";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy Mode To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Medium";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;


                    }
                    else if (selectedDiff == 2)
                    {

                        //isSelected = "HistoryHard";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy & Medium Modes To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Hard";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;



                    }
                    if (modes.Equals("History of Programming"))
                    {
                        myGame.HistoryGAme();

                    }

                    ModesSelectionCondition();

                    Console.ReadKey(true);
                    Console.Clear();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
            }



            Console.ReadKey();

        }


        string[] OnlySpotOption = { "\n\n\n\t\t\tSpot The Error" };


        public void SpotOnly()
        {

            myGame.fullscreen();
            Console.Clear();
            myTitles.printTitle();


            try
            {
                string soundFilePath2 = @"C:\selected.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);


                modes mainModes = new modes(OnlySpotOption);
                int selectedMode = mainModes.ModesSelectingSolo();


                if (selectedMode == 0)
                {
                    modes = "Spot The Error";


                }

                Console.Clear();




                while (true)
                {

                    Console.Clear();
                    myTitles.printTitle();
                    Difficulties mainDiff = new Difficulties(options2);
                    int selectedDiff = mainDiff.DiffSelecting();

                    if (selectedDiff == 0)
                    {

                        isSelected = "SpotEasy";



                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;
                    }
                    else if (selectedDiff == 1)
                    {
                        //isSelected = "HistoryMedium";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy Mode To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Medium";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;


                    }
                    else if (selectedDiff == 2)
                    {

                        //isSelected = "HistoryHard";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy & Medium Modes To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Hard";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;



                    }

                    if (modes.Equals("Spot The Error"))
                    {
                        myGame.SpotGAme();

                    }

                    ModesSelectionCondition();


                    Console.ReadKey(true);
                    Console.Clear();



                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
            }



            Console.ReadKey();

        }


        string[] OnlyGuessOption = { "\n\n\n\t\t\tGuess The Output" };


        public void GuessOnly()
        {

            myGame.fullscreen();
            Console.Clear();
            myTitles.printTitle();


            try
            {
                string soundFilePath2 = @"C:\selected.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);


                modes mainModes = new modes(OnlyGuessOption);
                int selectedMode = mainModes.ModesSelectingSolo();


                if (selectedMode == 0)
                {
                    modes = "Guess The Output";


                }

                Console.Clear();




                while (true)
                {

                    Console.Clear();
                    myTitles.printTitle();
                    Difficulties mainDiff = new Difficulties(options2);
                    int selectedDiff = mainDiff.DiffSelecting();

                    if (selectedDiff == 0)
                    {

                        isSelected = "GuessEasy";




                        //diff = "Easy";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;
                    }
                    else if (selectedDiff == 1)
                    {
                        //isSelected = "HistoryMedium";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy Mode To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Medium";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;


                    }
                    else if (selectedDiff == 2)
                    {

                        //isSelected = "HistoryHard";
                        Console.WriteLine("\n\t\t\tYou Need to Passed Easy & Medium Modes To Unlocked This Difficulties...");
                        Console.Beep(500, 300);
                        continue;
                        //diff = "Hard";
                        //soundFilePath2 = @"C:\selected.wav";
                        //ThreadPool.QueueUserWorkItem(ForEnteringTheNameSounds, soundFilePath2);
                        //break;



                    }

                    if (modes.Equals("Guess The Output"))
                    {
                        myGame.GuessGAme();

                    }

                    ModesSelectionCondition();


                    Console.ReadKey(true);
                    Console.Clear();






                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
            }



            Console.ReadKey();

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------



    }
}
