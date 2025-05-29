-- Refined SQL Schema for Smile & Sunshine Toy Co. System

-- User Accounts (for system login)
CREATE TABLE SystemUser (
        UserID INT AUTO_INCREMENT PRIMARY KEY,
        Username VARCHAR(50) UNIQUE NOT NULL,
        PasswordHash VARCHAR(255) NOT NULL,
        Role VARCHAR(50) NOT NULL,
        IsActive BOOLEAN DEFAULT TRUE,
        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Customer
CREATE TABLE Customer (
        CustomerID VARCHAR(50) PRIMARY KEY,
        CustomerName VARCHAR(100) NOT NULL,
        CustomerPhoneNo VARCHAR(20) NOT NULL,
        Address VARCHAR(255) NOT NULL
);

-- Supplier
CREATE TABLE Supplier (
        SupplierID VARCHAR(50) PRIMARY KEY,
        SupplierName VARCHAR(100) NOT NULL,
        ContactInfo VARCHAR(255) NOT NULL
);

-- Warehouse
CREATE TABLE Warehouse (
        WarehouseID VARCHAR(50) PRIMARY KEY,
        WarehouseCountry VARCHAR(100) NOT NULL,
        WarehouseAddress VARCHAR(255) NOT NULL
);

-- Worker
CREATE TABLE Worker (
        WorkerID VARCHAR(50) PRIMARY KEY,
        Name VARCHAR(100) NOT NULL,
        PositionTitle VARCHAR(100) NOT NULL,
        ManagerID VARCHAR(50),
        CONSTRAINT Worker_ManagerID_fk FOREIGN KEY (ManagerID) REFERENCES Worker(WorkerID)
);

-- Worker Team
CREATE TABLE WorkerTeam (
        TeamID VARCHAR(50) PRIMARY KEY,
        TeamName VARCHAR(100) NOT NULL,
        LeaderID VARCHAR(50),
        CONSTRAINT WorkerTeam_LeaderID_fk FOREIGN KEY (LeaderID) REFERENCES Worker(WorkerID)
);

-- Material
CREATE TABLE Material (
        MaterialID VARCHAR(50) PRIMARY KEY,
        MaterialName VARCHAR(100) NOT NULL,
        Description VARCHAR(255),
        QuantityPerUnit DECIMAL(12,2) NOT NULL
);

-- Product Design Request
CREATE TABLE ProductDesignRequest (
        DesignRequestID VARCHAR(50) PRIMARY KEY,
        CustomerID VARCHAR(50),
        RequestDate DATE NOT NULL,
        Specifications TEXT NOT NULL,
        Status VARCHAR(50) NOT NULL,
        ConsultantFee DECIMAL(12,2),
        ApprovalDate DATE,
        AssignedManagerID VARCHAR(50) NOT NULL,
        CONSTRAINT ProductDesignRequest_CustomerID_fk FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
        CONSTRAINT ProductDesignRequest_AssignedManagerID_fk FOREIGN KEY (AssignedManagerID) REFERENCES Worker(WorkerID)
);

-- Product
CREATE TABLE Product (
        ProductID VARCHAR(50) PRIMARY KEY,
        DesignRequestID VARCHAR(50),
        ProductName VARCHAR(100) NOT NULL,
        ProductType VARCHAR(100) NOT NULL,
        ProductSpecifications TEXT NOT NULL,
        UnitPrice DECIMAL(12,2) NOT NULL,
        CONSTRAINT Product_DesignRequestID_fk FOREIGN KEY (DesignRequestID) REFERENCES ProductDesignRequest(DesignRequestID)
);

-- Quotation
CREATE TABLE Quotation (
        QuotationID VARCHAR(50) PRIMARY KEY,
        CustomerID VARCHAR(50) NOT NULL,
        QuotationDate DATE NOT NULL,
        ProductID VARCHAR(50) NOT NULL,
        Quantity INT NOT NULL,
        TotalAmount DECIMAL(12,2) NOT NULL,
        Status VARCHAR(50) NOT NULL,
        ValidityPeriod DATE NOT NULL,
        DiscountAmount DECIMAL(12,2),
        CONSTRAINT Quotation_CustomerID_fk FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
        CONSTRAINT Quotation_ProductID_fk FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Customer Order
CREATE TABLE CustomerOrder (
        CustomerOrderID VARCHAR(50) PRIMARY KEY,
        CustomerID VARCHAR(50) NOT NULL,
        QuotationID VARCHAR(50),
        OrderDate DATE NOT NULL,
        Deadline DATE NOT NULL,
        Status VARCHAR(50) NOT NULL,
        DepositPaid DECIMAL(12,2) NOT NULL,
        BalanceDue DECIMAL(12,2) NOT NULL,
        PaymentStatus VARCHAR(50) NOT NULL,
        OrderType VARCHAR(50),
        TotalAmount DECIMAL(12,2),
        CONSTRAINT CustomerOrder_CustomerID_fk FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
        CONSTRAINT CustomerOrder_QuotationID_fk FOREIGN KEY (QuotationID) REFERENCES Quotation(QuotationID)
);

-- Production Order
CREATE TABLE ProductionOrder (
        ProductionOrderID VARCHAR(50) PRIMARY KEY,
        CustomerOrderID VARCHAR(50) NOT NULL,
        ProductID VARCHAR(50) NOT NULL,
        Quantity INT NOT NULL,
        ScheduledDate DATE NOT NULL,
        Status VARCHAR(50) NOT NULL,
        CONSTRAINT ProductionOrder_OrderID_fk FOREIGN KEY (CustomerOrderID) REFERENCES CustomerOrder(CustomerOrderID),
        CONSTRAINT ProductionOrder_ProductID_fk FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Production Stage
CREATE TABLE ProductionStage (
        StageID VARCHAR(50) PRIMARY KEY,
        ProductionOrderID VARCHAR(50) NOT NULL,
        StageName VARCHAR(100) NOT NULL,
        AssignedTeamID VARCHAR(50) NOT NULL,
        StartDate DATE NOT NULL,
        EndDate DATE,
        Status VARCHAR(50) NOT NULL,
        CONSTRAINT ProductionStage_ProductionOrderID_fk FOREIGN KEY (ProductionOrderID) REFERENCES ProductionOrder(ProductionOrderID),
        CONSTRAINT ProductionStage_AssignedTeamID_fk FOREIGN KEY (AssignedTeamID) REFERENCES WorkerTeam(TeamID)
);

-- Material Requirement
CREATE TABLE MaterialRequirement (
        RequirementID VARCHAR(50) PRIMARY KEY,
        ProductionOrderID VARCHAR(50) NOT NULL,
        MaterialID VARCHAR(50) NOT NULL,
        QuantityRequired DECIMAL(12,2) NOT NULL,
        PriorityLevel VARCHAR(50) NOT NULL,
        DeliveryDateNeeded DATE NOT NULL,
        Status VARCHAR(50) NOT NULL,
        CONSTRAINT MaterialRequirement_ProductionOrderID_fk FOREIGN KEY (ProductionOrderID) REFERENCES ProductionOrder(ProductionOrderID),
        CONSTRAINT MaterialRequirement_MaterialID_fk FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
);

-- Inventory Product
CREATE TABLE Inventory_Product (
        WarehouseID VARCHAR(50) NOT NULL,
        ProductID VARCHAR(50) NOT NULL,
        ProductQuantityInWarehouse INT NOT NULL,
        MinimumStockLevel INT,
        ReorderPoint INT,
        PRIMARY KEY (WarehouseID, ProductID),
        CONSTRAINT Inventory_Product_WarehouseID_fk FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID),
        CONSTRAINT Inventory_Product_ProductID_fk FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Purchase Order
CREATE TABLE PurchaseOrder (
        PurchaseOrderID VARCHAR(50) PRIMARY KEY,
        SupplierID VARCHAR(50) NOT NULL,
        OrderDate DATE NOT NULL,
        ExpectedDeliveryDate DATE NOT NULL,
        Status VARCHAR(50) NOT NULL,
        POStatus VARCHAR(50) NOT NULL,
        CONSTRAINT PurchaseOrder_SupplierID_fk FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID)
);

-- Purchase Order Line
CREATE TABLE PurchaseOrderLine (
        PurchaseOrderLineID INT AUTO_INCREMENT PRIMARY KEY,
        PurchaseOrderID VARCHAR(50) NOT NULL,
        MaterialID VARCHAR(50) NOT NULL,
        Quantity INT NOT NULL,
        ReceivedQuantity INT,
        FOREIGN KEY (PurchaseOrderID) REFERENCES PurchaseOrder(PurchaseOrderID),
        FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
);

-- Shipment
CREATE TABLE Shipment (
        ShipmentID VARCHAR(50) PRIMARY KEY,
        CustomerOrderID VARCHAR(50) NOT NULL,
        ShipmentDate DATE NOT NULL,
        Carrier VARCHAR(100) NOT NULL,
        TrackingNumber VARCHAR(100) NOT NULL,
        Status VARCHAR(50) NOT NULL,
        IssueDate DATE NOT NULL,
        CONSTRAINT Shipment_OrderID_fk FOREIGN KEY (CustomerOrderID) REFERENCES CustomerOrder(CustomerOrderID)
);

-- Customer Order Invoice
CREATE TABLE CustomerOrderInvoice (
        InvoiceID VARCHAR(50) PRIMARY KEY,
        CustomerOrderID VARCHAR(50) NOT NULL,
        InvoiceDate DATE NOT NULL,
        TotalAmount DECIMAL(12,2) NOT NULL,
        FOREIGN KEY (CustomerOrderID) REFERENCES CustomerOrder(CustomerOrderID)
);

-- Purchase Order Invoice
CREATE TABLE PurchaseOrderInvoice (
        InvoiceID VARCHAR(50) PRIMARY KEY,
        PurchaseOrderID VARCHAR(50) NOT NULL,
        InvoiceDate DATE NOT NULL,
        TotalAmount DECIMAL(12,2) NOT NULL,
        FOREIGN KEY (PurchaseOrderID) REFERENCES PurchaseOrder(PurchaseOrderID)
);

-- Customer Service Case
CREATE TABLE CustomerServiceCase (
        CaseID VARCHAR(50) PRIMARY KEY,
        CustomerID VARCHAR(50) NOT NULL,
        CustomerOrderID VARCHAR(50),
        CaseDate DATE NOT NULL,
        Description TEXT NOT NULL,
        Status VARCHAR(50) NOT NULL,
        Resolution TEXT,
        CaseType VARCHAR(50) NOT NULL,
        AssignedStaffID VARCHAR(50),
        FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
        FOREIGN KEY (CustomerOrderID) REFERENCES CustomerOrder(CustomerOrderID),
        FOREIGN KEY (AssignedStaffID) REFERENCES Worker(WorkerID)
);

-- Prototype
CREATE TABLE Prototype (
        PrototypeID VARCHAR(50) PRIMARY KEY,
        DesignRequestID VARCHAR(50) NOT NULL,
        PrototypeDate DATE NOT NULL,
        Feedback TEXT,
        Status VARCHAR(50) NOT NULL,
        ReviewedBy VARCHAR(50),
        FOREIGN KEY (DesignRequestID) REFERENCES ProductDesignRequest(DesignRequestID),
        FOREIGN KEY (ReviewedBy) REFERENCES Worker(WorkerID)
);


-- Sample data inserts for Smile & Sunshine Toy Co. System

-- System Users
INSERT INTO SystemUser (Username, PasswordHash, Role) VALUES
('admin', 'hashedpassword123', 'Admin'),
('manager1', 'hashedpassword456', 'Manager'),
('staff1', 'hashedpassword789', 'Staff');

-- Customers
INSERT INTO Customer (CustomerID, CustomerName, CustomerPhoneNo, Address) VALUES
('CUST001', 'Happy Kids Shop', '12345678', '123 Smile St'),
('CUST002', 'Playtime Ltd.', '23456789', '456 Sunshine Rd');

-- Suppliers
INSERT INTO Supplier (SupplierID, SupplierName, ContactInfo) VALUES
('SUP001', 'Toy Parts Co.', 'parts@toyparts.com'),
('SUP002', 'Fast Materials Inc.', 'fast@materials.com');

-- Warehouses
INSERT INTO Warehouse (WarehouseID, WarehouseCountry, WarehouseAddress) VALUES
('WH001', 'USA', '789 Warehouse Ave'),
('WH002', 'Canada', '101 Storage Blvd');

-- Workers
INSERT INTO Worker (WorkerID, Name, PositionTitle) VALUES
('WORK001', 'Alice Smith', 'Manager'),
('WORK002', 'Bob Johnson', 'Designer'),
('WORK003', 'Charlie Lee', 'Assembler');

-- Worker Teams
INSERT INTO WorkerTeam (TeamID, TeamName, LeaderID) VALUES
('TEAM001', 'Design Team', 'WORK002'),
('TEAM002', 'Assembly Team', 'WORK003');

-- Materials
INSERT INTO Material (MaterialID, MaterialName, Description, QuantityPerUnit) VALUES
('MAT001', 'Plastic Wheels', 'Set of 4 wheels', 4),
('MAT002', 'Wooden Blocks', 'Pack of 10 blocks', 10);

-- Product Design Requests
INSERT INTO ProductDesignRequest (DesignRequestID, CustomerID, RequestDate, Specifications, Status, AssignedManagerID) VALUES
('REQ001', 'CUST001', '2025-01-10', 'Custom toy car', 'Approved', 'WORK001'),
('REQ002', 'CUST002', '2025-01-15', 'Personalized block set', 'Pending', 'WORK001');

-- Products
INSERT INTO Product (ProductID, DesignRequestID, ProductName, ProductType, ProductSpecifications, UnitPrice) VALUES
('PROD001', 'REQ001', 'Speedy Car', 'Toy Car', 'Red, plastic, pull-back action', 19.99),
('PROD002', 'REQ002', 'Name Blocks', 'Building Blocks', 'Wooden, personalized', 29.99);

-- Quotations
INSERT INTO Quotation (QuotationID, CustomerID, QuotationDate, ProductID, Quantity, TotalAmount, Status, ValidityPeriod) VALUES
('QUOTE001', 'CUST001', '2025-01-12', 'PROD001', 100, 1999.00, 'Sent', '2025-02-12'),
('QUOTE002', 'CUST002', '2025-01-18', 'PROD002', 50, 1499.50, 'Draft', '2025-02-18');

-- Customer Orders
INSERT INTO CustomerOrder (CustomerOrderID, CustomerID, QuotationID, OrderDate, Deadline, Status, DepositPaid, BalanceDue, PaymentStatus, TotalAmount) VALUES
('ORDER001', 'CUST001', 'QUOTE001', '2025-01-20', '2025-02-20', 'Confirmed', 500.00, 1499.00, 'Partial', 1999.00);

-- Production Orders
INSERT INTO ProductionOrder (ProductionOrderID, CustomerOrderID, ProductID, Quantity, ScheduledDate, Status) VALUES
('PRODORD001', 'ORDER001', 'PROD001', 100, '2025-01-25', 'Scheduled');

-- Production Stages
INSERT INTO ProductionStage (StageID, ProductionOrderID, StageName, AssignedTeamID, StartDate, Status) VALUES
('STAGE001', 'PRODORD001', 'Design', 'TEAM001', '2025-01-26', 'In Progress'),
('STAGE002', 'PRODORD001', 'Assembly', 'TEAM002', '2025-02-01', 'Pending');

-- Material Requirements
INSERT INTO MaterialRequirement (RequirementID, ProductionOrderID, MaterialID, QuantityRequired, PriorityLevel, DeliveryDateNeeded, Status) VALUES
('REQMAT001', 'PRODORD001', 'MAT001', 400, 'High', '2025-01-28', 'Ordered');

-- Inventory Products
INSERT INTO Inventory_Product (WarehouseID, ProductID, ProductQuantityInWarehouse, MinimumStockLevel, ReorderPoint) VALUES
('WH001', 'PROD001', 50, 20, 30);

-- Purchase Orders
INSERT INTO PurchaseOrder (PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, Status, POStatus) VALUES
('PO001', 'SUP001', '2025-01-22', '2025-01-28', 'Open', 'Pending');

-- Purchase Order Lines
INSERT INTO PurchaseOrderLine (PurchaseOrderID, MaterialID, Quantity, ReceivedQuantity) VALUES
('PO001', 'MAT001', 400, 0);

-- Shipments
INSERT INTO Shipment (ShipmentID, CustomerOrderID, ShipmentDate, Carrier, TrackingNumber, Status, IssueDate) VALUES
('SHIP001', 'ORDER001', '2025-02-15', 'DHL', 'TRACK123', 'Shipped', '2025-02-14');

-- Customer Order Invoice
INSERT INTO CustomerOrderInvoice (InvoiceID, CustomerOrderID, InvoiceDate, TotalAmount) VALUES
('INV001', 'ORDER001', '2025-01-25', 1999.00);

-- Purchase Order Invoice
INSERT INTO PurchaseOrderInvoice (InvoiceID, PurchaseOrderID, InvoiceDate, TotalAmount) VALUES
('POINV001', 'PO001', '2025-01-28', 1000.00);

-- Customer Service Case
INSERT INTO CustomerServiceCase (CaseID, CustomerID, CustomerOrderID, CaseDate, Description, Status, CaseType) VALUES
('CASE001', 'CUST001', 'ORDER001', '2025-02-25', 'Customer reported missing parts', 'Open', 'Complaint');

-- Prototype
INSERT INTO Prototype (PrototypeID, DesignRequestID, PrototypeDate, Feedback, Status, ReviewedBy) VALUES
('PROTO001', 'REQ001', '2025-01-15', 'Looks good, minor changes needed', 'In Review', 'WORK002');
