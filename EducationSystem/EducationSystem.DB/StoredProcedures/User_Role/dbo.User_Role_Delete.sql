create proc [dbo].[User_Role_Delete]
	@userId int,
	@roleId int 
as
	DELETE FROM dbo.User_Role WHERE UserID = @userId and RoleID = @roleId
