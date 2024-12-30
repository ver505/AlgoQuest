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
-- Table structure for table `tbhardquestion_spoterror`
--

CREATE TABLE IF NOT EXISTS `tbhardquestion_spoterror` (
  `IDHQSPOT` int(100) NOT NULL,
  `QUESTION` varchar(1000) NOT NULL,
  `ANSWER` varchar(1000) NOT NULL,
  PRIMARY KEY (`IDHQSPOT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbhardquestion_spoterror`
--

INSERT INTO `tbhardquestion_spoterror` (`IDHQSPOT`, `QUESTION`, `ANSWER`) VALUES
(1, 'static void Main()  {  	int num1 = 10, num2 = 5  	Console.WriteLine(num1 + " " + num2);  }', 'int num1 = 10, num2 = 5;'),
(2, 'static void Main()  {  	int i = 1, num = 5;  	while i <= 3  	{  		Console.Write(num * i + " ");  		i++;  	}    } ', 'while (i <= 3)'),
(3, 'static void Main()  {  	int num = "10";  	Console.WriteLine(num);  }', 'int num = 10;'),
(4, 'static void Main()  {  	int i = 1, num = 5;  	do  	{  		Console.Write(num * i + " ");  		i++;  	}  	while i <= 3;    }', 'while (i <= 3);'),
(5, 'static void Main()  {  	int num1 = 10, num2 = 5  	for (int i = 1; i <= 3; i++)  	{  		Console.Write(num1 * i + " " + num2 * i + " ");  	}', '}'),
(6, ' static void Main()  {  	int num = 10;  	if num > 5  	{  		Console.WriteLine(num);  	}    }', 'if (num > 5)'),
(7, 'static void Main()  {  	int num1 = 5, num2 = 3;  	 Console.Writeline(num1 + " " + num2);  }', 'Console.WriteLine(num1 + " " + num2);'),
(8, 'static void Main()  {  	int i = 1, num = 5;  	while (i <= 3)  	{  		Console.Write(num * i + " ");  		i+;  	}    }', 'i++;'),
(9, 'static void Main()  {  	 int num = 10  	Console.WriteLine(num);  }', 'int num = 10;'),
(10, 'static void Main()  {  	int num = 5;  	if (num > 3  	{  		 Console.WriteLine("Number is greater than 3");  	}    }', 'if (num > 3)'),
(11, 'static void Main()  {  	int i = 0;  	for (; i < 3; i+)  	{  		Console.WriteLine(i);  	}    }', 'for (; i < 3; i++)'),
(12, 'static void Main()  {  	int num1 = 10;  	Console.WriteLine(num2);  }', 'Console.WriteLine(num1);'),
(13, 'static void Main()  {  	console.Writeline("Hello")  }', ' Console.WriteLine("Hello");'),
(14, 'static void Main()  {  	int num = 5;  	if (num = 10)  	{  		Console.WriteLine("Equal");  	}    }', 'if (num == 10)'),
(15, 'static void Main()  {  	int nums = { 1, 2, 3 };  	Console.WriteLine(nums[1]);  }', 'int[] nums = { 1, 2, 3 };'),
(16, 'static void Main()  {  	int num = 10;  	if (num > 5 | num < 15)  	{  	Console.WriteLine("Valid");  	}    }', 'if (num > 5 || num < 15)'),
(17, 'static void Main()  {  	int i = 0;  	do  	{  		Console.WriteLine(i);  		 i++;  	}  	while i < 5    }', 'while (i < 5);'),
(18, 'static void Main()  {  	for (int i = 0; i < 5; int i++)  	{  		 Console.WriteLine(i);  	}    }', 'for (int i = 0; i < 5; i++)'),
(19, 'static void Main()  {  	string firstName = "John", lastName = "Doe";  	Console.WriteLine("Full Name: " + firstName lastName);  }', 'Console.WriteLine("Full Name: " + firstName + " " + lastName);'),
(20, 'static void Main()  {  	int result = 10;  	Console.WriteLine("Result is: "  Result);  }', 'Console.WriteLine("Result is: " + result);');
