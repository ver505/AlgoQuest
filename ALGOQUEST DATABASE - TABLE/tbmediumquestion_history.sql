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
-- Table structure for table `tbmediumquestion_history`
--

CREATE TABLE IF NOT EXISTS `tbmediumquestion_history` (
  `IDMQHISTORY` int(100) NOT NULL,
  `QUESTION` varchar(100) NOT NULL,
  `A` varchar(100) NOT NULL,
  `B` varchar(100) NOT NULL,
  `C` varchar(100) NOT NULL,
  `D` varchar(100) NOT NULL,
  `ANSWER` varchar(100) NOT NULL,
  PRIMARY KEY (`IDMQHISTORY`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbmediumquestion_history`
--

INSERT INTO `tbmediumquestion_history` (`IDMQHISTORY`, `QUESTION`, `A`, `B`, `C`, `D`, `ANSWER`) VALUES
(1, 'Who developed the C# programming language?', 'James Gosling', 'Bjarne Stroustrup', 'Anders Hejlsberg', 'Guido van Rossum', 'C'),
(2, 'When was the C# programming language first introduced?', '1999', '2000', '2001', '2002', 'B'),
(3, 'C# was developed as part of which framework?', '.NET Frameworked', 'Java Runtime Environment', 'Mono Framework', 'Spring Framework', 'A'),
(4, 'What version of Visual Studio first supported C#?', 'Visual Studio 97', 'Visual Studio 6.0', 'Visual Studio .NET 2002', 'Visual Studio 2005', 'C'),
(5, 'Which programming language influenced the creation of C# the most?', 'Java', 'Python', 'C++', 'Ruby', 'A'),
(6, 'What was the primary design goal of C#?', 'Create a lightweight scripting language', 'Provide a language for system-level programming', 'Develop a language for building Windows applications', 'Enable machine learning algorithms', 'C'),
(7, 'Which of the following is a key feature introduced in C# 3.0?', 'LINQ', 'Async programming', 'Generics', 'Nullable types', 'A'),
(8, 'What is the file extension for C# source code files?', '.java', '.cs', '.cpp', '.py', 'B'),
(9, 'C# is primarily used for developing applications on which platform?', 'Android', 'Windows', 'iOS', 'Linux', 'B'),
(10, 'Which organization standardized the C# language?', 'IEEE', 'ISO/IEC', 'ANSI', 'W3C', 'B'),
(11, 'What was the initial codename for C# during its development?', 'Cool', 'Razor', 'AspNet', 'Blade', 'A'),
(12, 'What is the Common Language Runtime (CLR) in the .NET Framework?', 'A compiler', 'A runtime environment for .NET applications', 'A text editor for writing C#', 'A database system', 'B'),
(13, 'C# is classified as which type of programming language?', 'Procedural', 'Functional', 'Object-oriented', 'Assembly', 'C'),
(14, 'Which C# feature ensures that objects are managed and cleaned up automatically?', 'Pointers', 'Garbage collection', 'Destructors', 'Finalizers', 'B'),
(15, 'Which version of C# introduced async/await for asynchronous programming?', 'C# 3.0', 'C# 4.0', 'C# 5.0', 'C# 6.0', 'C'),
(16, 'Which of these is not a valid data type in C#?', 'int', 'float', 'string', 'doubletext', 'D'),
(17, 'What is the purpose of the using directive in C#?', 'Import namespaces', 'Declare variables', 'Handle exceptions', 'Create loops', 'A'),
(18, 'Which feature was introduced in C# 6.0 to simplify property access?', 'Auto-implemented properties', 'Expression-bodied members', 'LINQ', 'Generic types', 'B'),
(19, 'What is the default access modifier for members in a class in C#?', 'public', 'private', 'protected', 'internal', 'B'),
(20, 'What does the acronym "LINQ" stand for in C#?', 'Linked Integration Query', 'Language-Integrated Query', 'Logic-Initiated Query', 'List-Indexing Query', 'A'),
(21, 'What is the base class for all classes in C#?', 'Object', 'BaseClass', 'Main', 'Core', 'A'),
(22, 'Which version of .NET Framework was released alongside C# 1.0?', '.NET Framework 1.0', '.NET Framework 2.0', '.NET Framework 3.0', '.NET Framework 4.0', 'A'),
(23, 'Which C# feature allows for defining methods with the same name but different parameters?', 'Method overriding', 'Method hiding', 'Method overloading', 'Method extension', 'C'),
(24, 'What keyword in C# is used to create a new object?', 'make', 'init', 'new', 'create', 'C'),
(25, 'C# is designed to be part of which paradigm?', 'Procedural-only programming', 'Functional programming', 'General-purpose programming', 'Device driver programming', 'C'),
(26, 'Which tool is used to compile C# code?', 'CLR', 'MSBuild', 'CSC (C# Compiler)', 'VSC (Visual Studio Compiler)', 'C'),
(27, 'What is the purpose of the virtual keyword in C#?', 'Allow a method to be overridden in a derived class', 'Make a class abstract', 'Create a virtual machine', 'Indicate a thread-safe method', 'A'),
(28, 'Which keyword is used to inherit a class in C#?', 'extends', 'inherits', 'base', '(colon)', 'D'),
(29, 'What is a delegate in C#?', 'A class for file operations', 'A pointer to a method', 'A thread handler', 'A database connection class', 'B'),
(30, 'Which IDE is most commonly used for C# development?', 'Eclipse', 'IntelliJ IDEA', 'Visual Studio', 'PyCharm', 'C');
