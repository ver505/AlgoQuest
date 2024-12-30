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
     class LoadGame
    {
        string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";



        //-------------------------------------- CALLING OTHER CLASS -------------------------------------------------



        Title myTitles = new Title();

        game myGame = new game();



        //---------------------------------------------------------------------------------------



        public void SelectedLoadGame()
        {


            Console.Clear();
            myTitles.printTitle();

        back:
            Console.Write("\n\n\n\t\t\tUSER ID: ");
            string inputedID = Console.ReadLine();

            string soundFilePath2 = @"C:\selected.wav";
            ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);

            try
            {
                // Query to fetch the data for the given inputedID
                string query = "SELECT ID, USER, MODES, DIFFICULTIES, POINTS FROM tbinsert WHERE ID = @ID";

                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(query, myConn);
                    myCommand.Parameters.AddWithValue("@ID", inputedID);

                    myConn.Open();

                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a row is returned
                        {
                            // Store the primary key ID in a variable
                            int storedID = Convert.ToInt32(reader["ID"]);

                            // Retrieve additional data (optional)
                            string username = reader["USER"].ToString();
                            string modes = reader["MODES"].ToString();
                            string difficulties = reader["DIFFICULTIES"].ToString();
                            int points = Convert.ToInt32(reader["POINTS"]);




                            Clear();


                            myGame.fullscreen();
                            myGame.loadingScreen();






                            Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            myTitles.actualGameTitle();



                            Console.ForegroundColor = ConsoleColor.Yellow;



                            Console.WriteLine("\n\n\t\t\t| USERNAME: " + username);
                            Console.WriteLine("\t\t\t| USER ID: " + storedID);

                            Console.WriteLine("\n\n\t\t\t| MODE: " + modes);
                            Console.WriteLine("\t\t\t| DIFFICULTY: " + difficulties);

                            Console.WriteLine("\n\n\t\t\t| POINTS: " + points);



                            if (OperatingSystem.IsWindows())
                            {
                                SoundPlayer sound = new SoundPlayer(@"C:\ingameSound.wav");
                                sound.Load();
                                sound.PlayLooping();

                            }


                        }
                        else
                        {

                            Console.Clear();
                            myTitles.printTitle();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t\t\t\t\t\tUSER ID DOESN'T EXIST.");
                            Console.Beep(500, 300);
                            goto back;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadLine();

        }





    }
}
