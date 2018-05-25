CREATE TABLE Menus (
                MenuID INT IDENTITY NOT NULL,
                Name VARCHAR(150) NOT NULL,
                DayOfWeek INT NOT NULL,
                Status INT NOT NULL,
                CONSTRAINT MenusID PRIMARY KEY (MenuID)
)

CREATE TABLE Suppliers (
                SupplierID INT IDENTITY NOT NULL,
                Name VARCHAR(150) NOT NULL,
                Address VARCHAR(255),
                RegisterDate DATETIME NOT NULL,
                Phone VARCHAR(14) NOT NULL,
                Status INT DEFAULT 0 NOT NULL,
                CONSTRAINT SupplierID PRIMARY KEY (SupplierID)
)

CREATE TABLE Products (
                ProductID INT IDENTITY NOT NULL,
                Name VARCHAR(150) NOT NULL,
                Price DECIMAL(19,2) DEFAULT 0 NOT NULL,
                RegisterDate DATETIME NOT NULL,
                Status INT DEFAULT 0 NOT NULL,
                SupplierID INT NOT NULL,
                MenuID INT NOT NULL,
                CONSTRAINT ProductsID PRIMARY KEY (ProductID)
)

CREATE TABLE Employees (
                EmployeeID INT IDENTITY NOT NULL,
                Name VARCHAR(150) NOT NULL,
                Address VARCHAR(255) NOT NULL,
                Phone VARCHAR(14) NOT NULL,
                RegisterDate DATETIME NOT NULL,
                Status INT DEFAULT 0 NOT NULL,
                CONSTRAINT EmployeesID PRIMARY KEY (EmployeeID)
)

CREATE TABLE Users (
                UserID INT IDENTITY NOT NULL,
                Login VARCHAR(30) NOT NULL,
                Password VARCHAR(30) NOT NULL,
                UserType INT NOT NULL,
                EmployeeID INT NOT NULL,
                RegisterDate DATETIME NOT NULL,
                CONSTRAINT UserID PRIMARY KEY (UserID)
)

CREATE TABLE Orders (
                OrderID INT IDENTITY NOT NULL,
                OrderDate DATETIME NOT NULL,
                EmployeeID INT NOT NULL,
                Status INT DEFAULT 0 NOT NULL,
                CONSTRAINT OrderID PRIMARY KEY (OrderID)
)

CREATE TABLE OrderItems (
                OrderItemsID INT IDENTITY NOT NULL,
                OrderID INT NOT NULL,
                ProductID INT NOT NULL,
                Quantity INT NOT NULL,
                CONSTRAINT OrderItemsID PRIMARY KEY (OrderItemsID)
)

ALTER TABLE Products ADD CONSTRAINT Menus_Products_fk
FOREIGN KEY (MenuID)
REFERENCES Menus (MenuID)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Products ADD CONSTRAINT Suppliers_Products_fk
FOREIGN KEY (SupplierID)
REFERENCES Suppliers (SupplierID)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE OrderItems ADD CONSTRAINT Products_OrderItems_fk
FOREIGN KEY (ProductID)
REFERENCES Products (ProductID)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Orders ADD CONSTRAINT Employees_Orders_fk
FOREIGN KEY (EmployeeID)
REFERENCES Employees (EmployeeID)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Users ADD CONSTRAINT Employees_Users_fk
FOREIGN KEY (EmployeeID)
REFERENCES Employees (EmployeeID)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE OrderItems ADD CONSTRAINT Orders_OrderItems_fk
FOREIGN KEY (OrderID)
REFERENCES Orders (OrderID)
ON DELETE NO ACTION
ON UPDATE NO ACTION

CREATE VIEW Financial
AS
SELECT
	o.OrderID AS "Order Number",
	o.OrderDate AS "Order Date",
	e.EmployeeID,
	e.Name AS "Employee",
	oi.ProductID,
	pd.name AS "Product",
	oi.Quantity,
	pd.Price AS "Unit Price",
	(oi.Quantity * pd.Price) AS "Total Product"

FROM Orders o 
INNER JOIN OrderItems oi ON oi.OrderID = o.OrderID
INNER JOIN Products pd ON pd.ProductID = oi.ProductID
inner join Employees e ON e.EmployeeID = o.EmployeeID
left join Users u ON u.EmployeeID = e.EmployeeID

CREATE VIEW MenusGroup
AS
SELECT
	p.ProductID, 
	p.Name AS ProductName, 
	p.Price AS ProductPrice, 
	m.MenuID, 
	m.Name AS MenuName, 
	m.DayOfWeek
FROM Products AS p
INNER JOIN Menus AS m ON m.MenuID = p.MenuID