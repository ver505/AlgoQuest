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
-- Table structure for table `tbeasyquestion_history`
--

CREATE TABLE IF NOT EXISTS `tbeasyquestion_history` (
  `IDEQHISTORY` int(100) NOT NULL,
  `QUESTION` varchar(100) NOT NULL,
  `ANSWER` varchar(100) NOT NULL,
  `A` varchar(100) NOT NULL,
  `B` varchar(100) NOT NULL,
  PRIMARY KEY (`IDEQHISTORY`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbeasyquestion_history`
--

INSERT INTO `tbeasyquestion_history` (`IDEQHISTORY`, `QUESTION`, `ANSWER`, `A`, `B`) VALUES
(1, 'C# was developed by Microsoft as part of its .NET initiative and was officially released in 2000.', 'A', 'TRUE', 'FALSE'),
(2, 'The main designer of C# was Anders Hejlsberg.', 'A', 'TRUE', 'FALSE'),
(3, 'C# was created as an open-source language from the very beginning.', 'B', 'TRUE', 'FALSE'),
(4, 'The initial purpose of C# was to compete with Java.', 'B', 'TRUE', 'FALSE'),
(5, 'C# was originally named "Cool" before its official release.', 'A', 'TRUE', 'FALSE'),
(6, 'C# was designed to be a low-level programming language.', 'B', 'TRUE', 'FALSE'),
(7, 'C# was created with object-oriented programming as a primary focus.', 'A', 'TRUE', 'FALSE'),
(8, 'One of the goals of C# was to improve productivity for developers.', 'A', 'TRUE', 'FALSE'),
(9, 'C# is a statically typed programming language.', 'A', 'TRUE', 'FALSE'),
(10, 'The syntax of C# was heavily influenced by Visual Basic.', 'B', 'TRUE', 'FALSE'),
(11, 'C# 2.0 introduced generics, making it easier to work with type-safe data structures.', 'A', 'TRUE', 'FALSE'),
(12, 'C# 4.0 introduced the dynamic type, allowing more flexibility in data handling.', 'A', 'TRUE', 'FALSE'),
(13, 'C# 5.0 introduced support for asynchronous programming with async and await.', 'A', 'TRUE', 'FALSE'),
(14, 'C# 7.0 was the first version to support pattern matching.', 'A', 'TRUE', 'FALSE'),
(15, 'The latest versions of C# are still only compatible with Windows-based systems.', 'B', 'TRUE', 'FALSE'),
(16, 'C# became open source in 2014.', 'A', 'TRUE', 'FALSE'),
(17, 'The .NET Foundation was established to support the development of C# and related technologies.', 'A', 'TRUE', 'FALSE'),
(18, ' C# does not support contributions from the open-source community.', 'B', 'TRUE', 'FALSE'),
(19, 'C# is now maintained by both Microsoft and the open-source community.', 'A', 'TRUE', 'FALSE'),
(20, 'C# development is governed by an independent standards body.', 'A', 'TRUE', 'FALSE'),
(21, 'C# was inspired by languages such as Java, C++, and Delphi.', 'A', 'TRUE', 'FALSE'),
(22, 'C# has no similarities to Java.', 'A', 'TRUE', 'FALSE'),
(23, 'The name "C#" refers to the musical notation "C-sharp," signifying an increment or improvement.', 'A', 'TRUE', 'FALSE'),
(24, 'C# was created as a direct evolution of the C programming language.', 'B', 'TRUE', 'FALSE'),
(25, ' C# is closely tied to the development of the .NET Framework.', 'A', 'TRUE', 'FALSE'),
(26, 'C# is one of the most popular programming languages in the world.', 'A', 'TRUE', 'FALSE'),
(27, 'C# is primarily used for developing web applications and is rarely used for game development.', 'B', 'TRUE', 'FALSE'),
(28, 'Unity, a popular game engine, uses C# as its primary scripting language.', 'A', 'TRUE', 'FALSE'),
(29, 'C# is only used for desktop applications.', 'B', 'TRUE', 'FALSE'),
(30, 'C# is widely taught in universities as an introductory programming language.', 'A', 'TRUE', 'FALSE');
