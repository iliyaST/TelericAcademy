--Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing.
--Write a stored procedure that selects the full names of all persons.


USE FinanceDatabase
GO

CREATE TABLE Persons(
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	SSN int NOT NULL

)

CREATE TABLE Accounts(
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	PersonID int NOT NULL FOREIGN KEY(PersonID) REFERENCES Persons(ID),
	Balance MONEY NOT NULL
)
GO

CREATE PROCEDURE GetFullName
	AS
	SELECT FirstName + ' ' + LastName AS [FullName] 
	FROM Persons

EXEC GetFullName
GO
--2.Create a stored procedure that accepts a number as a parameter and returns all 
--persons who have more money in their accounts than the supplied number.
	
CREATE PROCEDURE GetMoney
AS
	DECLARE @number money
	SET @number = 2000

	SELECT FirstName, LastName
	FROM Persons p, Accounts a
	WHERE a.PersonID = p.ID AND a.Balance > @number

EXEC GetMoney

GO
--03.Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.


ALTER FUNCTION ufn_Calculate(@sum money, @rate money, @months int)
RETURNS money
AS
BEGIN	
    DECLARE @result money, @interest money
	SET @interest = @rate / 12 * @months
	SET @result = (@sum * @interest) + @sum
	RETURN @result
END

DECLARE @resultPrice money
SET @resultPrice = dbo.ufn_Calculate(5000,10,12);
PRINT @resultPrice
GO
--04.Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--It should take the AccountId and the interest rate as parameters.

ALTER PROCEDURE usp_InterestForOneMonth
 @accountID AS int,
 @interest_rate AS money
AS
BEGIN
	DECLARE @currentBalance money;
	SET @currentBalance = (SELECT Balance FROM Accounts Where Accounts.ID = @accountID);

	DECLARE @resultBalance money = dbo.ufn_Calculate(@currentBalance,@interest_rate,1);

	UPDATE Accounts
	SET Balance = @resultBalance
	WHERE Accounts.ID = @accountID
END

EXEC usp_InterestForOneMonth 4,10;
GO

--05.Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.

CREATE PROCEDURE usp_WithdrawMoney
 @accountID AS int,
 @sum AS money
AS
BEGIN TRANSACTION
	DECLARE @currentBalance money;
	SET @currentBalance = (SELECT Balance FROM Accounts Where Accounts.ID = @accountID);

	IF(@currentBalance - @sum < 0)
	BEGIN
		PRINT 'Not enough money in account';
	END
	ELSE
	BEGIN
		DECLARE @resultBalance money = @currentBalance - @sum;
	END

	UPDATE Accounts
		SET Balance = @resultBalance
		WHERE Accounts.ID = @accountID
COMMIT TRANSACTION
GO


CREATE PROCEDURE usp_DepositMoney
 @accountID AS int,
 @sum AS money
AS
BEGIN TRANSACTION

	DECLARE @currentBalance money;
	SET @currentBalance = (SELECT Balance FROM Accounts Where Accounts.ID = @accountID);

	DECLARE @resultBalance money = @currentBalance + @sum;

	UPDATE Accounts
		SET Balance = @resultBalance
		WHERE Accounts.ID = @accountID

COMMIT TRANSACTION

EXEC usp_WithdrawMoney 4,10;
GO

EXEC usp_DepositMoney 4,1000
GO

--06.Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE Logs(
	LogID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AccountID int NOT NULL FOREIGN KEY REFERENCES dbo.Accounts(ID),
	OldSUm money,
	NewSum money,
	[Action] nvarchar(20)
)
GO

--UPDATE
ALTER TRIGGER dbo.utr_AccountActivitiesUPDATE ON Accounts
AFTER UPDATE
AS
BEGIN
	DECLARE @oldSum money = (SELECT Balance FROM deleted);
	DECLARE @newSum money = (SELECT Balance FROM inserted);

	INSERT INTO Logs(AccountID,OldSUm,NewSum,[Action])
		SELECT ID,@oldSum,@newSum,'UPDATE' FROM DELETED
END
GO

---TEST

EXEC usp_InterestForOneMonth 4,10;
GO

EXEC usp_WithdrawMoney 4,10;
GO

EXEC usp_DepositMoney 4,1000
GO

--07.Define a function in the database TelerikAcademy that returns all Employee's names 
--(first or middle or last name) and all town's names that are comprised of given set of letters.
--Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.