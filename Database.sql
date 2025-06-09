-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jun 06, 2025 at 05:31 AM
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
('ORD001', 'CUST001', 'QUO001', '2025-06-01', '2025-06-15', 'Confirmed', 100.00, 200.00, 'Partial', 'Online', 300.00),
('ORD002', 'CUST002', 'QUO002', '2025-06-02', '2025-06-20', 'Pending', 50.00, 150.00, 'Unpaid', 'Offline', 200.00);

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
('INV001', 'ORD001', '2025-06-01', 300.00),
('INV002', 'ORD002', '2025-06-02', 200.00);

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
('CASE001', 'CUST001', 'ORD001', '2025-06-03', 'Broken part', 'Open', NULL, 'Complaint', 'U002'),
('CASE002', 'CUST002', 'ORD002', '2025-06-04', 'Late delivery', 'Closed', 'Refunded', 'Delivery', 'U002');

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
('WH001', 'PROD001', 100, 20, 30),
('WH002', 'PROD002', 150, 25, 40);

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
('MAT001', 'Plastic', 'High-grade plastic', 1.00),
('MAT002', 'Metal', 'Durable alloy', 2.50);

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
('REQ001', 'PO001', 'MAT001', 50.00, 'High', '2025-06-10', 'Ordered'),
('REQ002', 'PO002', 'MAT002', 30.00, 'Medium', '2025-06-15', 'Pending');

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
('PROD001', NULL, 'Deluxe Doll', 'Toy', 'Plastic, Pink dress', 29.99),
('PROD002', NULL, 'Super Car', 'Toy', 'Die-cast metal, Remote control', 49.99);

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
  `UserID` varchar(50) NOT NULL,
  `ApprovedBy` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ProductDesignRequest`
--

INSERT INTO `ProductDesignRequest` (`DesignRequestID`, `CustomerID`, `RequestDate`, `Specifications`, `Status`, `ConsultantFee`, `ApprovalDate`, `UserID`, `ApprovedBy`) VALUES
('DR001', 'CUST001', '2025-05-20', 'Custom pink doll', 'Approved', 20.00, '2025-05-25', 'U001', NULL),
('DR002', 'CUST002', '2025-05-21', 'Racing car model', 'Pending', 15.00, NULL, 'U002', NULL),
('DR003', 'CUST001', '2025-06-06', 'Toy robot with lights', 'Approved', 25.00, '2025-06-07', 'U002', 'U003');

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
('PO001', 'ORD001', 'PROD001', 100, '2025-06-05', 'Scheduled'),
('PO002', 'ORD002', 'PROD002', 150, '2025-06-06', 'Pending');

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
('STAGE001', 'PO001', 'Assembly', 'T002', '2025-06-05', NULL, 'Not Started'),
('STAGE002', 'PO002', 'Testing', 'T002', '2025-06-06', NULL, 'Not Started');

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
('PROTO001', 'DR001', '2025-05-26', 'Looks good', 'Reviewed', 'U002'),
('PROTO002', 'DR002', '2025-05-27', 'Needs adjustment', 'In Progress', NULL);

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
('PUR001', 'SUP001', '2025-05-30', '2025-06-07', 'Ordered', 'In Transit'),
('PUR002', 'SUP002', '2025-05-31', '2025-06-10', 'Ordered', 'Processing');

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
('PINV001', 'PUR001', '2025-06-01', 500.00),
('PINV002', 'PUR002', '2025-06-02', 400.00);

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
(1, 'PUR001', 'MAT001', 100, 90),
(2, 'PUR002', 'MAT002', 80, 70);

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
('QUO001', 'CUST001', '2025-05-25', 'PROD001', 10, 300.00, 'Approved', '2025-06-30', 20.00),
('QUO002', 'CUST002', '2025-05-26', 'PROD002', 5, 200.00, 'Pending', '2025-06-30', 10.00);

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
('SHIP001', 'ORD001', '2025-06-05', 'FedEx', 'TRACK123', 'Shipped', '2025-06-05'),
('SHIP002', 'ORD002', '2025-06-06', 'UPS', 'TRACK456', 'Pending', '2025-06-06');

-- --------------------------------------------------------

--
-- Table structure for table `Supplier`
--

CREATE TABLE `Supplier` (
  `SupplierID` varchar(50) NOT NULL,
  `SupplierName` varchar(100) NOT NULL,
  `ContactPerson` varchar(100) DEFAULT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Country` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT 'Active',
  `CreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Supplier`
--

INSERT INTO `Supplier` (`SupplierID`, `SupplierName`, `ContactPerson`, `PhoneNumber`, `Email`, `Address`, `Country`, `Status`, `CreatedAt`) VALUES
('SUP001', 'Toy Parts Co.', 'Alice Lee', '87654321', 'parts@toyparts.com', '123 Part St', 'USA', 'Active', '2025-06-05 18:26:08'),
('SUP002', 'Fast Materials Inc.', 'Bob Chan', '76543210', 'fast@materials.com', '456 Fast Rd', 'Canada', 'Active', '2025-06-05 18:26:08');

