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
-- Table structure for table `tbhardquestion_history`
--

CREATE TABLE IF NOT EXISTS `tbhardquestion_history` (
  `IDHQHISTORY` int(100) NOT NULL,
  `QUESTION` varchar(100) NOT NULL,
  `ANSWER` varchar(100) NOT NULL,
  PRIMARY KEY (`IDHQHISTORY`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbhardquestion_history`
--

INSERT INTO `tbhardquestion_history` (`IDHQHISTORY`, `QUESTION`, `ANSWER`) VALUES
(1, 'What company developed C#?', 'Microsoft'),
(2, 'Which software architect led the development of C#?', 'Hejlsberg'),
(3, 'In which year was C# first introduced?', '2000'),
(4, 'C# was originally part of which framework?', '.NET'),
(5, 'What was the first version of C# released?', '1.0'),
(6, 'C# was standardized by which organization in 2002?', 'ECMA'),
(7, 'Which keyword in C# indicates memory safety?', 'Unsafe'),
(8, 'Which company initially criticized C# as an imitation of Java?', 'Sun'),
(9, 'What is the primary extension for C# source files?', '.cs'),
(10, 'What type of language is C# classified as?', 'OOP'),
(11, 'Which IDE is most commonly associated with C# development?', 'VisualStudio'),
(12, 'What feature was introduced in C# 3.0 for querying data?', 'LINQ'),
(13, 'Which version of C# introduced asynchronous programming?', '5.0'),
(14, 'What is the name of C#''s garbage collector?', 'GC'),
(15, 'C# is heavily influenced by which programming language?', 'Java'),
(16, 'What type of programming is C# primarily designed for?', 'Managed'),
(17, 'Which keyword defines a class-level constant in C#?', 'Const'),
(18, 'What is the default access modifier for a class in C#?', 'Internal'),
(19, 'Which C# version introduced nullable reference types?', '8.0'),
(20, 'Which platform aims to make C# cross-platform?', 'Mono'),
(21, 'What is the term for converting a value type to an object in C#?', 'Boxing'),
(22, 'What is the term for converting an object back to a value type in C#?', 'Unboxing'),
(23, 'What keyword prevents a class from being inherited in C#?', 'Sealed'),
(24, 'Which keyword is used to handle exceptions in C#?', 'Catch'),
(25, 'What is the root namespace for all C# libraries?', 'System'),
(26, 'Which C# feature allows declaring unnamed methods?', 'Anonymous'),
(27, 'What is the output type of a LINQ query?', 'IEnumerable'),
(28, 'Which tool compiles C# code?', 'CSC'),
(29, 'What does C# rely on for memory management?', 'CLR'),
(30, 'Which type of inheritance is supported by C#?', 'Single');
