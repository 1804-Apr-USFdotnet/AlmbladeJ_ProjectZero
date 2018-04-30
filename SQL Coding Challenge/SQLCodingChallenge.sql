CREATE DATABASE ChallengeDB;
GO

CREATE TABLE Products (
	ID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	Price DECIMAL(5,2) NOT NULL );
GO

CREATE TABLE Customers (
	ID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(24) NOT NULL,
	LastName NVARCHAR(24) NOT NULL,
	CardNumber NVARCHAR(16) NOT NULL );
GO

CREATE TABLE Orders (
	ID INT PRIMARY KEY IDENTITY(1,1),
	ProductID INT FOREIGN KEY REFERENCES Products.ID NOT NULL,
	PersonID INT FOREIGN KEY REFERENCES Persons.ID NOT NULL );
GO

INSERT INTO Products (Name, Price) VALUES ('Blackberry', 10.00);
INSERT INTO Products (Name, Price) VALUES ('Zune', 0.50);
INSERT INTO Products (Name, Price) VALUES ('Brick', 20.00);
INSERT INTO Customers (FirstName, LastName, CardNumber) VALUES ('John', 'Doe', '1234234534564567');
INSERT INTO Customers (FirstName, LastName, CardNumber) VALUES ('John', 'Doe', '1234234534564567');
INSERT INTO Customers (FirstName, LastName, CardNumber) VALUES ('John', 'Doe', '1234234534564567');
INSERT INTO Orders (ProductID, PersonID) VALUES (1, 2);
INSERT INTO Orders (ProductID, PersonID) VALUES (2, 1);
INSERT INTO Orders (ProductID, PersonID) VALUES (3, 3);
INSERT INTO Orders (ProductID, PersonID) VALUES (1, 1);
INSERT INTO Orders (ProductID, PersonID) VALUES (1, 3);
INSERT INTO Orders (ProductID, PersonID) VALUES (2, 3);
INSERT INTO Orders (ProductID, PersonID) VALUES (3, 3);

INSERT INTO Products (Name, Price) VALUES ('iPhone', 250.00);
INSERT INTO Customers (FirstName, LastName, CardNumber) VALUES ('Tina', 'Smith', '1111222233334444');

INSERT INTO Orders (ProductID, PersonID)
	VALUES ((SELECT * FROM Products WHERE Products.Name = 'iPhone'),
			(SELECT * FROM Customers WHERE 
						Customers.FirstName = 'Tina'
						AND Customers.LastName = 'Smith') );

SELECT Customers.FirstName, Customers.LastName, Orders.ProductID FROM Customers
		INNER JOIN Orders ON Customers.ID = Orders.PersonID;

DECLARE @NumberOfSale DECIMAL = (SELECT COUNT(*) FROM Orders WHERE Orders.ProductID = 4);
SELECT @NumberOfSale * (SELECT Price FROM Products WHERE Product.ID = 4);

UPDATE Products SET Price = 250.00 WHERE ID = 4;