-- --------------------------------------------------------

--
-- Table structure for table `User`
--

CREATE TABLE `User` (
  `UserID` varchar(50) NOT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `PositionTitle` varchar(100) NOT NULL,
  `Role` varchar(50) NOT NULL,
  `ManagerID` varchar(50) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT 1,
  `CreatedAt` datetime DEFAULT current_timestamp(),
  `TeamID` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `User`
--

INSERT INTO `User` (`UserID`, `Username`, `PasswordHash`, `Name`, `PositionTitle`, `Role`, `ManagerID`, `IsActive`, `CreatedAt`, `TeamID`) VALUES
('U001', 'admin', '$2a$12$8jqjTs8hn7w.DbLvS2YaEejHzXSYc3/sTBF.Cko4Xl91YHzm9RIeu', 'Admin User', 'Administrator', 'Admin', NULL, 1, '2025-06-05 18:26:08', 'T001'),
('U002', 'john_doe', '$2a$12$Oc9EMFn2/87aTRsLU6DImumri57fmGTQvvzYDn/R0vGZMF6T4MU9G', 'John Doe', 'Production Manager', 'Manager', 'U001', 1, '2025-06-05 18:26:08', 'T002'),
('U003', 'rd_manager', '<hashed_pw>', 'Rachel Wong', 'R&D Manager', 'Manager', 'U001', 1, '2025-06-06 11:30:02', 'T003');

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
('T001', 'Admin Team', 'U001'),
('T002', 'Production Team', 'U002'),
('T003', 'R&D Team', 'U003');

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
  ADD KEY `ProductDesignRequest_UserID_fk` (`UserID`);

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
-- Indexes for table `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD KEY `ManagerID` (`ManagerID`),
  ADD KEY `User_TeamID_fk` (`TeamID`);

--
-- Indexes for table `Warehouse`
--
ALTER TABLE `Warehouse`
  ADD PRIMARY KEY (`WarehouseID`);

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
  MODIFY `PurchaseOrderLineID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

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
  ADD CONSTRAINT `CustomerOrderInvoice_ibfk_1` FOREIGN KEY (`CustomerOrderID`) REFERENCES `CustomerOrder` (`CustomerOrderID`);

--
-- Constraints for table `CustomerServiceCase`
--
ALTER TABLE `CustomerServiceCase`
  ADD CONSTRAINT `CustomerServiceCase_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `Customer` (`CustomerID`),
  ADD CONSTRAINT `CustomerServiceCase_ibfk_2` FOREIGN KEY (`CustomerOrderID`) REFERENCES `CustomerOrder` (`CustomerOrderID`);

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
  ADD CONSTRAINT `ProductDesignRequest_CustomerID_fk` FOREIGN KEY (`CustomerID`) REFERENCES `Customer` (`CustomerID`),
  ADD CONSTRAINT `ProductDesignRequest_UserID_fk` FOREIGN KEY (`UserID`) REFERENCES `User` (`UserID`);

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
  ADD CONSTRAINT `Prototype_ibfk_1` FOREIGN KEY (`DesignRequestID`) REFERENCES `ProductDesignRequest` (`DesignRequestID`);

--
-- Constraints for table `PurchaseOrder`
--
ALTER TABLE `PurchaseOrder`
  ADD CONSTRAINT `PurchaseOrder_SupplierID_fk` FOREIGN KEY (`SupplierID`) REFERENCES `Supplier` (`SupplierID`);

--
-- Constraints for table `PurchaseOrderInvoice`
--
ALTER TABLE `PurchaseOrderInvoice`
  ADD CONSTRAINT `PurchaseOrderInvoice_ibfk_1` FOREIGN KEY (`PurchaseOrderID`) REFERENCES `PurchaseOrder` (`PurchaseOrderID`);

--
-- Constraints for table `PurchaseOrderLine`
--
ALTER TABLE `PurchaseOrderLine`
  ADD CONSTRAINT `PurchaseOrderLine_ibfk_1` FOREIGN KEY (`PurchaseOrderID`) REFERENCES `PurchaseOrder` (`PurchaseOrderID`),
  ADD CONSTRAINT `PurchaseOrderLine_ibfk_2` FOREIGN KEY (`MaterialID`) REFERENCES `Material` (`MaterialID`);

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
-- Constraints for table `User`
--
ALTER TABLE `User`
  ADD CONSTRAINT `User_TeamID_fk` FOREIGN KEY (`TeamID`) REFERENCES `WorkerTeam` (`TeamID`),
  ADD CONSTRAINT `User_ibfk_1` FOREIGN KEY (`ManagerID`) REFERENCES `User` (`UserID`);

--
-- Constraints for table `WorkerTeam`
--
ALTER TABLE `WorkerTeam`
  ADD CONSTRAINT `WorkerTeam_LeaderID_fk` FOREIGN KEY (`LeaderID`) REFERENCES `User` (`UserID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
