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
-- Table structure for table `spotlb`
--

CREATE TABLE IF NOT EXISTS `spotlb` (
  `ID` int(100) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `S_EASYPOINTS` int(100) NOT NULL,
  `S_MEDIUMPOINTS` int(100) NOT NULL,
  `S_HARDPOINTS` int(100) NOT NULL,
  `S_OVERALLPOINTS` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `spotlb`
--

