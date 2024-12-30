-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 29, 2024 at 10:07 AM
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
-- Table structure for table `tbmediumquestion_guess`
--

CREATE TABLE IF NOT EXISTS `tbmediumquestion_guess` (
  `IDMQGUESS` int(100) NOT NULL,
  `QUESTION` varchar(1000) NOT NULL,
  `A` varchar(100) NOT NULL,
  `B` varchar(100) NOT NULL,
  `C` varchar(100) NOT NULL,
  `D` varchar(100) NOT NULL,
  `ANSWER` varchar(100) NOT NULL,
  PRIMARY KEY (`IDMQGUESS`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbmediumquestion_guess`
--

INSERT INTO `tbmediumquestion_guess` (`IDMQGUESS`, `QUESTION`, `A`, `B`, `C`, `D`, `ANSWER`) VALUES
(1, 'int a = 5;  int b = 3;  int c = 8;  int result = a + b * c - 2;    Console.WriteLine(result);', '27', '25', '29', '30', 'A'),
(2, 'int x = 4;  int y = 6;  int z = 2;  int result = x * y + z - 3;    Console.WriteLine(result);', '24', '23', '22', '25', 'B'),
(3, 'int a = 10;  int b = 3;  int c = 7;  int result = a - b * c + 2;    Console.WriteLine(result);', '-7', '-9', '-10', '-8', 'B'),
(4, 'int i = 6;  int j = 2;  int k = 4;  int result = (i + j) * k - 3;    Console.WriteLine(result);', '28', '30', '29', '31', 'C'),
(5, 'int a = 15;  int b = 5;  int c = 8;  int d = 3;  int result = a / b + c - d;    Console.WriteLine(result);', '7', '8', '9', '10', 'B'),
(6, 'int x = 8;  int y = 4;  int z = 6;  int result = x * y / z + 5;    Console.WriteLine(result);', '11', '10', '9', '12', 'B'),
(7, 'int a = 6;  int b = 5;  int c = 2;  int d = 8;  int result = (a * b - c) / d;    Console.WriteLine(result);', '2', '3', '4', '5', 'B'),
(8, 'int i = 3;  int j = 9;  int k = 2;  int result = i + (j * k) - 1;    Console.WriteLine(result);', '20', '19', '21', '22', 'A'),
(9, 'int p = 7;  int q = 3;  int r = 5;  int result = p * q + r - 4;    Console.WriteLine(result);', '21', '22', '23', '24', 'B'),
(10, 'int a = 12;  int b = 4;  int c = 3;  int result = a / b * c;    Console.WriteLine(result);', '8', '9', '10', '11', 'B'),
(11, 'int a = 10;  int b = 3;  int c = 5;  int d = 7;  int result = (a + b) * c - d;    Console.WriteLine(result);', '57', '56', '55', '58', 'b'),
(12, 'int x = 8;  int y = 4;  int z = 3;  int w = 2;  int result = x * y / z + w;    Console.WriteLine(result);', '13', '12', '11', '10', 'B'),
(13, 'int p = 12;  int q = 3;  int r = 4;  int s = 6;  int result = p - (q * r + s);    Console.WriteLine(result);', '-5', '-6', '-7', '-4', 'B'),
(14, 'int a = 15;  int b = 7;  int c = 3;  int d = 5;  int result = a * b / c - d;    Console.WriteLine(result);', '31', '30', '29', '32', 'B'),
(15, 'int i = 6;  int j = 9;  int k = 2;  int l = 4;  int result = (i + j - k) * l;    Console.WriteLine(result);', '50', '52', '54', '56', 'B'),
(16, 'int x = 14;  int y = 6;  int z = 3;  int w = 8;  int result = x - y + z * w;    Console.WriteLine(result);', '33', '32', '31', '34', 'B'),
(17, 'int p = 7;  int q = 4;  int r = 3;  int s = 2;  int t = 6;  int result = p * q + r - s * t;    Console.WriteLine(result);', '14', '13', '12', '15', 'B'),
(18, 'int a = 18;  int b = 6;  int c = 3;  int d = 5;  int e = 2;  int result = (a / b) + (c * d - e);    Console.WriteLine(result);', '15', '16', '17', '18', 'B'),
(19, 'int i = 20;  int j = 8;  int k = 3;  int l = 2;  int m = 5;  int result = i - (j + k) * l + m;    Console.WriteLine(result);', '7', '6', '8', '9', 'A'),
(20, 'int x = 10;  int y = 4;  int z = 3;  int w = 6;  int result = x + y * z - w;    Console.WriteLine(result);', '16', '17', '14', '15', 'A'),
(21, 'int a = 25;  int b = 5;  int c = 4;  int d = 6;  int result = a / b + c * d;    Console.WriteLine(result);', '30', '28', '29', '27', 'C'),
(22, 'int x = 14;  int y = 3;  int z = 2;  int w = 8;  int result = x - (y * z) + w;    Console.WriteLine(result);', '16', '17', '18', '19', 'A'),
(23, 'int p = 18;  int q = 6;  int r = 3;  int s = 5;  int t = 2;  int result = (p / q) * (r + s) - t;    Console.WriteLine(result);', '12', '14', '13', '15', 'C'),
(24, 'int i = 12;  int j = 4;  int k = 6;  int l = 2;  int result = i * j - k / l;    Console.WriteLine(result);', '45', '46', '47', '48', 'B'),
(25, 'int a = 8;  int b = 3;  int c = 5;  int d = 2;  int e = 7;  int result = a * b + c - d * e;    Console.WriteLine(result);', '5', '6', '4', '3', 'A'),
(26, 'int x = 15;  int y = 3;  int z = 6;  int w = 2;  int result = x - y * z / w;    Console.WriteLine(result);', '7', '6', '5', '4', 'B'),
(27, 'int p = 10;  int q = 5;  int r = 3;  int s = 8;  int result = p + q * r - s;    Console.WriteLine(result);', '17', '18', '15', '16', 'A'),
(28, 'int a = 20;  int b = 6;  int c = 2;  int d = 5;  int e = 3;  int result = a / b + c * d - e;    Console.WriteLine(result);', '8', '6', '7', '9', 'C'),
(29, 'int i = 18;  int j = 5;  int k = 3;  int l = 2;  int m = 4;  int result = (i - j) / k + l * m;    Console.WriteLine(result);', '15', '14', '13', '19', 'A'),
(30, 'int x = 12;  int y = 8;  int z = 3;  int w = 4;  int result = x + y / z * w;    Console.WriteLine(result);', '23', '25', '24', '22', 'C');
