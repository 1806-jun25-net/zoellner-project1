CREATE DATABASE Project1PizzaApplication;
GO

CREATE SCHEMA PizzaApp;
GO

----------Table Creation----------
--Users
CREATE TABLE PizzaApp.Users
(
	Username NVARCHAR(100) PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(12) NOT NULL,
	EmailAddress NVARCHAR(100) NOT NULL,
	DefaultLocation NVARCHAR(50) NOT NULL,
	PhysicalAddress NVARCHAR(100) NOT NULL
)

--Location
CREATE TABLE PizzaApp.StoreLocation
(
	CityName NVARCHAR(50) PRIMARY KEY,
	DoughRemaining int NOT NULL,
	SauceRemaining int NOT NULL,
	CheeseRemaining int NOT NULL,
	PepperoniRemaining int NOT NULL,
	VeggiesRemaining int NOT NULL,
	MeatRemaining int NOT NULL
)

--Orders
CREATE TABLE PizzaApp.Orders
(
	OrderId int PRIMARY KEY IDENTITY,
	OrderTime DATETIME2 DEFAULT GETDATE(),
	Username NVARCHAR(100) NOT NULL,
	NumPizzas int NOT NULL,
	StoreLocation NVARCHAR(50) NOT NULL,
	PizzaNum1 int NOT NULL,
	PizzaNum2 int NULL,
	PizzaNum3 int NULL,
	PizzaNum4 int NULL,
	PizzaNum5 int NULL,
	PizzaNum6 int NULL,
	PizzaNum7 int NULL,
	PizzaNum8 int NULL,
	PizzaNum9 int NULL,
	PizzaNum10 int NULL,
	PizzaNum11 int NULL,
	PizzaNum12 int NULL,
)
GO

--Pizza Variation
CREATE TABLE PizzaApp.PizzaVariation
(
	PizzaID int PRIMARY KEY IDENTITY,
	PizzaSize NVARCHAR(6) NOT NULL,
	PizzaType NVARCHAR(9) NOT NULL
)


----------Initially forgot to add cost column to the Orders table and FirstName column as well-----------
ALTER TABLE PizzaApp.Orders
ADD TotalCost SMALLMONEY DEFAULT 0.00;

ALTER TABLE PizzaApp.Orders
ADD FirstName NVARCHAR(100) NOT NULL;

----------Foreign Key Assignments----------
ALTER TABLE PizzaApp.Users
ADD CONSTRAINT FK_DefaultLocation FOREIGN KEY (DefaultLocation) REFERENCES PizzaApp.StoreLocation(CityName);

--had to remove this foreign key
ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Username FOREIGN KEY (Username) REFERENCES PizzaApp.Users(Username);

ALTER TABLE PizzaApp.Orders
DROP CONSTRAINT FK_Username

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Store_Location FOREIGN KEY (StoreLocation) REFERENCES PizzaApp.StoreLocation(CityName);

ALTER TABLE PizzaApp.Orders
DROP CONSTRAINT FK_Store_Location

-----Pizza Variation Foreign Key Alterations-----------
--had to drop all of these to allow repeats in the columns
ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num FOREIGN KEY (PizzaNum1) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num2 FOREIGN KEY (PizzaNum2) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num3 FOREIGN KEY (PizzaNum3) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num4 FOREIGN KEY (PizzaNum4) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num5 FOREIGN KEY (PizzaNum5) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num6 FOREIGN KEY (PizzaNum6) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num7 FOREIGN KEY (PizzaNum7) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num8 FOREIGN KEY (PizzaNum8) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num9 FOREIGN KEY (PizzaNum9) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num10 FOREIGN KEY (PizzaNum10) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num11 FOREIGN KEY (PizzaNum11) REFERENCES PizzaApp.PizzaVariation(PizzaID);

ALTER TABLE PizzaApp.Orders
ADD CONSTRAINT FK_Pizza_ID_Num12 FOREIGN KEY (PizzaNum12) REFERENCES PizzaApp.PizzaVariation(PizzaID);
GO

----------Populating Database with Necessary Locations----------

INSERT INTO PizzaApp.StoreLocation VALUES ('Reston', 1000, 1000, 1000, 1000, 1000, 1000);

INSERT INTO PizzaApp.StoreLocation VALUES ('Herndon', 1000, 1000, 1000, 1000, 1000, 1000);

