-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 10, 2016 at 11:22 AM
-- Server version: 5.6.24
-- PHP Version: 5.6.8

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
SET foreign_key_checks = 0;
--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `ID` int(11) NOT NULL,
  `BankName` varchar(255) NOT NULL,
  `AccountNumber` varchar(255) NOT NULL,
  `InitialBalance` float DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`ID`, `BankName`, `AccountNumber`, `InitialBalance`) VALUES
(1, 'HBL Branch 1', '1000001', 500000);

-- --------------------------------------------------------

--
-- Table structure for table `cash`
--

CREATE TABLE IF NOT EXISTS `cash` (
  `ID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `MachineID` int(11) DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Liter` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` float NOT NULL,
  `VehicleNumber` varchar(255) DEFAULT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=156 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cash`
--

INSERT INTO `cash` (`ID`, `CashierID`, `MachineID`, `Name`, `Type`, `Liter`, `Rate`, `Amount`, `VehicleNumber`, `DateTime`) VALUES
(1, 1, NULL, 'asd', 'Deisel', 25, 77.68, 1942, '', '2016-03-18 22:29:28'),
(2, 1, NULL, 'zxy', 'Petrol', 20, 62.99, 1259.8, '', '2016-03-18 22:29:37'),
(3, 1, NULL, 'fgh', 'Deisel', 50, 77.68, 3884, '', '2016-03-18 22:29:46'),
(4, 1, NULL, 'qwer', 'Petrol', 35, 62.99, 2204.65, '', '2016-03-19 22:34:24'),
(5, 1, NULL, 'tyu', 'Petrol', 41, 62.99, 2582.59, '', '2016-03-19 22:34:41'),
(7, 1, NULL, 'sdf', 'Deisel', 25, 77.68, 1942, NULL, '2016-03-18 22:31:28'),
(155, 1, NULL, '1', 'Deisel', 42, 77, 3234, '', '2016-04-14 01:32:58');

-- --------------------------------------------------------

--
-- Table structure for table `cashiers`
--

CREATE TABLE IF NOT EXISTS `cashiers` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Type` varchar(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

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
  `ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Number` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `companies`
--

INSERT INTO `companies` (`ID`, `Name`, `Number`, `Email`) VALUES
(1, 'Company 1', '123456789', 'company1@company.com'),
(2, 'Company 2', '1234567890', 'company2@company.com'),
(3, 'Company 3', '123456789', 'company3@company.com'),
(4, 'company 69', '00412312', 'asdlaksjdlkj@asldkasjd.com');

-- --------------------------------------------------------

--
-- Table structure for table `credit`
--

CREATE TABLE IF NOT EXISTS `credit` (
  `ID` int(11) NOT NULL,
  `CompanyID` int(11) NOT NULL,
  `VehicleID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `MachineID` int(11) DEFAULT NULL,
  `Type` varchar(255) NOT NULL,
  `Liter` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=153 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `credit`
--

INSERT INTO `credit` (`ID`, `CompanyID`, `VehicleID`, `CashierID`, `MachineID`, `Type`, `Liter`, `Rate`, `Amount`, `DateTime`) VALUES
(1, 1, 1, 1, NULL, 'Deisel', 100, 77.68, 7768, '2016-03-18 22:21:59'),
(2, 2, 5, 1, NULL, 'Petrol', 120, 62.99, 7558.8, '2016-03-18 22:22:09'),
(3, 2, 4, 1, NULL, 'Deisel', 300, 77.68, 23304, '2016-03-18 22:22:26'),
(4, 3, 9, 1, NULL, 'Deisel', 300, 77.68, 23304, '2016-03-18 22:22:38'),
(5, 1, 3, 1, NULL, 'Petrol', 121, 62.99, 7621.79, '2016-03-18 22:22:53'),
(6, 1, 2, 1, NULL, 'Deisel', 200, 77.68, 15536, '2016-03-19 22:33:02'),
(7, 1, 3, 1, NULL, 'Deisel', 300, 77.68, 23304, '2016-03-19 22:33:09'),
(8, 3, 9, 1, NULL, 'Deisel', 150, 77.68, 11652, '2016-03-19 22:33:17'),
(9, 3, 7, 1, NULL, 'Petrol', 123, 62.99, 7747.77, '2016-03-19 22:33:25'),
(10, 1, 1, 1, NULL, 'Deisel', 1, 77.68, 77.68, '2016-03-25 19:36:16'),
(151, 1, 10, 1, NULL, 'Deisel', 1, 77, 77, '2016-04-14 01:29:51'),
(152, 1, 10, 1, NULL, 'Deisel', 1, 77, 77, '2016-04-14 01:32:30');

-- --------------------------------------------------------

--
-- Table structure for table `creditreceived`
--

CREATE TABLE IF NOT EXISTS `creditreceived` (
  `ID` int(11) NOT NULL,
  `CreditID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `ChequeNumber` varchar(50) DEFAULT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `creditreceived`
--

INSERT INTO `creditreceived` (`ID`, `CreditID`, `CashierID`, `Type`, `Amount`, `AccountID`, `ChequeNumber`, `DateTime`) VALUES
(1, 1, 1, 'Cash', 7768, NULL, NULL, '2016-04-14 01:04:12'),
(2, 5, 1, 'Cash', 7621.79, NULL, NULL, '2016-04-14 01:04:12'),
(3, 6, 1, 'Cash', 15536, NULL, NULL, '2016-04-14 01:04:12'),
(4, 7, 1, 'Cash', 19074.2, NULL, NULL, '2016-04-14 01:04:12');

-- --------------------------------------------------------

--
-- Table structure for table `deposit`
--

CREATE TABLE IF NOT EXISTS `deposit` (
  `ID` int(11) NOT NULL,
  `Amount` float NOT NULL,
  `AccountID` int(11) NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `expense`
--

CREATE TABLE IF NOT EXISTS `expense` (
  `ID` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `Description` varchar(255) NOT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE IF NOT EXISTS `inventory` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`ID`, `Name`, `Quantity`, `Rate`) VALUES
(2, 'Deisel', 2900, 77),
(4, 'Inventory 1', 10000, 123),
(3, 'OIL', 600, 140),
(1, 'Petrol', 3245, 62.99);

-- --------------------------------------------------------

--
-- Table structure for table `inventoryhistory`
--

CREATE TABLE IF NOT EXISTS `inventoryhistory` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventoryhistory`
--

INSERT INTO `inventoryhistory` (`ID`, `Name`, `Quantity`, `Rate`, `DateTime`) VALUES
(1, 'Petrol', 2000, 62.99, '2016-03-18 22:13:39'),
(2, 'Deisel', 2000, 77.68, '2016-03-18 22:14:05'),
(3, 'Deisel', 3000, 77.68, '2016-03-19 22:32:34'),
(4, 'Petrol', 2000, 62.99, '2016-03-19 22:32:46'),
(5, 'OIL', 200, 140, '2016-04-03 19:07:08'),
(6, 'OIL', 400, 140, '2016-04-03 19:07:18'),
(7, 'Inventory 1', 10000, 123, '2016-04-10 17:06:56'),
(8, 'Deisel', 141, 77.68, '2016-04-10 17:07:16'),
(9, 'Deisel', 4, 77.68, '2016-04-10 17:07:25'),
(10, 'Deisel', 4, 77, '2016-04-10 17:07:46');

-- --------------------------------------------------------

--
-- Table structure for table `linecredit`
--

CREATE TABLE IF NOT EXISTS `linecredit` (
  `ID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `MachineID` int(11) DEFAULT NULL,
  `Type` varchar(255) NOT NULL,
  `Liter` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=157 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `linecredit`
--

INSERT INTO `linecredit` (`ID`, `CustomerID`, `CashierID`, `MachineID`, `Type`, `Liter`, `Rate`, `Amount`, `DateTime`) VALUES
(1, 1, 1, NULL, 'Petrol', 150, 62.99, 9448.5, '2016-03-18 22:23:11'),
(2, 2, 1, NULL, 'Deisel', 200, 77.68, 15536, '2016-03-18 22:23:19'),
(3, 3, 1, NULL, 'Deisel', 122, 77.68, 9476.96, '2016-03-18 22:23:26'),
(4, 3, 1, NULL, 'Deisel', 321, 77.68, 24935.3, '2016-03-18 22:23:40'),
(5, 2, 1, NULL, 'Petrol', 145, 62.99, 9133.55, '2016-03-18 22:23:51'),
(6, 3, 1, NULL, 'Deisel', 123, 77.68, 9554.64, '2016-03-19 22:33:35'),
(153, 2, 1, NULL, 'Deisel', 1, 77, 77, '2016-04-14 01:32:37'),
(156, 2, 1, NULL, 'Deisel', 12, 77, 924, '2016-06-05 21:54:21');

-- --------------------------------------------------------

--
-- Table structure for table `linecreditreceived`
--

CREATE TABLE IF NOT EXISTS `linecreditreceived` (
  `ID` int(11) NOT NULL,
  `LineCreditID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `linecreditreceived`
--

INSERT INTO `linecreditreceived` (`ID`, `LineCreditID`, `CashierID`, `Amount`, `DateTime`) VALUES
(1, 5, 1, 6000, '2016-03-18 22:28:14'),
(2, 2, 1, 15536, '2016-03-18 22:28:23'),
(3, 1, 1, 5000, '2016-03-18 22:28:34'),
(4, 4, 1, 20000, '2016-03-18 22:28:49'),
(5, 3, 1, 9476.96, '2016-03-18 22:28:55'),
(6, 5, 1, 2000, '2016-03-19 22:35:29'),
(7, 6, 1, 9554.64, '2016-03-19 22:35:38'),
(8, 4, 1, 4500, '2016-03-19 22:35:51'),
(9, 4, 1, 435.28, '2016-03-19 22:35:55'),
(10, 5, 1, 1133.55, '2016-03-19 22:36:03');

-- --------------------------------------------------------

--
-- Table structure for table `linecustomers`
--

CREATE TABLE IF NOT EXISTS `linecustomers` (
  `ID` int(11) NOT NULL,
  `VehicleNumber` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `linecustomers`
--

INSERT INTO `linecustomers` (`ID`, `VehicleNumber`, `Name`) VALUES
(1, 'veh-010', 'Customer1'),
(2, 'veh-011', 'Customer 2'),
(3, 'veh-012', 'Customer 3');

-- --------------------------------------------------------

--
-- Table structure for table `machines`
--

CREATE TABLE IF NOT EXISTS `machines` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Units` float NOT NULL,
  `InventoryID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE IF NOT EXISTS `settings` (
  `Type` varchar(255) NOT NULL,
  `Value` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`Type`, `Value`) VALUES
('Printer', 'Foxit Reader PDF Printer'),
('Slip Number', '157');

-- --------------------------------------------------------

--
-- Table structure for table `vehiclecash`
--

CREATE TABLE IF NOT EXISTS `vehiclecash` (
  `ID` int(11) NOT NULL,
  `CompanyID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `ReceiverName` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=155 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vehiclecash`
--

INSERT INTO `vehiclecash` (`ID`, `CompanyID`, `CashierID`, `ReceiverName`, `Amount`, `DateTime`) VALUES
(1, 2, 1, 'xyz', 20000, '2016-03-18 22:24:04'),
(2, 1, 1, 'asd', 3400, '2016-03-18 22:24:16'),
(3, 1, 1, 'fgh', 12000, '2016-03-18 22:24:25'),
(4, 3, 1, 'qwe', 24000, '2016-03-18 22:24:33'),
(5, 3, 1, 'hjk', 25000, '2016-03-19 22:33:54'),
(6, 2, 1, 'zxcv', 30000, '2016-03-19 22:34:07'),
(154, 1, 1, '1', 3, '2016-04-14 01:32:49');

-- --------------------------------------------------------

--
-- Table structure for table `vehiclecashreceived`
--

CREATE TABLE IF NOT EXISTS `vehiclecashreceived` (
  `ID` int(11) NOT NULL,
  `VehicleCashID` int(11) NOT NULL,
  `CashierID` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Amount` float NOT NULL,
  `AccountID` int(11) NOT NULL,
  `ChequeNumber` varchar(255) DEFAULT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vehiclecashreceived`
--

INSERT INTO `vehiclecashreceived` (`ID`, `VehicleCashID`, `CashierID`, `Type`, `Amount`, `AccountID`, `ChequeNumber`, `DateTime`) VALUES
(1, 1, 1, 'Cheque', 19137.2, 0, '21321312312', '2016-04-03 18:57:53'),
(4, 2, 1, 'Cheque', 3400, 1, NULL, '2016-04-14 00:37:54'),
(5, 3, 1, 'Cheque', 12000, 1, NULL, '2016-04-14 00:37:54');

-- --------------------------------------------------------

--
-- Table structure for table `vehicles`
--

CREATE TABLE IF NOT EXISTS `vehicles` (
  `ID` int(11) NOT NULL,
  `CompanyID` int(11) NOT NULL,
  `Number` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vehicles`
--

INSERT INTO `vehicles` (`ID`, `CompanyID`, `Number`, `Name`) VALUES
(10, 1, 'ju-c10111', 'driver 1111'),
(2, 1, 'veh-002', 'driver 2'),
(3, 1, 'veh-003', 'driver 3'),
(4, 2, 'veh-004', 'driver 4'),
(5, 2, 'veh-005', 'driver 5'),
(6, 2, 'veh-006', 'driver 6'),
(7, 3, 'veh-007', 'driver 7'),
(8, 3, 'veh-008', 'driver 8'),
(9, 3, 'veh-009', 'driver 9'),
(1, 1, 'vehicle-001', 'driver 1');

-- --------------------------------------------------------

--
-- Table structure for table `withdraw`
--

CREATE TABLE IF NOT EXISTS `withdraw` (
  `ID` int(11) NOT NULL,
  `Amount` float NOT NULL,
  `AccountID` int(11) NOT NULL,
  `DateTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`ID`), ADD UNIQUE KEY `BankName` (`BankName`,`AccountNumber`);

--
-- Indexes for table `cash`
--
ALTER TABLE `cash`
  ADD PRIMARY KEY (`ID`), ADD KEY `CashierID` (`CashierID`), ADD KEY `MachineID` (`MachineID`);

--
-- Indexes for table `cashiers`
--
ALTER TABLE `cashiers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `companies`
--
ALTER TABLE `companies`
  ADD PRIMARY KEY (`Name`), ADD KEY `ID` (`ID`);

--
-- Indexes for table `credit`
--
ALTER TABLE `credit`
  ADD PRIMARY KEY (`ID`), ADD KEY `CompanyID` (`CompanyID`), ADD KEY `VehicleID` (`VehicleID`), ADD KEY `CashierID` (`CashierID`), ADD KEY `MachineID` (`MachineID`);

--
-- Indexes for table `creditreceived`
--
ALTER TABLE `creditreceived`
  ADD PRIMARY KEY (`ID`), ADD KEY `AccountID` (`AccountID`), ADD KEY `CreditID` (`CreditID`), ADD KEY `CashierID` (`CashierID`);

--
-- Indexes for table `deposit`
--
ALTER TABLE `deposit`
  ADD PRIMARY KEY (`ID`), ADD KEY `AccountID` (`AccountID`);

--
-- Indexes for table `expense`
--
ALTER TABLE `expense`
  ADD PRIMARY KEY (`ID`), ADD KEY `AccountID` (`AccountID`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`Name`), ADD KEY `ID` (`ID`);

--
-- Indexes for table `inventoryhistory`
--
ALTER TABLE `inventoryhistory`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `linecredit`
--
ALTER TABLE `linecredit`
  ADD PRIMARY KEY (`ID`), ADD KEY `CustomerID` (`CustomerID`), ADD KEY `CashierID` (`CashierID`), ADD KEY `MachineID` (`MachineID`);

--
-- Indexes for table `linecreditreceived`
--
ALTER TABLE `linecreditreceived`
  ADD PRIMARY KEY (`ID`), ADD KEY `LineCreditID` (`LineCreditID`), ADD KEY `CashierID` (`CashierID`);

--
-- Indexes for table `linecustomers`
--
ALTER TABLE `linecustomers`
  ADD PRIMARY KEY (`VehicleNumber`), ADD KEY `ID` (`ID`);

--
-- Indexes for table `machines`
--
ALTER TABLE `machines`
  ADD PRIMARY KEY (`ID`), ADD KEY `InventoryID` (`InventoryID`);

--
-- Indexes for table `settings`
--
ALTER TABLE `settings`
  ADD PRIMARY KEY (`Type`);

--
-- Indexes for table `vehiclecash`
--
ALTER TABLE `vehiclecash`
  ADD PRIMARY KEY (`ID`), ADD KEY `CompanyID` (`CompanyID`), ADD KEY `CashierID` (`CashierID`);

--
-- Indexes for table `vehiclecashreceived`
--
ALTER TABLE `vehiclecashreceived`
  ADD KEY `CreditID` (`VehicleCashID`), ADD KEY `CashierID` (`CashierID`), ADD KEY `ID` (`ID`), ADD KEY `AccountID` (`AccountID`);

--
-- Indexes for table `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`Number`), ADD KEY `CompanyID` (`CompanyID`), ADD KEY `ID` (`ID`);

--
-- Indexes for table `withdraw`
--
ALTER TABLE `withdraw`
  ADD PRIMARY KEY (`ID`), ADD KEY `AccountID` (`AccountID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `cash`
--
ALTER TABLE `cash`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=156;
--
-- AUTO_INCREMENT for table `cashiers`
--
ALTER TABLE `cashiers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `companies`
--
ALTER TABLE `companies`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `credit`
--
ALTER TABLE `credit`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=153;
--
-- AUTO_INCREMENT for table `creditreceived`
--
ALTER TABLE `creditreceived`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `deposit`
--
ALTER TABLE `deposit`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `expense`
--
ALTER TABLE `expense`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `inventoryhistory`
--
ALTER TABLE `inventoryhistory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `linecredit`
--
ALTER TABLE `linecredit`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=157;
--
-- AUTO_INCREMENT for table `linecreditreceived`
--
ALTER TABLE `linecreditreceived`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `linecustomers`
--
ALTER TABLE `linecustomers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `machines`
--
ALTER TABLE `machines`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `vehiclecash`
--
ALTER TABLE `vehiclecash`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=155;
--
-- AUTO_INCREMENT for table `vehiclecashreceived`
--
ALTER TABLE `vehiclecashreceived`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `vehicles`
--
ALTER TABLE `vehicles`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `withdraw`
--
ALTER TABLE `withdraw`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
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
SET foreign_key_checks = 1;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
