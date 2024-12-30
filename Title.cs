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
     class Title
    {

        string mycon = "datasource=localhost;Database=algoquest;username=root;convert zero datetime=true";

        public void printTitle()
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

        }

        public void printTitleforGame()
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
            Console.Write("\t\t    ONCE YOU PRESS ANYKEY EXCEPT FOR DOWN ARROW YOU NEED TO FINISH CREATING USERNAME..");


        }


        public void actualGameTitle()
        {
            ForegroundColor = ConsoleColor.DarkCyan;

            string title = @" 

                  █████╗ ██╗      ██████╗  ██████╗  ██████╗ ██╗   ██╗███████╗███████╗████████╗
                 ██╔══██╗██║     ██╔════╝ ██╔═══██╗██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
                 ███████║██║     ██║  ███╗██║   ██║██║   ██║██║   ██║█████╗  ███████╗   ██║   
                 ██╔══██║██║     ██║   ██║██║   ██║██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   
                 ██║  ██║███████╗╚██████╔╝╚██████╔╝╚██████╔╝╚██████╔╝███████╗███████║   ██║   
                 ╚═╝  ╚═╝╚══════╝ ╚═════╝  ╚═════╝  ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   
                                                                       ";

            // Get console window size (full screen)
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Clear the screen first
            Console.Clear();

            // Calculate the padding needed to center the title horizontally and vertically
            int paddingX = (consoleWidth - title.Split('\n')[0].Length) / 4; // Horizontal padding based on the first line's length
            int paddingY = consoleHeight / 15; // Vertically centered (1/4th down the screen)

            // Set cursor position and print the title line by line
            foreach (string line in title.Split('\n'))
            {
                Console.SetCursorPosition(paddingX, paddingY);
                Console.WriteLine(line);
                paddingY++; // Increment Y to move to the next line
            }

        }



        public void gameOver()
        {

            ForegroundColor = ConsoleColor.DarkRed;
            BackgroundColor = ConsoleColor.Black;


            string gameover = @" 

                 ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
                ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
                ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
                ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
                ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
                 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝
                                                                              ";

            Console.WriteLine(gameover);

            // Get console window size (full screen)
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Clear the screen first
            Console.Clear();

            // Calculate the padding needed to center the title horizontally and vertically
            int paddingX = (consoleWidth - gameover.Split('\n')[0].Length) / 4; // Horizontal padding based on the first line's length
            int paddingY = consoleHeight / 15; // Vertically centered (1/4th down the screen)

            // Set cursor position and print the title line by line
            foreach (string line in gameover.Split('\n'))
            {
                Console.SetCursorPosition(paddingX, paddingY);
                Console.WriteLine(line);
                paddingY++; // Increment Y to move to the next line
            }




        }


        public void congrats()
        {

            ForegroundColor = ConsoleColor.DarkCyan;
            BackgroundColor = ConsoleColor.Black;


            string congrats = @" 

         ██████╗ ██████╗ ███╗   ██╗ ██████╗ ██████╗  █████╗ ████████╗██╗   ██╗██╗      █████╗ ████████╗██╗ ██████╗ ███╗   ██╗███████╗
        ██╔════╝██╔═══██╗████╗  ██║██╔════╝ ██╔══██╗██╔══██╗╚══██╔══╝██║   ██║██║     ██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝
        ██║     ██║   ██║██╔██╗ ██║██║  ███╗██████╔╝███████║   ██║   ██║   ██║██║     ███████║   ██║   ██║██║   ██║██╔██╗ ██║███████╗
        ██║     ██║   ██║██║╚██╗██║██║   ██║██╔══██╗██╔══██║   ██║   ██║   ██║██║     ██╔══██║   ██║   ██║██║   ██║██║╚██╗██║╚════██║
        ╚██████╗╚██████╔╝██║ ╚████║╚██████╔╝██║  ██║██║  ██║   ██║   ╚██████╔╝███████╗██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║███████║
         ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝
";

            Console.WriteLine(congrats);

            // Get console window size (full screen)
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Clear the screen first
            Console.Clear();

            // Calculate the padding needed to center the title horizontally and vertically
            int paddingX = (consoleWidth - congrats.Split('\n')[0].Length) / 6; // Horizontal padding based on the first line's length
            int paddingY = consoleHeight / 15; // Vertically centered (1/4th down the screen)

            // Set cursor position and print the title line by line
            foreach (string line in congrats.Split('\n'))
            {
                Console.SetCursorPosition(paddingX, paddingY);
                Console.WriteLine(line);
                paddingY++; // Increment Y to move to the next line
            }




        }



        public void passed()
        {


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;

            string art = @"




         ██████╗ ██████╗ ███╗   ██╗ ██████╗ ██████╗  █████╗ ████████╗██╗   ██╗██╗      █████╗ ████████╗██╗ ██████╗ ███╗   ██╗███████╗
        ██╔════╝██╔═══██╗████╗  ██║██╔════╝ ██╔══██╗██╔══██╗╚══██╔══╝██║   ██║██║     ██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝
        ██║     ██║   ██║██╔██╗ ██║██║  ███╗██████╔╝███████║   ██║   ██║   ██║██║     ███████║   ██║   ██║██║   ██║██╔██╗ ██║███████╗
        ██║     ██║   ██║██║╚██╗██║██║   ██║██╔══██╗██╔══██║   ██║   ██║   ██║██║     ██╔══██║   ██║   ██║██║   ██║██║╚██╗██║╚════██║
        ╚██████╗╚██████╔╝██║ ╚████║╚██████╔╝██║  ██║██║  ██║   ██║   ╚██████╔╝███████╗██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║███████║
         ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝

                                                                    +##+                              
                                                       +##+        ######        +##+               
                                                        +##+       ######       +##+               
                                                         ####+   ##########   +####                
                                                         #####-#############-#####                 
                                                         #####--###########--#####                 
                                                          ##++---##++##++##---++##                 
                                                          ##+-------+##+-------+##                 
                                                           ##+--##+--####--##+--##                 
                                                           ######################                 
                                                           ----------------------                 
                                                           ######################                 
                                                           ++++++++++++++++++++++                 

                   
";


            Console.Clear();

            // Get console dimensions
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Split art into lines
            string[] artLines = art.Split('\n');
            int artWidth = artLines[0].Length;
            int artHeight = artLines.Length;

            // Calculate starting positions for centering
            int startX = (consoleWidth - artWidth) / 6;
            int startY = (consoleHeight - artHeight) / 15;

            // Print each line of art, centered
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < artLines.Length; i++)
            {
                Console.SetCursorPosition(Math.Max(startX, 0), startY + i);
                Console.WriteLine(artLines[i]);
            }


        }



        public void finishedAll()
        {
            string soundFilePath2 = @"C:\outrocredits.wav";
            game myGame = new game();
            ThreadPool.QueueUserWorkItem(myGame.ForEnteringTheNameSounds, soundFilePath2);

            string read = "SELECT USER FROM tbinsert WHERE ID = (SELECT MAX(ID) FROM tbinsert)";
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
                        username = reader["USER"].ToString();





                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.BackgroundColor = ConsoleColor.Black;
                        //sadya yan
                        string art = $@"

                       +##+                              
          +##+        ######        +##+              
           +##+       ######       +##+               
            ####+   ##########   +####                                                                                                                  
            #####-#############-#####                             CONGRATULATIONS {username}!                                                                 ABOUT THIS GAME
            #####--###########--#####                              
            ##++---##++##++##---++##                 YOU FINISHED ALL OF THE MODES AND DIFFICULTIES.                                    A QUIZ GAME CREATED WITH PASSION AND PURPOSE
            ##+-------+##+-------+##                                                                                          
             ##+--##+--####--##+--##                         THANKYOU FOR PLAYING THIS GAME.                        ALGOQEUST is not just any quiz game, it's a project crafted as part of our journey in
             ######################                                                                                             
             ----------------------                                    THE END!                                              BS Computer Science. We designed this game to test knowledge, spark 
             ######################                                                                                             
             ++++++++++++++++++++++                                                                                                 curiosity, and deliver a fun and engaging experience.                                 
                                                                                                                                         
                       +##+                                     
          +##+        ######        +##+                          
           +##+       ######       +##+               
            ####+   ##########   +####                                  < NOTE >
            #####-#############-#####                 
            #####--###########--#####                    IF YOUR SCORE IS HIGHER THAN OTHER PLAYERS                        Educational and Fun: A blend of learning across a wide range of MODES/SUBJECT
             ##++---##++##++##---++##                                                                                                  
             ##+-------+##+-------+##                 YOUR NAME WILL POP UP ON THE TOP 10 LEADERBOARDS                        Custom Made Questions: Curated to challenge players in all DIFFICULTIES.
              ##+--##+--####--##+--##                           
              ######################                             RANKING PER MODES/SUBJECT                             Student Innovation: Developed as a creative project to showcase our skills and passion.
              ----------------------                 
              ######################                 
              ++++++++++++++++++++++      

                       +##+                              
          +##+        ######        +##+               
           +##+       ######       +##+               
            ####+   ##########   +####                
            #####-#############-#####                    THIS GAME WAS PRESENTED BY: ALGOQUEST TEAM                             We hope you enjoy playing this game as much as we enjoyed creating it.
            #####--###########--#####                                  
             ##++---##++##++##---++##                               - JOHN VER LAYAG -                                              
             ##+-------+##+-------+##                                 
              ##+--##+--####--##+-##                                - CLARELL CANTRE -                                                           ALL RIGHTS RESERVED © 2024 - 2025
              ######################                                                          
              ----------------------                                - MELVIN ALMARIO -     
              ######################                            
              ++++++++++++++++++++++    

                             
                  
";

                        Console.Clear();


                        // Get console dimensions
                        int consoleWidth = Console.WindowWidth;
                        int consoleHeight = Console.WindowHeight;

                        // Split art into lines
                        string[] artLines = art.Split('\n');
                        int artWidth = artLines[0].Length;
                        int artHeight = artLines.Length;

                        // Calculate starting positions for centering
                        int startX = (consoleWidth - artWidth) / 1;
                        int startY = (consoleHeight - artHeight) / 15;

                        // Print each line of art, centered
                        Console.SetCursorPosition(0, 0);
                        for (int i = 0; i < artLines.Length; i++)
                        {
                            Console.SetCursorPosition(Math.Max(startX, 0), startY + i);
                            Console.WriteLine(artLines[i]);
                        }

                        //Console.ResetColor();
                        //Console.ReadKey();
                    }

                }
            }
        }

    }
}