INSERT INTO PizzaApp.StoreLocation VALUES ('Dulles', 1000, 1000, 1000, 1000, 1000, 1000);

INSERT INTO PizzaApp.StoreLocation VALUES ('Hattontown', 1000, 1000, 1000, 1000, 1000, 1000);

SELECT * FROM PizzaApp.StoreLocation --inserted to check that values were properly added

----------Adding different pizza variations for later use in Order table----------

INSERT INTO PizzaApp.PizzaVariation VALUES ('none', 'none');

INSERT INTO PizzaApp.PizzaVariation VALUES ('small', 'cheese');

INSERT INTO PizzaApp.PizzaVariation VALUES ('medium', 'cheese');

INSERT INTO PizzaApp.PizzaVariation VALUES ('large', 'cheese');

INSERT INTO PizzaApp.PizzaVariation VALUES ('small', 'pepperoni');

INSERT INTO PizzaApp.PizzaVariation VALUES ('medium', 'pepperoni');

INSERT INTO PizzaApp.PizzaVariation VALUES ('large', 'pepperoni');

INSERT INTO PizzaApp.PizzaVariation VALUES ('small', 'meat');

INSERT INTO PizzaApp.PizzaVariation VALUES ('medium', 'meat');

INSERT INTO PizzaApp.PizzaVariation VALUES ('large', 'meat');

INSERT INTO PizzaApp.PizzaVariation VALUES ('small', 'veggie');

INSERT INTO PizzaApp.PizzaVariation VALUES ('medium', 'veggie');

INSERT INTO PizzaApp.PizzaVariation VALUES ('large', 'veggie');

SELECT * FROM PizzaApp.PizzaVariation;  --added for verification that all type variations were added properly
GO

----------Triggers----------
--cannot delete orders
CREATE TRIGGER PizzaApp.TR_Order_ReplaceDelete
ON PizzaApp.Orders
INSTEAD OF DELETE
AS
	PRINT 'Unable to delete or replace orders';

DELETE FROM PizzaApp.Orders --test query
GO

--cannot delete locations
CREATE TRIGGER PizzaApp.TR_Location_ReplaceDelete
ON PizzaApp.StoreLocation
INSTEAD OF DELETE
AS
	Print 'Unable to delete or replace locations';

DELETE FROM PizzaApp.StoreLocation; --test query
SELECT * FROM PizzaApp.StoreLocation; --test query
GO

--cannot delete users
CREATE TRIGGER PizzaApp.TR_Users_ReplaceDelete
ON PizzaApp.Users
INSTEAD OF DELETE
AS
	Print 'Unable to delete or replace users';

DELETE FROM PizzaApp.Users; --test query
GO

--cannot update users (should still be able to insert new user)
CREATE TRIGGER PizzaApp.TR_Users_ReplaceUpdate
ON PizzaApp.Users
INSTEAD OF UPDATE
AS
	Print 'Unable to update users. Please make new user.';

UPDATE PizzaApp.Users
SET Username = 'Test'
WHERE Username = 'OtherTest'; --test query
GO

----------Forgot to add Recommended Pizza column to Users table----------
ALTER TABLE PizzaApp.Users
ADD RecommendedPizza NVARCHAR(9) DEFAULT 'Cheese'

----------Test Queries----------
Update PizzaApp.StoreLocation
Set DoughRemaining = 1000
where CityName = 'Reston';

Update PizzaApp.StoreLocation
Set DoughRemaining = 1000
where CityName = 'Herndon';

Update PizzaApp.StoreLocation
Set DoughRemaining = 1000
where CityName = 'Hattontown';

Update PizzaApp.StoreLocation
Set DoughRemaining = 1000
where CityName = 'Dulles';

SELECT * FROM PizzaApp.Users;

SELECT * FROM PizzaApp.Orders;

--Had to alter primary key in the Users table
SELECT * 
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
WHERE TABLE_NAME = 'Users'

ALTER TABLE PizzaApp.Users DROP CONSTRAINT PK__Users__536C85E5EBA59E62

ALTER TABLE PizzaApp.Users ADD CONSTRAINT PK_Email PRIMARY KEY (EmailAddress)

TRUNCATE TABLE PizzaApp.Orders

SELECT * FROM PizzaApp.Orders