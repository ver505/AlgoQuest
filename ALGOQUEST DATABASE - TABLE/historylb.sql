-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 29, 2024 at 10:05 AM
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
-- Table structure for table `historylb`
--

CREATE TABLE IF NOT EXISTS `historylb` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(11) NOT NULL,
  `H_EASYPOINTS` int(11) NOT NULL,
  `H_MEDIUMPOINTS` int(11) NOT NULL,
  `H_HARDPOINTS` int(11) NOT NULL,
  `H_OVERALLPOINTS` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `historylb`
--

