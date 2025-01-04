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
using System.Net.Security;


namespace AlgoQuest
{
    class Admin
    {

        Title myTitles = new Title();
        game myGame = new game();
        public void adminLogin()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    myTitles.adminTitle();
                    Console.Write("\n\n\t\t\t\t\tADMIN 4 DIGITS PIN : ");
                    string pin = Console.ReadLine();

                    if (string.IsNullOrEmpty(pin))
                    {
                        Console.Clear();
                        myTitles.adminTitle();

                    again:
                        Console.WriteLine("\t\t\t\t\tCannot be empty.");
                        Console.Beep(500, 300);
                        continue;
                    }

                    if (int.TryParse(pin, out int pinInt) && pin.Length == 4)
                    {
                        if (pinInt == 1234)
                        {
                            Console.Clear();
                            game myGame = new game();
                        
                            admin_Opt();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            myTitles.adminTitle();
                            Console.WriteLine("\t\t\t\t\tWrong PIN.");
                            Console.Beep(500, 300);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        myTitles.adminTitle();
                        Console.WriteLine("\t\t\t\t\tInvalid input. Enter a 4-digit number.");
                        Console.Beep(500, 300);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"\t\t\t\t\tAn unexpected error occurred: {ex.Message}");
            }
            Console.ReadKey();


        }



