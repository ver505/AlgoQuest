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
-- Table structure for table `tbeasyquestion_guess`
--

CREATE TABLE IF NOT EXISTS `tbeasyquestion_guess` (
  `IDEQGUESS` int(100) NOT NULL,
  `QUESTION` varchar(100) NOT NULL,
  `ANSWER` varchar(100) NOT NULL,
  `A` varchar(100) NOT NULL,
  `B` varchar(100) NOT NULL,
  PRIMARY KEY (`IDEQGUESS`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbeasyquestion_guess`
--

INSERT INTO `tbeasyquestion_guess` (`IDEQGUESS`, `QUESTION`, `ANSWER`, `A`, `B`) VALUES
(1, 'int a = 10;  int b = 3;  int sum = a * b;    Console.WriteLine(sum);    Output is 30?', 'TRUE', 'TRUE', 'FALSE'),
(2, 'int a = 5;  int b = 8;  int diff = b - a;    Console.WriteLine(diff);    Output is 4?', 'FALSE', 'TRUE', 'FALSE'),
(3, 'int a = 12;  int b = 6;  int div = a / b;    Console.WriteLine(div);    Output is 3?', 'TRUE', 'TRUE', 'FALSE'),
(4, 'int x = 4;  int y = 2;  int z = x * y + 1;    Console.WriteLine(z);    Output is 9?', 'TRUE', 'TRUE', 'FALSE'),
(5, 'int i = 5;  int j = 3;  int result = i + j * 2;    Console.WriteLine(result);    Output is 16?', 'FALSE', 'TRUE', 'FALSE'),
(6, 'int a = 10;  int b = 3;  int sum = a + b;    Console.WriteLine(sum);    Output is 7?', 'FALSE', 'TRUE', 'FALSE'),
(7, 'int x = 8;  int y = 2;  int z = x % y;    Console.WriteLine(z);    Output is 1?', 'FALSE', 'TRUE', 'FALSE'),
(8, 'int p = 3;  int q = 4;  int r = p + q * 2;    Console.WriteLine(r);    Output is 14?', 'TRUE', 'TRUE', 'FALSE'),
(9, 'int m = 9;  int n = 3;  int res = m / n;    Console.WriteLine(res);    Output is 2?', 'FALSE', 'TRUE', 'FALSE'),
(10, 'int x = 5;  int y = 5;  int sum = x + y + 3;    Console.WriteLine(sum);    Output is 13?', 'TRUE', 'TRUE', 'FALSE'),
(11, 'int a = 6;  int b = 2;  int sum = a * b;    Console.WriteLine(sum);    Output is 8?', 'FALSE', 'TRUE', 'FALSE'),
(12, 'int x = 7;  int y = 2;  int sum = x / y;    Console.WriteLine(sum);    Output is 3?', 'TRUE', 'TRUE', 'FALSE'),
(13, 'int a = 10;  int b = 3;  int res = a % b;    Console.WriteLine(res);    Output is 1?', 'TRUE', 'TRUE', 'FALSE'),
(14, 'int x = 8;  int y = 4;  int result = x - y * 2;    Console.WriteLine(result);    Output is 0?', 'TRUE', 'TRUE', 'FALSE'),
(15, 'int i = 7;  int j = 4;  int sum = i + j;    Console.WriteLine(sum);    Output is 12?', 'FALSE', 'TRUE', 'FALSE'),
(16, 'int a = 10;  int b = 5;  int diff = a - b + 1;    Console.WriteLine(diff);    Output is 6?', 'TRUE', 'TRUE', 'FALSE'),
(17, 'int p = 3;  int q = 5;  int res = p * q - 2;    Console.WriteLine(res);    Output is 13?', 'FALSE', 'TRUE', 'FALSE'),
(18, 'int i = 8;  int j = 3;  int res = i - j;    Console.WriteLine(res);    Output is 6?', 'FALSE', 'TRUE', 'FALSE'),
(19, 'int a = 6;  int b = 7;  int res = a * b / 2;    Console.WriteLine(res);    Output is 21?', 'TRUE', 'TRUE', 'FALSE'),
(20, 'int x = 10;  int y = 3;  int res = x / y;    Console.WriteLine(res);    Output is 3?', 'TRUE', 'TRUE', 'FALSE'),
(21, 'int i = 4;  int j = 5;  int res = i + j - 1;    Console.WriteLine(res);    Output is 8?', 'TRUE', 'TRUE', 'FALSE'),
(22, 'int a = 3;  int b = 4;  int c = a * b + 2;    Console.WriteLine(c);    Output is 16?', 'FALSE', 'TRUE', 'FALSE'),
(23, 'int i = 9;  int j = 2;  int result = i / j;    Console.WriteLine(result);    Output is 5?', 'FALSE', 'TRUE', 'FALSE'),
(24, 'int a = 5;  int b = 6;  int c = a + b / 2;    Console.WriteLine(c);    Output is 8?', 'TRUE', 'TRUE', 'FALSE'),
(25, 'int x = 10;  int y = 2;  int res = x - y + 1;    Console.WriteLine(res);    Output is 9?', 'TRUE', 'TRUE', 'FALSE'),
(26, 'int a = 15;  int b = 5;  int res = a / b;    Console.WriteLine(res);    Output is 3?', 'FALSE', 'TRUE', 'FALSE'),
(27, 'int p = 6;  int q = 7;  int res = p * q - 5;    Console.WriteLine(res);    Output is 37?', 'FALSE', 'TRUE', 'FALSE'),
(28, 'int i = 3;  int j = 8;  int res = i * j - 4;    Console.WriteLine(res);    Output is 20?', 'FALSE', 'TRUE', 'FALSE'),
(29, 'int a = 8;  int b = 6;  int res = a % b;    Console.WriteLine(res);    Output is 2?', 'TRUE', 'TRUE', 'FALSE'),
(30, 'int i = 5;  int j = 10;  int sum = i + j * 2;    Console.WriteLine(sum);    Output is 25?', 'FALSE', 'TRUE', 'FALSE');
