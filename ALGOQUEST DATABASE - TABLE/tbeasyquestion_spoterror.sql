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
-- Table structure for table `tbeasyquestion_spoterror`
--

CREATE TABLE IF NOT EXISTS `tbeasyquestion_spoterror` (
  `IDEQSPOT` int(100) NOT NULL,
  `QUESTION` varchar(1000) NOT NULL,
  `ANSWER` varchar(1000) NOT NULL,
  `A` varchar(100) NOT NULL,
  `B` varchar(100) NOT NULL,
  PRIMARY KEY (`IDEQSPOT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbeasyquestion_spoterror`
--

INSERT INTO `tbeasyquestion_spoterror` (`IDEQSPOT`, `QUESTION`, `ANSWER`, `A`, `B`) VALUES
(1, 'Console.WriteLine("Hello World!");', 'TRUE', 'TRUE', 'FALSE'),
(2, 'int num = Console.ReadLine();', 'FALSE', 'TRUE', 'FALSE'),
(3, 'double value = 5.5;', 'TRUE', 'TRUE', 'FALSE'),
(4, 'string message = "Hello " + name;', 'TRUE', 'TRUE', 'FALSE'),
(5, 'int[] arr = {1, 2, 3, 4};  Console.WriteLine(arr[5]);', 'FALSE', 'TRUE', 'FALSE'),
(6, 'int num = 10;  if (num = 5)  {  	Console.WriteLine("True");  }', 'FALSE', 'TRUE', 'FALSE'),
(7, 'for (int i = 0; i < 10; i++)  {  	Console.WriteLine(i);  }', 'TRUE', 'TRUE', 'FALSE'),
(8, 'string name = "Alice";  name = 10;', 'FALSE', 'TRUE', 'FALSE'),
(9, 'double result = 10 / 3;', 'TRUE', 'TRUE', 'FALSE'),
(10, 'int a = 5;  a = a * 2;  Console.WriteLine(a);', 'TRUE', 'TRUE', 'FALSE'),
(11, 'string user = "John";  Console.WriteLine(User);', 'FALSE', 'TRUE', 'FALSE'),
(12, 'int x = 5;  Console.WriteLine(x > 0 ? "Positive" : "Negative");', 'TRUE', 'TRUE', 'FALSE'),
(13, 'int[] arr = {1, 2, 3};  Console.WriteLine(arr[3]);', 'FALSE', 'TRUE', 'FALSE'),
(14, 'bool flag = true;  {  	 Console.WriteLine("Flag is true");  }', 'FALSE', 'TRUE', 'FALSE'),
(15, 'int a = 10;  int b = 0;  Console.WriteLine(a / b);', 'FALSE', 'TRUE', 'FALSE'),
(16, 'Console.Write("Enter your age: ");  int age = Convert.ToInt32(Console.ReadLine());', 'TRUE', 'TRUE', 'FALSE'),
(17, 'int[] numbers = { 5, 10, 15 };  Console.WriteLine(numbers[4]);', 'FALSE', 'TRUE', 'FALSE'),
(18, 'int[] nums = new int[5];  nums[3] = 100  Console.WriteLine(nums[3]);', 'TRUE', 'TRUE', 'FALSE'),
(19, 'Console.WriteLine("The number is" + num);', 'FALSE', 'TRUE', 'FALSE'),
(20, 'float price = 10.5f;', 'TRUE', 'TRUE', 'FALSE'),
(21, 'for (int i = 0; i < 5; i++)  {  	Console.WriteLine("i is " + i);  }', 'TRUE', 'TRUE', 'FALSE'),
(22, 'string input = Console.ReadLine();  int number = Convert.ToInt32(input);', 'TRUE', 'TRUE', 'FALSE'),
(23, 'string[] colors = {"Red", "Green", "Blue"};  Console.WriteLine(colors[2]);', 'TRUE', 'TRUE', 'FALSE'),
(24, 'string s = "Hello";  int length = s.Length();', 'FALSE', 'TRUE', 'FALSE'),
(25, 'int[] arr = {1, 2, 3};  arr[2] = 5;  Console.WriteLine(arr[2]);', 'TRUE', 'TRUE', 'FALSE'),
(26, 'Console.WriteLine("Enter your name:");  string name = Console.ReadLine();  Console.WriteLine("Hello, " + name);', 'TRUE', 'TRUE', 'FALSE'),
(27, 'int[] nums = new int[3];  nums[0] = 1;  nums[1] = 2;  nums[2] = 3;  Console.WriteLine(nums[3]);', 'FALSE', 'TRUE', 'FALSE'),
(28, 'int x = 10;  if (x = 10)  {  		Console.WriteLine("Correct");  }', 'FALSE', 'TRUE', 'FALSE'),
(29, 'string greeting = "Hello, " + "World!";  Console.WriteLine(greeting);', 'TRUE', 'TRUE', 'FALSE'),
(30, 'double total = 10.5;  int result = (int)total;  Console.WriteLine(result);', 'TRUE', 'TRUE', 'FALSE');