        private void admin_Opt()
        {
            string[] mainMenu = { "History of Programming", "   Guess the Output   ", "    Spot the Error    " }; 
            string[] difficultyLevels = { "Easy", "Medium", "Hard" };
            int mainMenuIndex = 0;
            string admin = @"
       ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗     █████╗ ██████╗ ███╗   ███╗██╗███╗   ██╗██╗
       ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ██╔══██╗██╔══██╗████╗ ████║██║████╗  ██║██║
       ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗      ███████║██║  ██║██╔████╔██║██║██╔██╗ ██║██║
       ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝      ██╔══██║██║  ██║██║╚██╔╝██║██║██║╚██╗██║╚═╝
       ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗    ██║  ██║██████╔╝██║ ╚═╝ ██║██║██║ ╚████║██╗
        ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝    ╚═╝  ╚═╝╚═════╝ ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═╝
";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t\t\t" + admin);
                Console.WriteLine("\n\n\t\t       Use the arrow keys to navigate, press Enter to select, or press Backspace to go back.");
                Console.WriteLine("\t\t\t\t\t          Please Select an Option\n");

              
                for (int i = 0; i < mainMenu.Length; i++)
                {
                    if (i == mainMenuIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\t\t\t\t\t> " + mainMenu[i] + " <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t\t\t  " + mainMenu[i]);
                    }
                }

            
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    mainMenuIndex = (mainMenuIndex > 0) ? mainMenuIndex - 1 : mainMenu.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    mainMenuIndex = (mainMenuIndex < mainMenu.Length - 1) ? mainMenuIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    ShowDifficultyLevels(mainMenu[mainMenuIndex], difficultyLevels);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    
                    Console.Clear();
                    myGame.startWindow();
                }
            }
        }



        static void ShowDifficultyLevels(string menuName, string[] difficultyLevels)
        {
            int difficultyIndex = 0;
            string dif = @"
                            ██████╗ ██╗███████╗███████╗██╗ ██████╗██╗   ██╗██╗  ████████╗██╗   ██╗
                            ██╔══██╗██║██╔════╝██╔════╝██║██╔════╝██║   ██║██║  ╚══██╔══╝╚██╗ ██╔╝
                            ██║  ██║██║█████╗  █████╗  ██║██║     ██║   ██║██║     ██║    ╚████╔╝ 
                            ██║  ██║██║██╔══╝  ██╔══╝  ██║██║     ██║   ██║██║     ██║     ╚██╔╝  
                            ██████╔╝██║██║     ██║     ██║╚██████╗╚██████╔╝███████╗██║      ██║   
                            ╚═════╝ ╚═╝╚═╝     ╚═╝     ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝      ╚═╝ 
";

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(dif);
                Console.WriteLine("");
                Console.WriteLine("\n\t     Select difficulty level (Use arrow keys to navigate, Enter to select, or Backspace to go back):\n\n\n\n");

           
                for (int i = 0; i < difficultyLevels.Length; i++)
                {
                    if (i == difficultyIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\t\t\t\t\t\t> " + difficultyLevels[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t  " + difficultyLevels[i]);
                    }
                }

              
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    difficultyIndex = (difficultyIndex > 0) ? difficultyIndex - 1 : difficultyLevels.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    difficultyIndex = (difficultyIndex < difficultyLevels.Length - 1) ? difficultyIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    Console.WriteLine("You selected: " + menuName + " - " + difficultyLevels[difficultyIndex] + "\n");

                  
                    if (menuName == "History of Programming")
                    {
                        HandleHistoryOfProgramming(difficultyLevels[difficultyIndex]);
                    }
                    else if (menuName == "   Guess the Output   ")
                    {
                        HandleGuessTheOutput(difficultyLevels[difficultyIndex]);
                    }
                    else if (menuName == "    Spot the Error    ")
                    {
                        HandleSpotTheError(difficultyLevels[difficultyIndex]);
                    }

                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    break;
                }
                else if (key == ConsoleKey.Backspace)
                {
                    return;   
                }
            }
        }
        static void Guesstitle()
        {
            string guess = @"
                                                                                                                                
                                       ██████╗ ██╗   ██╗███████╗███████╗███████╗
                                      ██╔════╝ ██║   ██║██╔════╝██╔════╝██╔════╝
                                      ██║  ███╗██║   ██║█████╗  ███████╗███████╗
                                      ██║   ██║██║   ██║██╔══╝  ╚════██║╚════██║
                                      ╚██████╔╝╚██████╔╝███████╗███████║███████║
                                       ╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚══════╝                                                                                                    
        ";

            Console.Write(guess);
        }

        static void historytitle()
        {
            string histo = @"
                                   ██╗  ██╗██╗███████╗████████╗ ██████╗ ██████╗ ██╗   ██╗  
                                   ██║  ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
                                   ███████║██║███████╗   ██║   ██║   ██║██████╔╝ ╚████╔╝ 
                                   ██╔══██║██║╚════██║   ██║   ██║   ██║██╔══██╗  ╚██╔╝  
                                   ██║  ██║██║███████║   ██║   ╚██████╔╝██║  ██║   ██║ 
                                   ╚═╝  ╚═╝╚═╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝  
        ";

            Console.Write(histo);
        }

        static void spottitle()
        {
            string histo = @"
                                                                                                                                
         ███████╗██████╗  ██████╗ ████████╗  ████████╗██╗  ██╗███████╗  ███████╗██████╗ ██████╗  ██████╗ ██████╗   
         ██╔════╝██╔══██╗██╔═══██╗╚══██╔══╝  ╚══██╔══╝██║  ██║██╔════╝  ██╔════╝██╔══██╗██╔══██╗██╔═══██╗██╔══██╗  
         ███████╗██████╔╝██║   ██║   ██║        ██║   ███████║█████╗    █████╗  ██████╔╝██████╔╝██║   ██║██████╔╝ 
         ╚════██║██╔═══╝ ██║   ██║   ██║        ██║   ██╔══██║██╔══╝    ██╔══╝  ██╔══██╗██╔══██╗██║   ██║██╔══██╗ 
         ███████║██║     ╚██████╔╝   ██║        ██║   ██║  ██║███████╗  ███████╗██║  ██║██║  ██║╚██████╔╝██║  ██║ 
         ╚══════╝╚═╝      ╚═════╝    ╚═╝        ╚═╝   ╚═╝  ╚═╝╚══════╝  ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝                                                                   
        ";

            Console.Write(histo);
        }

        static void HandleHistoryOfProgramming(string difficulty)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            historytitle();
            Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
            string historydiff = difficulty;

            
            if (historydiff == "Easy")
            {

                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {

                        string query = "INSERT INTO  tbeasyquestion_history (QUESTION, ANSWER, A , B ) VALUES (@question, @answer , @a , @b)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();
                            string a = "TRUE";
                            string b = "FALSE";

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);
                            myCommand.Parameters.AddWithValue("@a", a);
                            myCommand.Parameters.AddWithValue("@b", b);

                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                historytitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");


                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else if (historydiff == "Medium")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";
                try
                {

                    string cont = "";
                    do
                    {

                        string query = "INSERT INTO  tbmediumquestion_history (QUESTION, A, B, C, D, ANSWER) VALUES (@question, @a, @b, @c, @d,@answer)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  A: ");
                            string a = Console.ReadLine();
                            Console.Write("\t\t\t\t  B: ");
                            string b = Console.ReadLine();
                            Console.Write("\t\t\t\t  C: ");
                            string c = Console.ReadLine();
                            Console.Write("\t\t\t\t  D: ");
                            string d = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);
                            myCommand.Parameters.AddWithValue("@a", a);
                            myCommand.Parameters.AddWithValue("@b", b);
                            myCommand.Parameters.AddWithValue("@c", c);
                            myCommand.Parameters.AddWithValue("@d", d);


                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                historytitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");


                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }

            }

            else if (historydiff == "Hard")
            {
                Console.WriteLine();
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {
                        string query = "INSERT INTO  tbhardquestion_history (QUESTION, ANSWER) VALUES (@question, @answer)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);

                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                historytitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");

                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        
        static void HandleGuessTheOutput(string difficulty)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Guesstitle();
            Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
            string guessdiff = difficulty;

            if (guessdiff == "Easy")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";
                try
                {
                    string cont = "";
                    do
                    {

                        string query = "INSERT INTO  tbeasyquestion_guess (QUESTION, ANSWER, A , B ) VALUES (@question, @answer , @a , @b)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);


                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();
                            string a = "TRUE";
                            string b = "FALSE";

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);
                            myCommand.Parameters.AddWithValue("@a", a);
                            myCommand.Parameters.AddWithValue("@b", b);

                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Guesstitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");

                    return;
                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else if (guessdiff == "Medium")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {
                        string query = "INSERT INTO  tbmediumquestion_guess (QUESTION, A, B, C, D, ANSWER) VALUES (@question, @a, @b, @c, @d,@answer)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  A: ");
                            string a = Console.ReadLine();
                            Console.Write("\t\t\t\t  B: ");
                            string b = Console.ReadLine();
                            Console.Write("\t\t\t\t  C: ");
                            string c = Console.ReadLine();
                            Console.Write("\t\t\t\t  D: ");
                            string d = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);
                            myCommand.Parameters.AddWithValue("@a", a);
                            myCommand.Parameters.AddWithValue("@b", b);
                            myCommand.Parameters.AddWithValue("@c", c);
                            myCommand.Parameters.AddWithValue("@d", d);



                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Guesstitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");


                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }

            }
            else if (guessdiff == "Hard")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {
                        string query = "INSERT INTO  tbhardquestion_guess (QUESTION, ANSWER) VALUES (@question, @answer)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\n\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();


                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);

                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Guesstitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");



                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

      
        static void HandleSpotTheError(string difficulty)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            spottitle();
            Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
            string spotdiff = difficulty;

           
            if (spotdiff == "Easy")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {

                        string query = "INSERT INTO  tbeasyquestion_spoterror (QUESTION, ANSWER, A , B ) VALUES (@question, @answer , @a , @b)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);


                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();
                            string a = "TRUE";
                            string b = "FALSE";

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);
                            myCommand.Parameters.AddWithValue("@a", a);
                            myCommand.Parameters.AddWithValue("@b", b);

                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                spottitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");


                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else if (spotdiff == "Medium")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {
                        string query = "INSERT INTO  tbmediumquestion_spoterror (QUESTION, A, B, C, D, ANSWER) VALUES (@question, @a, @b, @c, @d,@answer)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  A: ");
                            string a = Console.ReadLine();
                            Console.Write("\t\t\t\t  B: ");
                            string b = Console.ReadLine();
                            Console.Write("\t\t\t\t  C: ");
                            string c = Console.ReadLine();
                            Console.Write("\t\t\t\t  D: ");
                            string d = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();

                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);
                            myCommand.Parameters.AddWithValue("@a", a);
                            myCommand.Parameters.AddWithValue("@b", b);
                            myCommand.Parameters.AddWithValue("@c", c);
                            myCommand.Parameters.AddWithValue("@d", d);


                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                spottitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");


                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }

            }
            else if (spotdiff == "Hard")
            {
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

                try
                {
                    string cont = "";
                    do
                    {
                        string query = "INSERT INTO  tbhardquestion_spoterror (QUESTION, ANSWER) VALUES (@question, @answer)";
                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);

                            Console.Write("\t\t\t\t  QUESTION: ");
                            string question = Console.ReadLine();
                            Console.Write("\t\t\t\t  ANSWER: ");
                            string answer = Console.ReadLine();


                            myCommand.Parameters.AddWithValue("@question", question);
                            myCommand.Parameters.AddWithValue("@answer", answer);

                            Console.Write("\t\t\t\t  ADDED SUCCESSFULLY!");
                            Console.Write("\n\t\t\t\t  CONTINUE: ");
                            cont = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            Clear();
                            if (cont == "yes")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                spottitle();
                                Console.WriteLine("\n\n\t\t\t\t     Use double spacing to create a new line (\"  \")\n\n");
                            }
                            myConn.Open();
                            int rowsAffected = myCommand.ExecuteNonQuery();
                        }
                    }
                    while (cont == "yes");



                }

                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }

            }
        }
    }
}
