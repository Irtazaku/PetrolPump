-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 31, 2016 at 10:59 AM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `petrolpump`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `BankName` varchar(255) NOT NULL,
  `AccountNumber` varchar(255) NOT NULL,
  `InitialBalance` float DEFAULT NULL,
  `Date_Created` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `BankName` (`BankName`,`AccountNumber`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

-- --------------------------------------------------------

--
-- Table structure for table `cash`
--

CREATE TABLE IF NOT EXISTS `cash` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CashierID` int(11) NOT NULL,
  `MachineID` int(11) DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Liter` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` float NOT NULL,
  `VehicleNumber` varchar(255) DEFAULT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `CashierID` (`CashierID`),
  KEY `MachineID` (`MachineID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

-- --------------------------------------------------------

--
-- Table structure for table `cashiers`
--

CREATE TABLE IF NOT EXISTS `cashiers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Type` varchar(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `cashiers`
--

INSERT INTO `cashiers` (`ID`, `Name`, `Password`, `Type`) VALUES
(1, 'Talha', 'test', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `companies`
--

CREATE TABLE IF NOT EXISTS `companies` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Number` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  PRIMARY KEY (`Name`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;


-- --------------------------------------------------------

--
-- Table structure for table `credit`
--

CREATE TABLE IF NOT EXISTS `credit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyID` int(11) NOT NULL,
  `VehicleID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `MachineID` int(11) DEFAULT NULL,
  `Type` varchar(255) NOT NULL,
  `Liter` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `CompanyID` (`CompanyID`),
  KEY `VehicleID` (`VehicleID`),
  KEY `CashierID` (`CashierID`),
  KEY `MachineID` (`MachineID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;


-- --------------------------------------------------------

--
-- Table structure for table `creditreceived`
--

CREATE TABLE IF NOT EXISTS `creditreceived` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreditID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `ChequeNumber` varchar(50) DEFAULT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `AccountID` (`AccountID`),
  KEY `CreditID` (`CreditID`),
  KEY `CashierID` (`CashierID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;


-- --------------------------------------------------------

--
-- Table structure for table `deposit`
--

CREATE TABLE IF NOT EXISTS `deposit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Amount` float NOT NULL,
  `AccountID` int(11) NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `AccountID` (`AccountID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `expense`
--

CREATE TABLE IF NOT EXISTS `expense` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `Description` varchar(255) NOT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `AccountID` (`AccountID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;


-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE IF NOT EXISTS `inventory` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Quantity` float unsigned NOT NULL,
  `Rate` float NOT NULL,
  PRIMARY KEY (`Name`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;


-- --------------------------------------------------------

--
-- Table structure for table `inventoryhistory`
--

CREATE TABLE IF NOT EXISTS `inventoryhistory` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

-- --------------------------------------------------------

--
-- Table structure for table `linecredit`
--

CREATE TABLE IF NOT EXISTS `linecredit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `MachineID` int(11) DEFAULT NULL,
  `Type` varchar(255) NOT NULL,
  `Liter` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `CustomerID` (`CustomerID`),
  KEY `CashierID` (`CashierID`),
  KEY `MachineID` (`MachineID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

-- --------------------------------------------------------

--
-- Table structure for table `linecreditreceived`
--

CREATE TABLE IF NOT EXISTS `linecreditreceived` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `LineCreditID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `LineCreditID` (`LineCreditID`),
  KEY `CashierID` (`CashierID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `linecustomers`
--

CREATE TABLE IF NOT EXISTS `linecustomers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `VehicleNumber` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`VehicleNumber`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

-- --------------------------------------------------------

--
-- Table structure for table `machines`
--

CREATE TABLE IF NOT EXISTS `machines` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Units` float NOT NULL,
  `InventoryID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `InventoryID` (`InventoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE IF NOT EXISTS `settings` (
  `Type` varchar(255) NOT NULL,
  `Value` varchar(255) NOT NULL,
  PRIMARY KEY (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`Type`, `Value`) VALUES
('Printer', 'Send To OneNote 2013'),
('Slip Number', '11');

-- --------------------------------------------------------

--
-- Table structure for table `vehiclecash`
--

CREATE TABLE IF NOT EXISTS `vehiclecash` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `ReceiverName` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `CompanyID` (`CompanyID`),
  KEY `CashierID` (`CashierID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

-- --------------------------------------------------------

--
-- Table structure for table `vehiclecashreceived`
--

CREATE TABLE IF NOT EXISTS `vehiclecashreceived` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `VehicleCashID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `ChequeNumber` varchar(255) DEFAULT NULL,
  `DateTime` datetime NOT NULL,
  KEY `CreditID` (`VehicleCashID`),
  KEY `CashierID` (`CashierID`),
  KEY `ID` (`ID`),
  KEY `AccountID` (`AccountID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

-- --------------------------------------------------------

--
-- Table structure for table `vehicles`
--

CREATE TABLE IF NOT EXISTS `vehicles` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyID` int(11) NOT NULL,
  `Number` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`Number`),
  KEY `CompanyID` (`CompanyID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=39 ;

-- --------------------------------------------------------

--
-- Table structure for table `withdraw`
--

CREATE TABLE IF NOT EXISTS `withdraw` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Amount` float NOT NULL,
  `AccountID` int(11) NOT NULL,
  `DateTime` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `AccountID` (`AccountID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cash`
--
ALTER TABLE `cash`
  ADD CONSTRAINT `cash_ibfk_1` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `cash_ibfk_2` FOREIGN KEY (`MachineID`) REFERENCES `machines` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `credit`
--
ALTER TABLE `credit`
  ADD CONSTRAINT `credit_ibfk_1` FOREIGN KEY (`CompanyID`) REFERENCES `companies` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `credit_ibfk_2` FOREIGN KEY (`VehicleID`) REFERENCES `vehicles` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `credit_ibfk_3` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `credit_ibfk_4` FOREIGN KEY (`MachineID`) REFERENCES `machines` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `creditreceived`
--
ALTER TABLE `creditreceived`
  ADD CONSTRAINT `creditreceived_ibfk_2` FOREIGN KEY (`CreditID`) REFERENCES `credit` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `creditreceived_ibfk_3` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `creditreceived_ibfk_4` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `deposit`
--
ALTER TABLE `deposit`
  ADD CONSTRAINT `deposit_ibfk_1` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `expense`
--
ALTER TABLE `expense`
  ADD CONSTRAINT `expense_ibfk_1` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `linecredit`
--
ALTER TABLE `linecredit`
  ADD CONSTRAINT `linecredit_ibfk_2` FOREIGN KEY (`CustomerID`) REFERENCES `linecustomers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `linecredit_ibfk_3` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `linecredit_ibfk_4` FOREIGN KEY (`MachineID`) REFERENCES `machines` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `linecreditreceived`
--
ALTER TABLE `linecreditreceived`
  ADD CONSTRAINT `linecreditreceived_ibfk_1` FOREIGN KEY (`LineCreditID`) REFERENCES `linecredit` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `linecreditreceived_ibfk_2` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `machines`
--
ALTER TABLE `machines`
  ADD CONSTRAINT `machines_ibfk_1` FOREIGN KEY (`InventoryID`) REFERENCES `inventory` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `vehiclecash`
--
ALTER TABLE `vehiclecash`
  ADD CONSTRAINT `vehiclecash_ibfk_1` FOREIGN KEY (`CompanyID`) REFERENCES `companies` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `vehiclecash_ibfk_3` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `vehiclecashreceived`
--
ALTER TABLE `vehiclecashreceived`
  ADD CONSTRAINT `vehiclecashreceived_ibfk_2` FOREIGN KEY (`CashierID`) REFERENCES `cashiers` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `vehiclecashreceived_ibfk_3` FOREIGN KEY (`VehicleCashID`) REFERENCES `vehiclecash` (`ID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `vehiclecashreceived_ibfk_5` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `vehicles`
--
ALTER TABLE `vehicles`
  ADD CONSTRAINT `vehicles_ibfk_1` FOREIGN KEY (`CompanyID`) REFERENCES `companies` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `withdraw`
--
ALTER TABLE `withdraw`
  ADD CONSTRAINT `withdraw_ibfk_1` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
