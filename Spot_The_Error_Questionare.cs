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
using System.Net.NetworkInformation;

namespace AlgoQuest
{
    class Spot_The_Error_Questionare
    {
        int id = 0;

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

        ProcessOfModesSelection pms = new ProcessOfModesSelection();



        //---------------------------------------------------------------------------------------







        public void easySpotQuestionaire(){

        tryEasyAgain:
            int counter = 0;
            int c = 0;


            while (counter < 11)  
            {

                try
                {
 
                    string randomIdQuery = "SELECT IDEQSPOT FROM tbeasyquestion_spoterror ORDER BY RAND() LIMIT 1;";
                    int randomIDQ = 0;
                    bool isUniqueIDFound = false;
                    HashSet<int> usedIds = new HashSet<int>();

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand randomIdCommand = new MySqlCommand(randomIdQuery, myConn);

                        myConn.Open();
                        object result = randomIdCommand.ExecuteScalar();
                        if (result != null)
                        {
                            randomIDQ = Convert.ToInt32(result);
                            if (!usedIds.Contains(randomIDQ))
                            {
                                isUniqueIDFound = true;
                                usedIds.Add(randomIDQ);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No questions available in the database.");
                            return;
                        }
                    }

                  
                    string query = "SELECT IDEQSPOT, QUESTION, ANSWER, A, B FROM  tbeasyquestion_spoterror WHERE IDEQSPOT = @IDEQSPOT";

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand myCommand = new MySqlCommand(query, myConn);
                        myCommand.Parameters.AddWithValue("@IDEQSPOT", randomIDQ);

                        myConn.Open();

                        using (MySqlDataReader reader = myCommand.ExecuteReader())
                        {
                            if (reader.Read())  
                            {
                                string question = reader["QUESTION"].ToString().Replace("  ", "\n\t\t\t\t\t\t\t\t\t");
                                string choiceA = reader["A"].ToString();
                                string choiceB = reader["B"].ToString();
                                string correctAnswer = reader["ANSWER"].ToString();  

                         
                                int selectedOption = 0;
                                bool answerSelected = false;


                                while (!answerSelected)
                                {
                                    Console.Clear();
                                    myTitles.actualGameTitle();
                                    isSelected = "SpotEasy";
                                    actualGameSpot();
                                    if (c < 10)
                                    {
                                        ResetColor();
                                        ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\tInstructions: Read the code carefully, paying attention to the case sensitivity of variable names, and determine \n\t\t\t\t\t\t\t\t\t if the syntax is correct or wrong based on consistency and proper usage of variables.");
                                        ResetColor();
                                        Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\tQUESTION {counter + 1} - QUESTION 10\n");
                                        Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t{question}\n");
                                        Console.WriteLine($"\t\t\t\t\t\t\t\t\tCorrect Ans: {correctAnswer}\n");



                                     
                                        string[] choices = { choiceA, choiceB };
                                        for (int j = 0; j < choices.Length; j++)

                                        {
                                            if (j == selectedOption)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                            }
                                            else
                                            {
                                                Console.ResetColor();
                                            }

                                            Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t{choices[j]}");
                                        }

                                    
                                        var key = Console.ReadKey(true).Key;
                                        if (key == ConsoleKey.UpArrow) selectedOption = (selectedOption - 1 + choices.Length) % choices.Length;
                                        else if (key == ConsoleKey.DownArrow) selectedOption = (selectedOption + 1) % choices.Length;
                                        else if (key == ConsoleKey.Enter)
                                        {
                                            answerSelected = true;

                                          
                                            if (choices[selectedOption].Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                                            {
                                                easyPoints++;
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\tCorrect!.");
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t\t\t\tIncorrect.");
                                            }



                                            Console.ResetColor();
                                            Thread.Sleep(1000);
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found for the selected IDEQSPOT.");
                                return;

                            }
                        }
                    }

                    Clear();
                    counter++;
                    c++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }


            }



            if (holderPoints >= 6)
            {
                string soundFilePath2 = @"C:\congrats.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                string username = "";


                //----- adding to SPOT LEADERBOARD
             
                string read = "SELECT USER FROM tbinsert WHERE ID = (SELECT MAX(ID) FROM tbinsert)";
                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(read, myConn);

                    myConn.Open();

                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            username = reader["USER"].ToString();


                        }
                    }
                }

                string insert = "INSERT INTO spotlb (ID, NAME, S_EASYPOINTS, S_OVERALLPOINTS) VALUES (@id, @name, @heasyPoints, @S_OVERALLPOINTS);";

                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(insert, myConn);
                    myCommand.Parameters.AddWithValue("@id", id);
                    myCommand.Parameters.AddWithValue("@name", username);
                    myCommand.Parameters.AddWithValue("@heasyPoints", holderPoints);
                    myCommand.Parameters.AddWithValue("@S_OVERALLPOINTS", holderPoints);
                    myConn.Open();
                    int rowsAffected = myCommand.ExecuteNonQuery();

                }

