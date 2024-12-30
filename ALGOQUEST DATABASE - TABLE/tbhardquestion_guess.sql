-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 29, 2024 at 10:06 AM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `algoquest`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbhardquestion_guess`
--

CREATE TABLE IF NOT EXISTS `tbhardquestion_guess` (
  `IDHQGUESS` int(100) NOT NULL,
  `QUESTION` varchar(1000) NOT NULL,
  `ANSWER` varchar(1000) NOT NULL,
  PRIMARY KEY (`IDHQGUESS`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbhardquestion_guess`
--

INSERT INTO `tbhardquestion_guess` (`IDHQGUESS`, `QUESTION`, `ANSWER`) VALUES
(1, 'static void Main()  {    	int num1 = 2, num2 = 4;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 * i + " " + num2 * i + " ");  	}    }', '2 4 4 8 6 12'),
(2, 'static void Main()  {  	int num1 = 6, num2 = 3;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 / i + " " + num2 / i + " ");  	}    }', '6 3 3 1 2 1'),
(3, 'static void Main()  {  	 int num1 = 1, num2 = 2;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 + i + " " + num2 * i + " ");  	}    }', '2 2 3 4 4 6'),
(4, 'static void Main()  {  	int num1 = 3, num2 = 5;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 * i + " " + num2 - i + " ");  	}    }', '3 4 6 3 9 2'),
(5, 'static void Main()  {  	int num1 = 2, num2 = 8;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 * i + " " + num2 / i + " ");  	}    }', '2 8 4 4 6 2'),
(6, 'static void Main()  {  	int num1 = 5, num2 = 10;  	for (int i = 1; i <= 4; i++)  	{  		Console.Write(num1 * i + " " + num2 / i + " ");  	}    }', '5 10 10 5 15 3 20 2'),
(7, 'static void Main()  {  	int num1 = 7, num2 = 3;  	for (int i = 1; i <= 4; i++)  	{  		Console.Write(num1 - i + " " + num2 + i + " ");  	}    }', '6 4 5 5 4 6 3 7'),
(8, 'static void Main()  {  	 int num1 = 1, num2 = 3;  	for (int i = 1; i <= 4; i++)  	{  		Console.Write(num1 + i + " " + num2 * i + " ");  	}    }', '2 3 3 6 4 9 5 12'),
(9, 'static void Main()  {  	int num1 = 2, num2 = 6;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 * i + " " + num2 - i + " ");  	}    }', '2 5 4 4 6 3'),
(10, 'static void Main()  {  	int num1 = 4, num2 = 9;  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 + i + " " + num2 / i + " ");  	}    }', '5 9 6 4 7 3'),
(11, 'static void Main()  {  	int num1 = 1, num2 = 2, i = 1;  	while (i <= 3)  	{  		 Console.Write(num1 * i + " " + num2 * i + " ");  		i++;  	}    }  ', '1 2 2 4 3 6'),
(12, ' static void Main()  {  	int num1 = 5, num2 = 3;  	for (int i = 1; i <= 3; i++)  	{  		if (i % 2 == 0)  		{  			Console.Write(num1 * i + " ");  		}  		else  		{  			Console.Write(num2 * i + " ");  		}  	}    }  ', '5 6 15'),
(13, 'static void Main()  {  	int num1 = 3, num2 = 4, i = 1;  	do  	{  		 Console.Write(num1 * i + " " + num2 * i + " ");  		i++;  	}  	while (i <= 3);    }', '3 4 6 8 9 12'),
(14, 'static void Main()  {  	int num1 = 2, num2 = 6, i = 1;  	while (i <= 3)  	{  		if (i == 2)  		{  			 Console.Write(num1 * i + " ");  		}  		else  		{  			Console.Write(num2 / i + " ");  		}  		i++;  	}    }', '6 12 2'),
(15, 'static void Main()  {  	int num1 = 7, num2 = 3;  	for (int i = 1; i <= 3; i++)  	{  		if (i % 2 != 0)  		{  			Console.Write(num1 * i + " ");  		}  		else  		{  			 Console.Write(num2 + i + " ");  		}  	}    }', '7 5 21'),
(16, 'static void Main()  {  	int num1 = 8, num2 = 4, i = 1;  	 while (i <= 3)  	{  		Console.Write(num1 - i + " " + num2 + i + " ");  		 i++;  	}    }', '7 5 6 6 5 7'),
(17, 'static void Main()  {   	int num1 = 2, num2 = 6;  	 for (int i = 1; i <= 3; i++)  	{  		 if (i % 2 == 0)  		{  			Console.Write(num1 * i + " ");  		}  		else  		{  			Console.Write(num2 * i + " ");  		}  	}    }', '6 6 12'),
(18, 'static void Main()  {  	int num1 = 5, num2 = 7, i = 1;  	do  	{  		Console.Write(num1 + i + " " + num2 - i + " ");  		i++;  	}  	 while (i <= 3);    }', '6 6 7 5 8 4'),
(19, 'static void Main()  {  	 int num1 = 10, num2 = 5, i = 1;  	while (i <= 3)  	{  		Console.Write(num1 / i + " " + num2 + i + " ");  		i++;  	}    }', '10 6 5 7 3 8'),
(20, 'static void Main()  {  	int num1 = 9, num2 = 2, i = 1;  	while (i <= 3)  	{  		if (i % 2 != 0)  		{  			Console.Write(num1 - i + " ");  		}  		else  		{  			 Console.Write(num2 + i + " ");  		}  		i++;  	}    }', '8 4 7');
