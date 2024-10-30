CREATE PROCEDURE [dbo].[AddPerson]
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@DateOfBirth Date
AS
BEGIN
	INSERT INTO People (FirstName, LastName, DateOfBirth)
	VALUES (@FirstName, @LastName, @DateOfBirth)
END
