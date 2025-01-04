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

namespace AlgoQuest
{
     class leaderboards
    {


        game myGame = new game();

        public void leaderboardTitle()
        {
            string title = @"
                    ██╗     ███████╗ █████╗ ██████╗ ███████╗██████╗ ██████╗  ██████╗  █████╗ ██████╗ ██████╗
                    ██║     ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗
                    ██║     █████╗  ███████║██║  ██║█████╗  ██████╔╝██████╔╝██║   ██║███████║██████╔╝██║  ██║
                    ██║     ██╔══╝  ██╔══██║██║  ██║██╔══╝  ██╔══██╗██╔══██╗██║   ██║██╔══██║██╔══██╗██║  ██║
                    ███████╗███████╗██║  ██║██████╔╝███████╗██║  ██║██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝
                    ╚══════╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ 
                            ";
        
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }



 



        public void Leaderboards()
            {
                Clear();
                string[] options = { "  History of Programming  ", "     Guess the Output     ", "      Spot the Error      " };
                int selectedIndex = 0;

                ConsoleKey key;
                do
                {
                    Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    leaderboardTitle();
                    ResetColor();
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\t\t\t\t\t\t> {options[i]} <");
                    }
                    else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray; // Normal color for unselected options
                            Console.WriteLine($"\t\t\t\t\t\t  {options[i]}");
                        }
                    }

                    Console.ResetColor();

                    key = Console.ReadKey().Key;

                    if (key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex + 1) % options.Length;
                    }
                } while (key != ConsoleKey.Enter);

                if (options[selectedIndex] == "  History of Programming  ")
                {
                    leaderboardHistory();
                }
                else if (options[selectedIndex] == "     Guess the Output     ")
                {
                    leaderboardGuess();
                }
                else if (options[selectedIndex] == "      Spot the Error      ")
                {
                    leaderboardSpot();
                }
            }



       
        public void leaderboardHistory()
        {
            Console.Clear();
            string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";
            string query = "SELECT ID, NAME, H_OVERALLPOINTS FROM historylb ORDER BY H_OVERALLPOINTS DESC";
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            leaderboardTitle();

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(query, myConn);
                    myConn.Open();

                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        
                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");
                        Console.WriteLine("\t\t\t\t| RANK\t| ID\t|\tUSERNAME\t|     POINTS    |");
                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");

                        int rank = 1;

                      
                        while (reader.Read() && rank <= 10)
                        {
                            string id = reader["ID"].ToString();
                            string user = reader["NAME"].ToString();
                            int points = Convert.ToInt32(reader["H_OVERALLPOINTS"]);

                           
                            if (user.Length > 8)
                            {
                                user = user.Length > 8 ? user.Substring(0, 8) : user;
                                Console.WriteLine("\t\t\t\t| " + rank + "\t| " + id + "\t|\t" + user + "...\t|       " + points + " \t|");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\t\t| " + rank + "\t| " + id + "\t|\t" + user + "\t\t|       " + points + " \t|");
                            }
                            rank++;
                        }


                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Write("\n\t\t\t\tMAIN SCREEN - UP ARROW\t\t\tDOWN ARROW - GO BACK");
            ConsoleKey keyPressed;

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow)
            {
                Console.Clear();
                myGame.RunFirstMenu();
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                Clear();
                Leaderboards();
            }
        }




        public void leaderboardSpot()
        {
            Console.Clear();
            string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";
            string query = "SELECT ID, NAME, S_OVERALLPOINTS FROM spotlb ORDER BY S_OVERALLPOINTS DESC";
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            leaderboardTitle();

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(query, myConn);
                    myConn.Open();

                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                  
                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");
                        Console.WriteLine("\t\t\t\t| RANK\t| ID\t|\tUSERNAME\t|     POINTS    |");
                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");

                        int rank = 1;

                        
                        while (reader.Read() && rank <= 10)
                        {
                            string id = reader["ID"].ToString();
                            string user = reader["NAME"].ToString();
                            int points = Convert.ToInt32(reader["S_OVERALLPOINTS"]);

                            
                            if (user.Length > 8)
                            {
                                user = user.Length > 8 ? user.Substring(0, 8) : user;
                                Console.WriteLine("\t\t\t\t| " + rank + "\t| " + id + "\t|\t" + user + "...\t|       " + points + " \t|");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\t\t| " + rank + "\t| " + id + "\t|\t" + user + "\t\t|       " + points + " \t|");
                            }
                            rank++;
                        }


                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }


            Write("\n\t\t\t\tMAIN SCREEN - UP ARROW\t\t\tDOWN ARROW - GO BACK");
            ConsoleKey keyPressed;

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow)
            {
                Console.Clear();
                myGame.RunFirstMenu();
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                Clear();
                Leaderboards();
            }
        }
             




        public void leaderboardGuess()
        {
            Console.Clear();
            string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";
            string query = "SELECT ID, NAME, G_OVERALLPOINTS FROM guesslb ORDER BY G_OVERALLPOINTS DESC";
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            leaderboardTitle();

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(query, myConn);
                    myConn.Open();

                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                       
                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");
                        Console.WriteLine("\t\t\t\t| RANK\t| ID\t|\tUSERNAME\t|     POINTS    |");
                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");

                        int rank = 1;

                      
                        while (reader.Read() && rank <= 10)
                        {
                            string id = reader["ID"].ToString();
                            string user = reader["NAME"].ToString();
                            int points = Convert.ToInt32(reader["G_OVERALLPOINTS"]);

                           
                            if(user.Length > 8)
                            {
                                user = user.Length > 8 ? user.Substring(0,8) : user;
                                Console.WriteLine("\t\t\t\t| " + rank + "\t| " + id + "\t|\t" + user + "...\t|       " + points + " \t|");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\t\t| " + rank + "\t| " + id + "\t|\t" + user + "\t\t|       " + points + " \t|");
                            }
                            rank++;
                        }


                        Console.WriteLine("\t\t\t\t---------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Write("\n\t\t\t\tMAIN SCREEN - UP ARROW\t\t\tDOWN ARROW - GO BACK");
            ConsoleKey keyPressed;

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow)
            {
                Console.Clear();
                myGame.RunFirstMenu();
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                Clear();
                Leaderboards();
            }
        }













    }

}
