create proc [dbo].[User_Role_Delete] (
	@id int
) as
begin
	DELETE FROM dbo.User_Role WHERE Id = @id
end