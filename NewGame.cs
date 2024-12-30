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
    class NewGame
    {

        int id = 0;
        string modes = "";

        int holderPoints = 0;
        int Eattempt = 1, Mattempt = 1, Hattempt = 1;
        string isSelected = "";
        string check = " ";
        int easyPoints = 0, mediumPoints = 0, hardPoints = 0;
        int easyCounter = 0, mediumCounter = 0, hardCounter = 0;



        string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";




        //-------------------------------------- CALLING OTHER CLASS -------------------------------------------------



                                              Title myTitles = new Title();

                                              game myGame = new game();



        //---------------------------------------------------------------------------------------


        string[] options = { "\n\n\n\t\t\tHistory of Programming", "\t\t\tSpot the Error", "\t\t\tGuess the Output" };
        string[] options2 = { "\n\n\n\t\t\tEasy", "\t\t\tMedium", "\t\t\tHard" };

        public void SelectedNewGame()
        {
            ConsoleKey keyPressed;





            Console.Clear();
            myTitles.printTitleforGame();


            Write("\n\n\n\t\t\tCreate Username : ");

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.DownArrow)
            {
                Console.Clear();


                myGame.RunFirstMenu();
            }
            else
            {


                Console.Clear();
                myTitles.printTitle();

            retry:
                Console.Write("\n\n\n\t\t\tCreate Username : ");
                string username = Console.ReadLine();

                try
                {

                    if (string.IsNullOrEmpty(username))
                    {
                        Console.Clear();
                        myTitles.printTitle();
                        Console.Write("\t\t\t\t\t\tUsername cannot be empty.");
                        Console.Beep(500, 300);
                        goto retry;
                    }



                    string soundFilePath2 = @"C:\selected.wav";
                    ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);

                    string query = "INSERT INTO tbinsert (USER, MODES, DIFFICULTIES, POINTS) VALUES (@username, @modes, @difficulties, @points)";


                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand myCommand = new MySqlCommand(query, myConn);

                        modes mainModes = new modes(options);
                        int selectedMode = mainModes.ModesSelecting();
                        string diff = "";

                        if (selectedMode == 0)
                        {
                            modes = "History of Programming";

                        }
                        else if (selectedMode == 1)
                        {
                            modes = "Spot The Error";

                        }
                        else if (selectedMode == 2)
                        {
                            modes = "Guess The Output";

                        }

                        Console.Clear();




                        if (modes.Equals("History of Programming"))
                        {
                            while (true)
                            {

                                Console.Clear();
                                myTitles.printTitle();
                                Difficulties mainDiff = new Difficulties(options2);
                                int selectedDiff = mainDiff.DiffSelecting();

                                if (selectedDiff == 0)
                                {
                                    isSelected = "Easy";

                                    diff = "Easy";
                                    soundFilePath2 = @"C:\selected.wav";
                                    ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                                    break;
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
                                Console.ReadKey(true);
                                Console.Clear();



                            }
                        }
                        else if (modes.Equals("Spot The Error"))
                        {
                            while (true)
                            {

                                Console.Clear();
                                myTitles.printTitle();
                                Difficulties mainDiff = new Difficulties(options2);
                                int selectedDiff = mainDiff.DiffSelecting();

                                if (selectedDiff == 0)
                                {
                                    isSelected = "Easy";

                                    diff = "Easy";
                                    soundFilePath2 = @"C:\selected.wav";
                                    ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                                    break;
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
                                Console.ReadKey(true);
                                Console.Clear();



                            }
                        }
                        else if (modes.Equals("Guess The Output"))
                        {
                            while (true)
                            {

                                Console.Clear();
                                myTitles.printTitle();
                                Difficulties mainDiff = new Difficulties(options2);
                                int selectedDiff = mainDiff.DiffSelecting();

                                if (selectedDiff == 0)
                                {
                                    isSelected = "Easy";

                                    diff = "Easy";
                                    soundFilePath2 = @"C:\selected.wav";
                                    ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                                    break;
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
                                Console.ReadKey(true);
                                Console.Clear();



                            }
                        }








                        myCommand.Parameters.AddWithValue("@username", username);
                        myCommand.Parameters.AddWithValue("@modes", modes);
                        myCommand.Parameters.AddWithValue("@difficulties", diff);

                        int starterPoints = 0;

                        myCommand.Parameters.AddWithValue("@points", starterPoints);



                        myConn.Open();
                        int rowsAffected = myCommand.ExecuteNonQuery();





                        if (modes.Equals("History of Programming"))
                        {
                            myGame.HistoryGAme();

                        }
                        else if (modes.Equals("Spot The Error"))
                        {
                            myGame.SpotGAme();

                        }
                        else if (modes.Equals("Guess The Output"))
                        {
                            myGame.GuessGAme();


                        }




                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }


            Console.ReadKey();

        }




    }

}
