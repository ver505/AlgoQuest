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
-- Table structure for table `tbinsert`
--

CREATE TABLE IF NOT EXISTS `tbinsert` (
  `ID` int(50) NOT NULL AUTO_INCREMENT,
  `USER` varchar(50) NOT NULL,
  `MODES` varchar(50) NOT NULL,
  `DIFFICULTIES` varchar(100) NOT NULL,
  `POINTS` int(100) NOT NULL,
  `HISTORYCOUNTER` int(100) NOT NULL,
  `SPOTCOUNTER` int(100) NOT NULL,
  `GUESSCOUNTER` int(100) NOT NULL,
  `DONE` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=547 ;

--
-- Dumping data for table `tbinsert`
--

