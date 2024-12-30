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
-- Table structure for table `tbmediumquestion_spoterror`
--

CREATE TABLE IF NOT EXISTS `tbmediumquestion_spoterror` (
  `IDMQSPOT` int(100) NOT NULL,
  `QUESTION` varchar(1000) NOT NULL,
  `A` varchar(1000) NOT NULL,
  `B` varchar(100) NOT NULL,
  `C` varchar(100) NOT NULL,
  `D` varchar(100) NOT NULL,
  `ANSWER` varchar(100) NOT NULL,
  PRIMARY KEY (`IDMQSPOT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbmediumquestion_spoterror`
--

INSERT INTO `tbmediumquestion_spoterror` (`IDMQSPOT`, `QUESTION`, `A`, `B`, `C`, `D`, `ANSWER`) VALUES
(1, 'int num = 10;  if (num > 5  {  	Console.WriteLine("Greater");  }', 'Missing closing parenthesis in the if statement', 'Missing curly braces for the if statement', 'num > 5 should be num == 5', 'Console should be lowercase', 'A'),
(2, 'string name = "John";  int length = name.Length();  Console.WriteLine(length);', 'Length is a method and needs parentheses', 'Length is a property, not a method', 'name should be declared as an int', 'The semicolon is missing after name.Length()', 'B'),
(3, 'int[] arr = { 1, 2, 3 };  Console.WriteLine(arr[3]);', 'Array index should be within bounds', 'arr should be declared with size 4', 'The arr[3] index should be arr[2]', 'Arrays should start at index 1', 'A'),
(4, 'double result = 5 / 2;  Console.WriteLine(result);', 'The division result should be cast to int', 'The division should use the Math.Floor method', 'The result will be an integer, not a double', 'This is a correct code', 'C'),
(5, 'int[] nums = new int[5];  nums[5] = 10;  Console.WriteLine(nums[5]);', 'The array should be initialized with a size of 6', 'The index must be between 0 and 4', 'The array index must be 1-based', 'nums[5] should be nums[4]', 'B'),
(6, 'string str = "Hello";  str = null;  Console.WriteLine(str.Length);', 'Cannot access Length on a null string', 'str should be initialized with an empty string', 'str must be checked for null before accessing Length', 'str should be a StringBuilder', 'A'),
(7, 'int x = 10;  if x == 10  {  		Console.WriteLine("Equal");  }', '== should be replaced with =', 'Missing parentheses in the if condition', 'The if statement should use else instead', 'The Console.WriteLine() method should be called inside a for loop', 'B'),
(8, 'for (int i = 0; i < 10; i++)    	 Console.WriteLine(i);  Console.WriteLine("Done");  ', 'The second Console.WriteLine should be inside the loop', 'Missing curly braces around the loop', 'The loop condition should be i <= 10', 'The semicolon after Console.WriteLine(i); should be removed', 'B'),
(9, 'int[] arr = {1, 2, 3, 4};  arr[4] = 5;', 'arr[4] is out of bounds', 'arr should be initialized with 5 elements', 'arr[4] should be arr[3]', 'The array should be a List<int> instead', 'A'),
(10, 'string[] names = { "Alice", "Bob", "Charlie" };  Console.WriteLine(names[3]);', 'Index 3 is out of bounds for the array', 'The array should have 4 elements', 'The array should be sorted first', 'names[3] should be names[2]', 'A'),
(11, 'string greeting = "Hello";  greeting = 123;  Console.WriteLine(greeting);', 'Cannot assign an integer to a string variable', 'The type of greeting should be var', 'greeting should be initialized with an integer', 'The semicolon after greeting = 123 is missing', 'A'),
(12, 'int num1 = 10;  int num2 = 20;  Console.WriteLine num1 + num2;', 'Missing parentheses around the Console.WriteLine statement', 'num1 should be a double', 'This is correct code', 'The + operator should be *', 'A'),
(13, 'int[] arr = new int[3];  arr[3] = 5;  Console.WriteLine(arr[3]);', 'Array index should be between 0 and 2', 'The array size should be 4', 'Array indices start from 1, not 0', 'This is correct code', 'A'),
(14, 'string[] colors = { "Red", "Green", "Blue" };  colors[3] = "Yellow";  Console.WriteLine(colors[3]);', 'colors[3] is out of bounds', 'colors should be initialized with 4 elements', 'The array should be declared as List<string>', 'The correct index for "Yellow" is 2', 'A'),
(15, 'The correct index for "Yellow" is 2  if (number > 5)  Console.WriteLine("Greater");  Console.WriteLine("Done");', 'The second Console.WriteLine should be inside the if statement', 'Missing curly braces around the if block', 'The else block should be used instead', 'The first Console.WriteLine should be removed', 'B'),
(16, 'int num = "123";  Console.WriteLine(num);', 'Cannot assign a string to an integer variable', 'num should be a string instead', 'int.Parse("123") should be used to convert', 'This is correct code', 'A'),
(17, 'string name = "Alice";  Console.WriteLine(name[5]);', 'Index 5 is out of bounds for the string', 'name should be a char instead of string', 'name[5] should be name[4]', 'The string should have at least 6 characters', 'A'),
(18, 'bool flag = true;  if flag  {  	Console.WriteLine("True");  }', 'Missing parentheses around the if condition', 'flag should be a bool?', 'The Console.WriteLine method is incorrect', 'This is correct code', 'A'),
(19, 'double result = 10 / 3;  Console.WriteLine(result);', 'The result will be a double, but this is integer division', 'The result should be cast to int', '10 / 3 should be 10.0 / 3 for correct double division', 'This is correct code', 'C'),
(20, 'List<int> numbers = new List<int>();  numbers.Add(5);  numbers[1] = 10;', 'List indices start at 1, not 0', 'numbers[1] should be numbers[0]', 'You cannot add values directly to the list', 'This is correct code', 'B'),
(21, 'int[] arr = new int[5];  arr[5] = 10;  Console.WriteLine(arr[5]);', 'The array size should be increased', 'Array index should be between 0 and 4', 'The array should be a List<int>', 'The index arr[5] is correct', 'B'),
(22, 'string text = "Programming";  int length = text.Length;  Console.WriteLine(length());', 'Length is a property, not a method', 'Missing semicolon after Console.WriteLine(length)', 'text.Length() should be text.Length', 'length() should be replaced by length', 'A'),
(23, 'bool isValid = true;  if (isValid)  		Console.WriteLine("Valid");  Console.WriteLine("End");', 'The second Console.WriteLine("End") should be inside the if statement', 'Missing curly braces around the if block', 'isValid should be declared as a string', 'The else block should be used', 'B'),
(24, 'int x = 10;  int y = 0;  int result = x / y;  Console.WriteLine(result);', 'Dividing by zero causes a runtime error', 'The division should use Math.Divide(x, y)', 'y should be assigned a non-zero value', 'This is correct code', 'A'),
(25, 'string message = "Hello";  int messageLength = message.ToUpper;  Console.WriteLine(messageLength);', 'ToUpper is a method and needs parentheses', 'ToUpper should be ToLower', 'messageLength should be declared as string', 'messageLength should be int', 'A'),
(26, 'int[] nums = { 1, 2, 3, 4 };  nums = nums.Remove(3);  Console.WriteLine(nums.Length);', 'Remove is not a valid method for arrays', 'The array should be resized before removing an element', 'Remove should be RemoveAt for arrays', 'nums should be a List<int>', 'A'),
(27, 'int[] numbers = new int[4];  numbers[0] = 10;  numbers[1] = 20;  numbers[4] = 30;  Console.WriteLine(numbers[4]);', 'Array index should be between 0 and 3', 'The array should be resized to 5 elements', 'numbers[4] is correct', 'numbers[4] should be numbers[3]', 'A'),
(28, 'double value = 10 / 3;  Console.WriteLine(value);', 'The division result should be cast to double', 'value should be a float', 'The result should be 10.0 / 3', 'This is correct code', 'A'),
(29, 'int[] arr = { 1, 2, 3 };  Console.WriteLine(arr[-1]);', 'Negative indices are not allowed in C# arrays', 'Array indices should start from 1', 'arr[-1] should be arr[0]', 'This is correct code', 'A'),
(30, 'int x = 10;  if (x == 10)  	Console.WriteLine("Ten");  else  	Console.WriteLine("Not Ten");', 'x is not declared', 'Missing curly braces around if and else', 'else block should be removed', 'The condition x == 10 should be x != 10', 'B');
