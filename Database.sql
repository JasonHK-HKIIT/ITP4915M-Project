-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: May 29, 2025 at 10:25 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `SmileAndSunshineToyCo`
--

-- --------------------------------------------------------

--
-- Table structure for table `Customer`
--

CREATE TABLE `Customer` (
  `CustomerID` varchar(50) NOT NULL,
  `CustomerName` varchar(100) NOT NULL,
  `CustomerPhoneNo` varchar(20) NOT NULL,
  `Address` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Customer`
--

INSERT INTO `Customer` (`CustomerID`, `CustomerName`, `CustomerPhoneNo`, `Address`) VALUES
('CUST001', 'Happy Kids Shop', '12345678', '123 Smile St'),
('CUST002', 'Playtime Ltd.', '23456789', '456 Sunshine Rd');

-- --------------------------------------------------------

--
-- Table structure for table `CustomerOrder`
--

CREATE TABLE `CustomerOrder` (
  `CustomerOrderID` varchar(50) NOT NULL,
  `CustomerID` varchar(50) NOT NULL,
  `QuotationID` varchar(50) DEFAULT NULL,
  `OrderDate` date NOT NULL,
  `Deadline` date NOT NULL,
  `Status` varchar(50) NOT NULL,
  `DepositPaid` decimal(12,2) NOT NULL,
  `BalanceDue` decimal(12,2) NOT NULL,
  `PaymentStatus` varchar(50) NOT NULL,
  `OrderType` varchar(50) DEFAULT NULL,
  `TotalAmount` decimal(12,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `CustomerOrder`
--

INSERT INTO `CustomerOrder` (`CustomerOrderID`, `CustomerID`, `QuotationID`, `OrderDate`, `Deadline`, `Status`, `DepositPaid`, `BalanceDue`, `PaymentStatus`, `OrderType`, `TotalAmount`) VALUES
('ORDER001', 'CUST001', 'QUOTE001', '2025-01-20', '2025-02-20', 'Confirmed', 500.00, 1499.00, 'Partial', NULL, 1999.00);

-- --------------------------------------------------------

--
-- Table structure for table `CustomerOrderInvoice`
--

CREATE TABLE `CustomerOrderInvoice` (
  `InvoiceID` varchar(50) NOT NULL,
  `CustomerOrderID` varchar(50) NOT NULL,
  `InvoiceDate` date NOT NULL,
  `TotalAmount` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `CustomerOrderInvoice`
--

INSERT INTO `CustomerOrderInvoice` (`InvoiceID`, `CustomerOrderID`, `InvoiceDate`, `TotalAmount`) VALUES
('INV001', 'ORDER001', '2025-01-25', 1999.00);

-- --------------------------------------------------------

--
-- Table structure for table `CustomerServiceCase`
--

CREATE TABLE `CustomerServiceCase` (
  `CaseID` varchar(50) NOT NULL,
  `CustomerID` varchar(50) NOT NULL,
  `CustomerOrderID` varchar(50) DEFAULT NULL,
  `CaseDate` date NOT NULL,
  `Description` text NOT NULL,
  `Status` varchar(50) NOT NULL,
  `Resolution` text DEFAULT NULL,
  `CaseType` varchar(50) NOT NULL,
  `AssignedStaffID` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `CustomerServiceCase`
--

INSERT INTO `CustomerServiceCase` (`CaseID`, `CustomerID`, `CustomerOrderID`, `CaseDate`, `Description`, `Status`, `Resolution`, `CaseType`, `AssignedStaffID`) VALUES
('CASE001', 'CUST001', 'ORDER001', '2025-02-25', 'Customer reported missing parts', 'Open', NULL, 'Complaint', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Inventory_Product`
--

CREATE TABLE `Inventory_Product` (
  `WarehouseID` varchar(50) NOT NULL,
  `ProductID` varchar(50) NOT NULL,
  `ProductQuantityInWarehouse` int(11) NOT NULL,
  `MinimumStockLevel` int(11) DEFAULT NULL,
  `ReorderPoint` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Inventory_Product`
--

INSERT INTO `Inventory_Product` (`WarehouseID`, `ProductID`, `ProductQuantityInWarehouse`, `MinimumStockLevel`, `ReorderPoint`) VALUES
('WH001', 'PROD001', 50, 20, 30);

-- --------------------------------------------------------

--
-- Table structure for table `Material`
--

CREATE TABLE `Material` (
  `MaterialID` varchar(50) NOT NULL,
  `MaterialName` varchar(100) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `QuantityPerUnit` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Material`
--

INSERT INTO `Material` (`MaterialID`, `MaterialName`, `Description`, `QuantityPerUnit`) VALUES
('MAT001', 'Plastic Wheels', 'Set of 4 wheels', 4.00),
('MAT002', 'Wooden Blocks', 'Pack of 10 blocks', 10.00);

-- --------------------------------------------------------

--
-- Table structure for table `MaterialRequirement`
--

CREATE TABLE `MaterialRequirement` (
  `RequirementID` varchar(50) NOT NULL,
  `ProductionOrderID` varchar(50) NOT NULL,
  `MaterialID` varchar(50) NOT NULL,
  `QuantityRequired` decimal(12,2) NOT NULL,
  `PriorityLevel` varchar(50) NOT NULL,
  `DeliveryDateNeeded` date NOT NULL,
  `Status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `MaterialRequirement`
--

INSERT INTO `MaterialRequirement` (`RequirementID`, `ProductionOrderID`, `MaterialID`, `QuantityRequired`, `PriorityLevel`, `DeliveryDateNeeded`, `Status`) VALUES
('REQMAT001', 'PRODORD001', 'MAT001', 400.00, 'High', '2025-01-28', 'Ordered');

-- --------------------------------------------------------

--
-- Table structure for table `Product`
--

CREATE TABLE `Product` (
  `ProductID` varchar(50) NOT NULL,
  `DesignRequestID` varchar(50) DEFAULT NULL,
  `ProductName` varchar(100) NOT NULL,
  `ProductType` varchar(100) NOT NULL,
  `ProductSpecifications` text NOT NULL,
  `UnitPrice` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Product`
--

INSERT INTO `Product` (`ProductID`, `DesignRequestID`, `ProductName`, `ProductType`, `ProductSpecifications`, `UnitPrice`) VALUES
('PROD001', 'REQ001', 'Speedy Car', 'Toy Car', 'Red, plastic, pull-back action', 19.99),
('PROD002', 'REQ002', 'Name Blocks', 'Building Blocks', 'Wooden, personalized', 29.99);

-- --------------------------------------------------------

--
-- Table structure for table `ProductDesignRequest`
--

CREATE TABLE `ProductDesignRequest` (
  `DesignRequestID` varchar(50) NOT NULL,
  `CustomerID` varchar(50) DEFAULT NULL,
  `RequestDate` date NOT NULL,
  `Specifications` text NOT NULL,
  `Status` varchar(50) NOT NULL,
  `ConsultantFee` decimal(12,2) DEFAULT NULL,
  `ApprovalDate` date DEFAULT NULL,
  `AssignedManagerID` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ProductDesignRequest`
--

INSERT INTO `ProductDesignRequest` (`DesignRequestID`, `CustomerID`, `RequestDate`, `Specifications`, `Status`, `ConsultantFee`, `ApprovalDate`, `AssignedManagerID`) VALUES
('REQ001', 'CUST001', '2025-01-10', 'Custom toy car', 'Approved', NULL, NULL, 'WORK001'),
('REQ002', 'CUST002', '2025-01-15', 'Personalized block set', 'Pending', NULL, NULL, 'WORK001');

-- --------------------------------------------------------

--
-- Table structure for table `ProductionOrder`
--

CREATE TABLE `ProductionOrder` (
  `ProductionOrderID` varchar(50) NOT NULL,
  `CustomerOrderID` varchar(50) NOT NULL,
  `ProductID` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `ScheduledDate` date NOT NULL,
  `Status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ProductionOrder`
--

INSERT INTO `ProductionOrder` (`ProductionOrderID`, `CustomerOrderID`, `ProductID`, `Quantity`, `ScheduledDate`, `Status`) VALUES
('PRODORD001', 'ORDER001', 'PROD001', 100, '2025-01-25', 'Scheduled');

-- --------------------------------------------------------

--
-- Table structure for table `ProductionStage`
--

CREATE TABLE `ProductionStage` (
  `StageID` varchar(50) NOT NULL,
  `ProductionOrderID` varchar(50) NOT NULL,
  `StageName` varchar(100) NOT NULL,
  `AssignedTeamID` varchar(50) NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `Status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ProductionStage`
--

INSERT INTO `ProductionStage` (`StageID`, `ProductionOrderID`, `StageName`, `AssignedTeamID`, `StartDate`, `EndDate`, `Status`) VALUES
('STAGE001', 'PRODORD001', 'Design', 'TEAM001', '2025-01-26', NULL, 'In Progress'),
('STAGE002', 'PRODORD001', 'Assembly', 'TEAM002', '2025-02-01', NULL, 'Pending');

-- --------------------------------------------------------

--
-- Table structure for table `Prototype`
--

CREATE TABLE `Prototype` (
  `PrototypeID` varchar(50) NOT NULL,
  `DesignRequestID` varchar(50) NOT NULL,
  `PrototypeDate` date NOT NULL,
  `Feedback` text DEFAULT NULL,
  `Status` varchar(50) NOT NULL,
  `ReviewedBy` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Prototype`
--

INSERT INTO `Prototype` (`PrototypeID`, `DesignRequestID`, `PrototypeDate`, `Feedback`, `Status`, `ReviewedBy`) VALUES
('PROTO001', 'REQ001', '2025-01-15', 'Looks good, minor changes needed', 'In Review', 'WORK002');

-- --------------------------------------------------------

--
-- Table structure for table `PurchaseOrder`
--

CREATE TABLE `PurchaseOrder` (
  `PurchaseOrderID` varchar(50) NOT NULL,
  `SupplierID` varchar(50) NOT NULL,
  `OrderDate` date NOT NULL,
  `ExpectedDeliveryDate` date NOT NULL,
  `Status` varchar(50) NOT NULL,
  `POStatus` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `PurchaseOrder`
--

INSERT INTO `PurchaseOrder` (`PurchaseOrderID`, `SupplierID`, `OrderDate`, `ExpectedDeliveryDate`, `Status`, `POStatus`) VALUES
('PO001', 'SUP001', '2025-01-22', '2025-01-28', 'Open', 'Pending');

-- --------------------------------------------------------

--
-- Table structure for table `PurchaseOrderInvoice`
--

CREATE TABLE `PurchaseOrderInvoice` (
  `InvoiceID` varchar(50) NOT NULL,
  `PurchaseOrderID` varchar(50) NOT NULL,
  `InvoiceDate` date NOT NULL,
  `TotalAmount` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `PurchaseOrderInvoice`
--

INSERT INTO `PurchaseOrderInvoice` (`InvoiceID`, `PurchaseOrderID`, `InvoiceDate`, `TotalAmount`) VALUES
('POINV001', 'PO001', '2025-01-28', 1000.00);

-- --------------------------------------------------------

--
-- Table structure for table `PurchaseOrderLine`
--

CREATE TABLE `PurchaseOrderLine` (
  `PurchaseOrderLineID` int(11) NOT NULL,
  `PurchaseOrderID` varchar(50) NOT NULL,
  `MaterialID` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `ReceivedQuantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `PurchaseOrderLine`
--

INSERT INTO `PurchaseOrderLine` (`PurchaseOrderLineID`, `PurchaseOrderID`, `MaterialID`, `Quantity`, `ReceivedQuantity`) VALUES
(1, 'PO001', 'MAT001', 400, 0);

-- --------------------------------------------------------

--
-- Table structure for table `Quotation`
--

CREATE TABLE `Quotation` (
  `QuotationID` varchar(50) NOT NULL,
  `CustomerID` varchar(50) NOT NULL,
  `QuotationDate` date NOT NULL,
  `ProductID` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `TotalAmount` decimal(12,2) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `ValidityPeriod` date NOT NULL,
  `DiscountAmount` decimal(12,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Quotation`
--

INSERT INTO `Quotation` (`QuotationID`, `CustomerID`, `QuotationDate`, `ProductID`, `Quantity`, `TotalAmount`, `Status`, `ValidityPeriod`, `DiscountAmount`) VALUES
('QUOTE001', 'CUST001', '2025-01-12', 'PROD001', 100, 1999.00, 'Sent', '2025-02-12', NULL),
('QUOTE002', 'CUST002', '2025-01-18', 'PROD002', 50, 1499.50, 'Draft', '2025-02-18', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Shipment`
--

CREATE TABLE `Shipment` (
  `ShipmentID` varchar(50) NOT NULL,
  `CustomerOrderID` varchar(50) NOT NULL,
  `ShipmentDate` date NOT NULL,
  `Carrier` varchar(100) NOT NULL,
  `TrackingNumber` varchar(100) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `IssueDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Shipment`
--

INSERT INTO `Shipment` (`ShipmentID`, `CustomerOrderID`, `ShipmentDate`, `Carrier`, `TrackingNumber`, `Status`, `IssueDate`) VALUES
('SHIP001', 'ORDER001', '2025-02-15', 'DHL', 'TRACK123', 'Shipped', '2025-02-14');

-- --------------------------------------------------------

--
-- Table structure for table `Supplier`
--

CREATE TABLE `Supplier` (
  `SupplierID` varchar(50) NOT NULL,
  `SupplierName` varchar(100) NOT NULL,
  `ContactInfo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Supplier`
--

INSERT INTO `Supplier` (`SupplierID`, `SupplierName`, `ContactInfo`) VALUES
('SUP001', 'Toy Parts Co.', 'parts@toyparts.com'),
('SUP002', 'Fast Materials Inc.', 'fast@materials.com');

-- --------------------------------------------------------

--
-- Table structure for table `SystemUser`
--

CREATE TABLE `SystemUser` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Role` varchar(50) NOT NULL,
  `IsActive` tinyint(1) DEFAULT 1,
  `CreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `SystemUser`
--

INSERT INTO `SystemUser` (`UserID`, `Username`, `PasswordHash`, `Role`, `IsActive`, `CreatedAt`) VALUES
(1, 'admin', 'hashedpassword123', 'Admin', 1, '2025-05-29 16:24:26'),
(2, 'manager1', 'hashedpassword456', 'Manager', 1, '2025-05-29 16:24:26'),
(3, 'staff1', 'hashedpassword789', 'Staff', 1, '2025-05-29 16:24:26');

-- --------------------------------------------------------

--
-- Table structure for table `Warehouse`
--

CREATE TABLE `Warehouse` (
  `WarehouseID` varchar(50) NOT NULL,
  `WarehouseCountry` varchar(100) NOT NULL,
  `WarehouseAddress` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Warehouse`
--

INSERT INTO `Warehouse` (`WarehouseID`, `WarehouseCountry`, `WarehouseAddress`) VALUES
('WH001', 'USA', '789 Warehouse Ave'),
('WH002', 'Canada', '101 Storage Blvd');

-- --------------------------------------------------------

--
-- Table structure for table `Worker`
--

CREATE TABLE `Worker` (
  `WorkerID` varchar(50) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `PositionTitle` varchar(100) NOT NULL,
  `ManagerID` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Worker`
--

INSERT INTO `Worker` (`WorkerID`, `Name`, `PositionTitle`, `ManagerID`) VALUES
('WORK001', 'Alice Smith', 'Manager', NULL),
('WORK002', 'Bob Johnson', 'Designer', NULL),
('WORK003', 'Charlie Lee', 'Assembler', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `WorkerTeam`
--

CREATE TABLE `WorkerTeam` (
  `TeamID` varchar(50) NOT NULL,
  `TeamName` varchar(100) NOT NULL,
  `LeaderID` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `WorkerTeam`
--

INSERT INTO `WorkerTeam` (`TeamID`, `TeamName`, `LeaderID`) VALUES
('TEAM001', 'Design Team', 'WORK002'),
('TEAM002', 'Assembly Team', 'WORK003');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Customer`
--
ALTER TABLE `Customer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `CustomerOrder`
--
ALTER TABLE `CustomerOrder`
  ADD PRIMARY KEY (`CustomerOrderID`),
  ADD KEY `CustomerOrder_CustomerID_fk` (`CustomerID`),
  ADD KEY `CustomerOrder_QuotationID_fk` (`QuotationID`);

--
-- Indexes for table `CustomerOrderInvoice`
--
ALTER TABLE `CustomerOrderInvoice`
  ADD PRIMARY KEY (`InvoiceID`),
  ADD KEY `CustomerOrderID` (`CustomerOrderID`);

--
-- Indexes for table `CustomerServiceCase`
--
ALTER TABLE `CustomerServiceCase`
  ADD PRIMARY KEY (`CaseID`),
  ADD KEY `CustomerID` (`CustomerID`),
  ADD KEY `CustomerOrderID` (`CustomerOrderID`),
  ADD KEY `AssignedStaffID` (`AssignedStaffID`);

--
-- Indexes for table `Inventory_Product`
--
ALTER TABLE `Inventory_Product`
  ADD PRIMARY KEY (`WarehouseID`,`ProductID`),
  ADD KEY `Inventory_Product_ProductID_fk` (`ProductID`);

--
-- Indexes for table `Material`
--
ALTER TABLE `Material`
  ADD PRIMARY KEY (`MaterialID`);

--
-- Indexes for table `MaterialRequirement`
--
ALTER TABLE `MaterialRequirement`
  ADD PRIMARY KEY (`RequirementID`),
  ADD KEY `MaterialRequirement_ProductionOrderID_fk` (`ProductionOrderID`),
  ADD KEY `MaterialRequirement_MaterialID_fk` (`MaterialID`);

--
-- Indexes for table `Product`
--
ALTER TABLE `Product`
  ADD PRIMARY KEY (`ProductID`),
  ADD KEY `Product_DesignRequestID_fk` (`DesignRequestID`);

--
-- Indexes for table `ProductDesignRequest`
--
ALTER TABLE `ProductDesignRequest`
  ADD PRIMARY KEY (`DesignRequestID`),
  ADD KEY `ProductDesignRequest_CustomerID_fk` (`CustomerID`),
  ADD KEY `ProductDesignRequest_AssignedManagerID_fk` (`AssignedManagerID`);

--
-- Indexes for table `ProductionOrder`
--
ALTER TABLE `ProductionOrder`
  ADD PRIMARY KEY (`ProductionOrderID`),
  ADD KEY `ProductionOrder_OrderID_fk` (`CustomerOrderID`),
  ADD KEY `ProductionOrder_ProductID_fk` (`ProductID`);

--
-- Indexes for table `ProductionStage`
--
ALTER TABLE `ProductionStage`
  ADD PRIMARY KEY (`StageID`),
  ADD KEY `ProductionStage_ProductionOrderID_fk` (`ProductionOrderID`),
  ADD KEY `ProductionStage_AssignedTeamID_fk` (`AssignedTeamID`);

--
-- Indexes for table `Prototype`
--
ALTER TABLE `Prototype`
  ADD PRIMARY KEY (`PrototypeID`),
  ADD KEY `DesignRequestID` (`DesignRequestID`),
  ADD KEY `ReviewedBy` (`ReviewedBy`);

--
-- Indexes for table `PurchaseOrder`
--
ALTER TABLE `PurchaseOrder`
  ADD PRIMARY KEY (`PurchaseOrderID`),
  ADD KEY `PurchaseOrder_SupplierID_fk` (`SupplierID`);

--
-- Indexes for table `PurchaseOrderInvoice`
--
ALTER TABLE `PurchaseOrderInvoice`
  ADD PRIMARY KEY (`InvoiceID`),
  ADD KEY `PurchaseOrderID` (`PurchaseOrderID`);

--
-- Indexes for table `PurchaseOrderLine`
--
ALTER TABLE `PurchaseOrderLine`
  ADD PRIMARY KEY (`PurchaseOrderLineID`),
  ADD KEY `PurchaseOrderID` (`PurchaseOrderID`),
  ADD KEY `MaterialID` (`MaterialID`);

--
-- Indexes for table `Quotation`
--
ALTER TABLE `Quotation`
  ADD PRIMARY KEY (`QuotationID`),
  ADD KEY `Quotation_CustomerID_fk` (`CustomerID`),
  ADD KEY `Quotation_ProductID_fk` (`ProductID`);

--
-- Indexes for table `Shipment`
--
ALTER TABLE `Shipment`
  ADD PRIMARY KEY (`ShipmentID`),
  ADD KEY `Shipment_OrderID_fk` (`CustomerOrderID`);

--
-- Indexes for table `Supplier`
--
ALTER TABLE `Supplier`
  ADD PRIMARY KEY (`SupplierID`);

--
-- Indexes for table `SystemUser`
--
ALTER TABLE `SystemUser`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indexes for table `Warehouse`
--
ALTER TABLE `Warehouse`
  ADD PRIMARY KEY (`WarehouseID`);

--
-- Indexes for table `Worker`
--
ALTER TABLE `Worker`
  ADD PRIMARY KEY (`WorkerID`),
  ADD KEY `Worker_ManagerID_fk` (`ManagerID`);

--
-- Indexes for table `WorkerTeam`
--
ALTER TABLE `WorkerTeam`
  ADD PRIMARY KEY (`TeamID`),
  ADD KEY `WorkerTeam_LeaderID_fk` (`LeaderID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `PurchaseOrderLine`
--
ALTER TABLE `PurchaseOrderLine`
  MODIFY `PurchaseOrderLineID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `SystemUser`
--
ALTER TABLE `SystemUser`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `CustomerOrder`
--
ALTER TABLE `CustomerOrder`
  ADD CONSTRAINT `CustomerOrder_CustomerID_fk` FOREIGN KEY (`CustomerID`) REFERENCES `Customer` (`CustomerID`),
  ADD CONSTRAINT `CustomerOrder_QuotationID_fk` FOREIGN KEY (`QuotationID`) REFERENCES `Quotation` (`QuotationID`);

--
-- Constraints for table `CustomerOrderInvoice`
--
ALTER TABLE `CustomerOrderInvoice`
  ADD CONSTRAINT `customerorderinvoice_ibfk_1` FOREIGN KEY (`CustomerOrderID`) REFERENCES `CustomerOrder` (`CustomerOrderID`);

--
-- Constraints for table `CustomerServiceCase`
--
ALTER TABLE `CustomerServiceCase`
  ADD CONSTRAINT `customerservicecase_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `Customer` (`CustomerID`),
  ADD CONSTRAINT `customerservicecase_ibfk_2` FOREIGN KEY (`CustomerOrderID`) REFERENCES `CustomerOrder` (`CustomerOrderID`),
  ADD CONSTRAINT `customerservicecase_ibfk_3` FOREIGN KEY (`AssignedStaffID`) REFERENCES `Worker` (`WorkerID`);

--
-- Constraints for table `Inventory_Product`
--
ALTER TABLE `Inventory_Product`
  ADD CONSTRAINT `Inventory_Product_ProductID_fk` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`),
  ADD CONSTRAINT `Inventory_Product_WarehouseID_fk` FOREIGN KEY (`WarehouseID`) REFERENCES `Warehouse` (`WarehouseID`);

--
-- Constraints for table `MaterialRequirement`
--
ALTER TABLE `MaterialRequirement`
  ADD CONSTRAINT `MaterialRequirement_MaterialID_fk` FOREIGN KEY (`MaterialID`) REFERENCES `Material` (`MaterialID`),
  ADD CONSTRAINT `MaterialRequirement_ProductionOrderID_fk` FOREIGN KEY (`ProductionOrderID`) REFERENCES `ProductionOrder` (`ProductionOrderID`);

--
-- Constraints for table `Product`
--
ALTER TABLE `Product`
  ADD CONSTRAINT `Product_DesignRequestID_fk` FOREIGN KEY (`DesignRequestID`) REFERENCES `ProductDesignRequest` (`DesignRequestID`);

--
-- Constraints for table `ProductDesignRequest`
--
ALTER TABLE `ProductDesignRequest`
  ADD CONSTRAINT `ProductDesignRequest_AssignedManagerID_fk` FOREIGN KEY (`AssignedManagerID`) REFERENCES `Worker` (`WorkerID`),
  ADD CONSTRAINT `ProductDesignRequest_CustomerID_fk` FOREIGN KEY (`CustomerID`) REFERENCES `Customer` (`CustomerID`);

--
-- Constraints for table `ProductionOrder`
--
ALTER TABLE `ProductionOrder`
  ADD CONSTRAINT `ProductionOrder_OrderID_fk` FOREIGN KEY (`CustomerOrderID`) REFERENCES `CustomerOrder` (`CustomerOrderID`),
  ADD CONSTRAINT `ProductionOrder_ProductID_fk` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`);

--
-- Constraints for table `ProductionStage`
--
ALTER TABLE `ProductionStage`
  ADD CONSTRAINT `ProductionStage_AssignedTeamID_fk` FOREIGN KEY (`AssignedTeamID`) REFERENCES `WorkerTeam` (`TeamID`),
  ADD CONSTRAINT `ProductionStage_ProductionOrderID_fk` FOREIGN KEY (`ProductionOrderID`) REFERENCES `ProductionOrder` (`ProductionOrderID`);

--
-- Constraints for table `Prototype`
--
ALTER TABLE `Prototype`
  ADD CONSTRAINT `prototype_ibfk_1` FOREIGN KEY (`DesignRequestID`) REFERENCES `ProductDesignRequest` (`DesignRequestID`),
  ADD CONSTRAINT `prototype_ibfk_2` FOREIGN KEY (`ReviewedBy`) REFERENCES `Worker` (`WorkerID`);

--
-- Constraints for table `PurchaseOrder`
--
ALTER TABLE `PurchaseOrder`
  ADD CONSTRAINT `PurchaseOrder_SupplierID_fk` FOREIGN KEY (`SupplierID`) REFERENCES `Supplier` (`SupplierID`);

--
-- Constraints for table `PurchaseOrderInvoice`
--
ALTER TABLE `PurchaseOrderInvoice`
  ADD CONSTRAINT `purchaseorderinvoice_ibfk_1` FOREIGN KEY (`PurchaseOrderID`) REFERENCES `PurchaseOrder` (`PurchaseOrderID`);

--
-- Constraints for table `PurchaseOrderLine`
--
ALTER TABLE `PurchaseOrderLine`
  ADD CONSTRAINT `purchaseorderline_ibfk_1` FOREIGN KEY (`PurchaseOrderID`) REFERENCES `PurchaseOrder` (`PurchaseOrderID`),
  ADD CONSTRAINT `purchaseorderline_ibfk_2` FOREIGN KEY (`MaterialID`) REFERENCES `Material` (`MaterialID`);

--
-- Constraints for table `Quotation`
--
ALTER TABLE `Quotation`
  ADD CONSTRAINT `Quotation_CustomerID_fk` FOREIGN KEY (`CustomerID`) REFERENCES `Customer` (`CustomerID`),
  ADD CONSTRAINT `Quotation_ProductID_fk` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`);

--
-- Constraints for table `Shipment`
--
ALTER TABLE `Shipment`
  ADD CONSTRAINT `Shipment_OrderID_fk` FOREIGN KEY (`CustomerOrderID`) REFERENCES `CustomerOrder` (`CustomerOrderID`);

--
-- Constraints for table `Worker`
--
ALTER TABLE `Worker`
  ADD CONSTRAINT `Worker_ManagerID_fk` FOREIGN KEY (`ManagerID`) REFERENCES `Worker` (`WorkerID`);

--
-- Constraints for table `WorkerTeam`
--
ALTER TABLE `WorkerTeam`
  ADD CONSTRAINT `WorkerTeam_LeaderID_fk` FOREIGN KEY (`LeaderID`) REFERENCES `Worker` (`WorkerID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