                int t = 0;

            t:
                if (t >= 1)
                {
                    Clear();
                    myTitles.congrats();
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\tINVALID SELECTION");
                    Console.Beep(500, 300);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t   CONGRATULATIONS ON PASSING THIS DIFFICULTIES");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints); ;
                }
                else
                {
                    Clear();
                    myTitles.congrats();
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t   CONGRATULATIONS ON PASSING THIS DIFFICULTIES");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);

                }


                Console.Write("\n\t\t\t\t\t\t\t\t\t\t   PRESS X - GO TO MAIN SCREEN\n\t\t\t\t\t\t\t\t\t\t   PRESS M - NEXT DIFFICULTIES (MEDIUM) \n\t\t\t\t\t\t\t\t\t\t   :");
                string decidee = Console.ReadLine().ToLower();


                if (decidee.Equals("m"))
                {



                    isSelected = "SpotMedium";



                    string updateQuery = "UPDATE tbinsert SET DIFFICULTIES = @newDiff WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                        myConn.Open();
                        updateCommand.Parameters.AddWithValue("@newDiff", "Medium");
                        updateCommand.ExecuteNonQuery();
                    }

                    holderPoints = 0;


                    string updateQuery2 = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery2, myConn);

                        myConn.Open();
                        updateCommand.Parameters.AddWithValue("@newPoints", holderPoints);
                        updateCommand.ExecuteNonQuery();
                    }

                    mediumSpotQuestionaire();



                }
                else if (decidee.Equals("x"))
                {
                    Console.Clear();
                    myGame.fullscreen();
                    myGame.RunFirstMenu();
                }
                else
                {

                    t++;
                    goto t;

                }


            }
            else
            {
                string soundFilePath2 = @"C:\gameover.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);

                int tt = 0;

            tt:
                if (tt >= 1)
                {
                    Clear();
                    myTitles.gameOver();
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\tINVALID SELECTION");
                    Console.Beep(500, 300);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t  FAILED, YOU NEED TO MEET THE REQUIRED POINTS (6)");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t     THE GAME ENDS QUESTION 10/10\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);

                }
                else
                {
                    Clear();
                    myTitles.gameOver();
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t  FAILED, YOU NEED TO MEET THE REQUIRED POINTS (6)");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t     THE GAME ENDS QUESTION 10/10\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);

                }



                Console.Write("\n\t\t\t\t\t\t\t\t\t\t  PRESS G - RETRY\n\t\t\t\t\t\t\t\t\t\t  PRESS X - GO TO MAIN SCREEN \n\t\t\t\t\t\t\t\t\t\t  :");
                string decidee = Console.ReadLine().ToLower();

                if (decidee.Equals("g"))
                {


                    easyPoints = 0;
                    easyCounter = 0;
                    Eattempt = 1;
                    holderPoints = 0;



                    string updateQuery = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                        myConn.Open();
                        updateCommand.Parameters.AddWithValue("@newPoints", holderPoints);
                        updateCommand.ExecuteNonQuery();
                    }




                    goto tryEasyAgain;
                }
                else if (decidee.Equals("x"))
                {
                    Console.Clear();
                    myGame.fullscreen();
                    myGame.RunFirstMenu();
                }
                else
                {
                    tt++;

                    goto tt;

                }

            }








        }

        public void mediumSpotQuestionaire()
        {


        tryMediumAgain:
            int counter = 0;
            int c = 0;
                string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";
             

                while (counter < 7)  
                {

                try
                {
                    HashSet<int> usedIds = new HashSet<int>();  
                    string randomIdQuery = "SELECT IDMQSPOT FROM tbmediumquestion_spoterror ORDER BY RAND() LIMIT 1;";
                    int randomIDQ = 0;
                    bool isUniqueIDFound = false;


                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand randomIdCommand = new MySqlCommand(randomIdQuery, myConn);

                        myConn.Open();
                        object result = randomIdCommand.ExecuteScalar();
                        if (result != null)
                        {
                            randomIDQ = Convert.ToInt32(result);
                            if (!usedIds.Contains(randomIDQ))
                            {
                                isUniqueIDFound = true;
                                usedIds.Add(randomIDQ);  
                            }
                        }
                        else
                        {
                            Console.WriteLine("No questions available in the database.");
                            return;
                        }
                    }



                    string query = "SELECT IDMQSPOT, QUESTION, A, B, C, D, ANSWER FROM tbmediumquestion_spoterror WHERE IDMQSPOT = @IDMQSPOT";

                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand myCommand = new MySqlCommand(query, myConn);
                            myCommand.Parameters.AddWithValue("@IDMQSPOT", randomIDQ);

                            myConn.Open();

                            using (MySqlDataReader reader = myCommand.ExecuteReader())
                            {
                                if (reader.Read())  
                                {
                                string question = reader["QUESTION"].ToString().Replace("  ", "\n\t\t\t\t\t\t\t\t\t");
                                string[] choices = {
                            reader["A"].ToString(),
                            reader["B"].ToString(),
                            reader["C"].ToString(),
                            reader["D"].ToString()
                        };
                                    string correctAnswer = reader["ANSWER"].ToString();

                                
                                    int selectedOption = 0;
                                    bool answerSelected = false;


                                while (!answerSelected)
                                {

                                    Console.Clear();
                                    myTitles.actualGameTitle();
                                    actualGameSpot();
                                    if (c < 6)
                                    {
                                        ResetColor();
                                        ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\tInstructions: Read the code carefully, paying attention to the case sensitivity of variable names, and determine \n\t\t\t\t\t\t\t\t\t if the syntax is correct or wrong based on consistency and proper usage of variables.");
                                        ResetColor();
                                        Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\tQUESTION {counter + 1} - QUESTION 6");
                                        Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t{question + " "}\n");
                                        Console.WriteLine($"\t\t\t\t\t\t\t\t\tCorrect Ans: {correctAnswer}\n");
                                        Console.WriteLine();
                                        Console.WriteLine();

                          

                                        for (int j = 0; j < choices.Length; j++)
                                        {
                                            if (j == selectedOption)
                                            {                                             
                                                Console.ForegroundColor = ConsoleColor.Red;
                                            }
                                            else
                                            {
                                                Console.ResetColor();
                                            }
                          
                                            Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t{(char)('A' + j)}. {choices[j]}");
                                        }
 
                                        var key = Console.ReadKey(true).Key;


                                        if (key == ConsoleKey.UpArrow) selectedOption = (selectedOption - 1 + choices.Length) % choices.Length;
                                        else if (key == ConsoleKey.DownArrow) selectedOption = (selectedOption + 1) % choices.Length;
                                        else if (key == ConsoleKey.Enter)
                                        {
                                            answerSelected = true;

                                         
                                            char selectedChoice = (char)('A' + selectedOption);  


                                            if (selectedChoice.ToString().Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                                            {


                                                mediumPoints += 2;
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\tCorrect!.");



                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\n\t\t\t\t\t\t\t\t\t\t\t\tIncorrect.");


                                            }



                                            Console.ResetColor();
                                            Thread.Sleep(1000);


                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    }

                                }
                                else
                                {
                                    Console.WriteLine("No data found for the selected IDMQSPOT.");
                                    return;
                                }
                            }
                        }

                        Clear();
                        counter++;
                    c++;    
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }

                Console.Clear();
                ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkRed;



                if (holderPoints >= 8)
                {
                string soundFilePath2 = @"C:\congrats.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                //----- adding to SPOT LEADERBOARD

              
                string update = @"
                UPDATE spotlb 
                SET 
                    S_MEDIUMPOINTS = S_MEDIUMPOINTS + @holderPoints,
                    S_OVERALLPOINTS = S_OVERALLPOINTS + @holderPoints
                WHERE ID = @id;";

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand myCommand = new MySqlCommand(update, myConn);
                        myCommand.Parameters.AddWithValue("@id", id);       
                        myCommand.Parameters.AddWithValue("@holderPoints", holderPoints); 
                        myConn.Open();
                        int rowsAffected = myCommand.ExecuteNonQuery();
                    }




                    int t = 0;

                t:
                    if (t >= 1)
                    {
                        Clear();
                        myTitles.congrats();
                        Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\tINVALID SELECTION");
                        Console.Beep(500, 300);
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t   CONGRATULATIONS ON PASSING THIS DIFFICULTIES");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints); ;
                    }
                    else
                    {
                        Clear();
                        myTitles.congrats();
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t   CONGRATULATIONS ON PASSING THIS DIFFICULTIES");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);

                    }



                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t   PRESS X - GO TO MAIN SCREEN\n\t\t\t\t\t\t\t\t\t\t   PRESS H - NEXT DIFFICULTIES (HARD) \n\t\t\t\t\t\t\t\t\t\t   :");
                    string decidee = Console.ReadLine().ToLower();

                if (decidee.Equals("h"))
                    {



                        isSelected = "SpotHard";




                        string updateQuery = "UPDATE tbinsert SET DIFFICULTIES = @newDiff WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                            myConn.Open();
                            updateCommand.Parameters.AddWithValue("@newDiff", "Hard");
                            updateCommand.ExecuteNonQuery();
                        }

                        holderPoints = 0;
                        string updateQuery2 = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery2, myConn);

                            myConn.Open();
                            updateCommand.Parameters.AddWithValue("@newPoints", holderPoints);
                            updateCommand.ExecuteNonQuery();
                        }

                        hardSpotQuestionaire();


                    }
                    else if (decidee.Equals("x"))
                    {
                    Console.Clear();
                    myGame.fullscreen();
                    myGame.RunFirstMenu();
                }
                    else
                    {
                        t++;
                        goto t;

                    }

                }
                else
                {



                string soundFilePath2 = @"C:\gameover.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);




                int tt = 0;

            tt:
                if (tt >= 1)
                {
                    Clear();
                    myTitles.gameOver();
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\tINVALID SELECTION");
                    Console.Beep(500, 300);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t  FAILED, YOU NEED TO MEET THE REQUIRED POINTS (8)");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t     THE GAME ENDS QUESTION 6/6\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);
                }
                else
                {
                    Clear();
                    myTitles.gameOver();
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t  FAILED, YOU NEED TO MEET THE REQUIRED POINTS (8)");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t     THE GAME ENDS QUESTION 6/6\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);


                }


                Console.Write("\n\t\t\t\t\t\t\t\t\t\t  PRESS G - RETRY\n\t\t\t\t\t\t\t\t\t\t  PRESS X - GO TO MAIN SCREEN \n\t\t\t\t\t\t\t\t\t\t  :");
                string decidee = Console.ReadLine().ToLower();


                if (decidee.Equals("g"))
                    {

                        mediumPoints = 0;
                        mediumCounter = 0;
                        Mattempt = 1;
                        holderPoints = 0;

                        string updateQuery = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                            myConn.Open();
                            updateCommand.Parameters.AddWithValue("@newPoints", holderPoints);
                            updateCommand.ExecuteNonQuery();
                        }

                        goto tryMediumAgain;
                    }
                    else if (decidee.Equals("x"))
                    {
                    Console.Clear();
                    myGame.fullscreen();
                    myGame.RunFirstMenu();
                }
                    else
                    {
                        tt++;
                        goto tt;

                    }

                }

            }

       


        public void hardSpotQuestionaire()
        {
        tryHardAgain:
            int counter = 0;
            int c = 0;
             

            while (counter < 7) 
            {


                try
                {
              
                    HashSet<int> usedIds = new HashSet<int>(); 
                    string randomIdQuery = "SELECT IDHQSPOT FROM tbhardquestion_spoterror ORDER BY RAND() LIMIT 1;";
                    int randomIDQ = 0;
                    bool isUniqueIDFound = false;


                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand randomIdCommand = new MySqlCommand(randomIdQuery, myConn);

                        myConn.Open();
                        object result = randomIdCommand.ExecuteScalar();
                        if (result != null)
                        {
                            randomIDQ = Convert.ToInt32(result);
                            if (!usedIds.Contains(randomIDQ))
                            {
                                isUniqueIDFound = true;
                                usedIds.Add(randomIDQ);  
                            }
                        }
                        else
                        {
                            Console.WriteLine("No questions available in the database.");
                            return;
                        }
                    }


                  
                    string query = "SELECT IDHQSPOT, QUESTION, ANSWER FROM tbhardquestion_spoterror WHERE IDHQSPOT = @IDHQSPOT";

                    using (MySqlConnection myConn = new MySqlConnection(mycon))
                    {
                        MySqlCommand myCommand = new MySqlCommand(query, myConn);
                        myCommand.Parameters.AddWithValue("@IDHQSPOT", randomIDQ);

                        myConn.Open();

                        using (MySqlDataReader reader = myCommand.ExecuteReader())
                        {
                            if (reader.Read())  
                            {
                                string question = reader["QUESTION"].ToString().Replace("  ", "\n\t\t\t\t\t\t\t\t\t");
                                string correctAnswer = reader["ANSWER"].ToString().ToLower();

                                Console.Clear();
                                myTitles.actualGameTitle();
                                actualGameSpot();
                                if (c < 6)
                                {
                                    ResetColor();
                                    ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\tInstructions: Carefully review the entire code and locate the specific line that causes the error. Once you identify \n\t\t\t\t\t\t\t\t\t     it, type the full line of code that is causing the issue. Focus on common errors such as syntax  \n\t\t\t\t\t\t\t\t\t\t      mistakes, incorrect variable usage, or mismatched types.");
                                    ResetColor();
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\tQUESTION {counter + 1} - QUESTION 6");
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t{question + " "}\n");

                                    Write("\t\t\t\t\t\t\t\t\tCorrect Ans: " + correctAnswer);
                                    ResetColor();
                                    ForegroundColor = ConsoleColor.Red;
                                    Write("\n\t\t\t\t\t\t\t\t\tAnswer: ");
                                    string ans = Console.ReadLine().ToLower();

                                   
                                    if (ans.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                                    {
                                        hardPoints += 3;  
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\tCorrect!");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n\t\t\t\t\t\t\t\t\t\t\t\tIncorrect!");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    break;
                                }

                               
                                Thread.Sleep(1000);  
                            }
                            else
                            {
                                Console.WriteLine("No data found for the selected IDHQSPOT.");
                                return;
                            }
                        }
                    }

                    Clear();
                    counter++;
                    c++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

            }

            Console.Clear();
            ResetColor();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;


            if (holderPoints >= 12)
            {
                string soundFilePath2 = @"C:\passed.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);
                //----- adding to SPOT LEADERBOARD

                string update = @"
                UPDATE spotlb 
                SET 
                    S_HARDPOINTS = S_HARDPOINTS + @holderPoints,
                    S_OVERALLPOINTS = S_OVERALLPOINTS + @holderPoints
                WHERE ID = @id;";

                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand myCommand = new MySqlCommand(update, myConn);
                    myCommand.Parameters.AddWithValue("@id", id);        
                    myCommand.Parameters.AddWithValue("@holderPoints", holderPoints);  
                    myConn.Open();
                    int rowsAffected = myCommand.ExecuteNonQuery();
                }


                string updateQuery = "UPDATE tbinsert SET DIFFICULTIES = @newDiff, POINTS = @newPoints, SPOTCOUNTER = @SPOTCOUNTER, DONE = @newSelc WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";
                


                using (MySqlConnection myConn = new MySqlConnection(mycon))
                {
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);


                    updateCommand.Parameters.AddWithValue("@newDiff", "Easy");
                    updateCommand.Parameters.AddWithValue("@newPoints", 0);
                    updateCommand.Parameters.AddWithValue("@SPOTCOUNTER", 1);
                    updateCommand.Parameters.AddWithValue("@newSelc", "SELECT_S");

                    myConn.Open();
                    updateCommand.ExecuteNonQuery();
                }



                int t = 0;

            t:
                if (t >= 1)
                {
                    Clear();
                    myTitles.passed();
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\tINVALID SELECTION");
                    Console.Beep(500, 300);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t   CONGRATULATIONS ON PASSING THIS MODE/SUBJECT");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints); ;
                }
                else
                {
                    Clear();
                    myTitles.passed();
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t   CONGRATULATIONS ON PASSING THIS MODE/SUBJECT");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);

                }



                Console.Write("\n\t\t\t\t\t\t\t\t\t\t   PRESS 0 - TO CHOOSE MODES AGAIN\n\t\t\t\t\t\t\t\t\t\t   PRESS X - GO TO MAIN SCREEN \n\t\t\t\t\t\t\t\t\t\t   :");
                string decidee = Console.ReadLine().ToLower();

                if (decidee.Equals("0"))
                {


 
                    holderPoints = 0;

                    easyPoints = 0;
                    easyCounter = 0;
                    Eattempt = 1;

                    mediumPoints = 0;
                    mediumCounter = 0;
                    Mattempt = 1;

                    hardPoints = 0;
                    hardCounter = 0;
                    Hattempt = 1;

                

                  
                    pms.ModesSelectionCondition();

                  
                  



                }
                else if (decidee.Equals("x"))
                {
                    Console.Clear();
                    myGame.fullscreen();
                    myGame.RunFirstMenu();
                }
                else
                {
                    t++;
                    goto t;

                }

            }
            else
            {


                string soundFilePath2 = @"C:\gameover.wav";
                ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);


                int tt = 0;

            tt:
                if (tt >= 1)
                {
                    Clear();
                    myTitles.gameOver();
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\tINVALID SELECTION");
                    Console.Beep(500, 300);
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t  FAILED, YOU NEED TO MEET THE REQUIRED POINTS (12)");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t     THE GAME ENDS QUESTION 6/6\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);


                }
                else
                {
                    Clear();
                    myTitles.gameOver();
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t  FAILED, YOU NEED TO MEET THE REQUIRED POINTS (12)");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t     THE GAME ENDS QUESTION 6/6\n");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t   YOUR SCORE " + holderPoints);





                    Console.Write("\t\t\t\t\t\t\t\t\t\t  PRESS X - GO TO MAIN SCREEN\n\t\t\t\t\t\t\t\t\t\t  PRESS G - RETRY\n\t\t\t\t\t\t\t\t\t\t  :");
                    string decidee = Console.ReadLine().ToLower();

                    if (decidee.Equals("g"))
                    {

                        hardPoints = 0;
                        hardCounter = 0;
                        Hattempt = 1;
                        holderPoints = 0;

                        string updateQuery = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";

                        using (MySqlConnection myConn = new MySqlConnection(mycon))
                        {
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn);

                            myConn.Open();
                            updateCommand.Parameters.AddWithValue("@newPoints", holderPoints);
                            updateCommand.ExecuteNonQuery();
                        }

                        goto tryHardAgain;
                    }
                    else if (decidee.Equals("x"))
                    {
                        Console.Clear();
                        myGame.fullscreen();
                        myGame.RunFirstMenu();
                    }
                    else
                    {
                        tt++;
                        goto tt;


                    }

                }

            }

        }







        public void actualGameSpot()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
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
                        if (reader.Read())  
                        {
                          
                            id = Convert.ToInt32(reader["ID"]);
                            string username = reader["USER"].ToString();
                            string modes = reader["MODES"].ToString();
                            string difficulties = reader["DIFFICULTIES"].ToString();
                            points = Convert.ToInt32(reader["POINTS"]);

                            Console.ForegroundColor = ConsoleColor.White;
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

                  

                    if (isSelected.Equals("SpotEasy"))
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
                    else if (isSelected.Equals("SpotMedium"))
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
                    else if (isSelected.Equals("SpotHard"))
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

 
                    string updateQuery = "UPDATE tbinsert SET POINTS = @newPoints WHERE ID = (SELECT MAX(ID) FROM (SELECT ID FROM tbinsert) AS temp);";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, myConn))
                    {
                       
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

    }


}
