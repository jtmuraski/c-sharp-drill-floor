CREATE PROCEDURE [dbo].[DeletePerson]
	@Id Int
AS
	DELETE FROM People
	WHERE Id = @Id
RETURN 0
