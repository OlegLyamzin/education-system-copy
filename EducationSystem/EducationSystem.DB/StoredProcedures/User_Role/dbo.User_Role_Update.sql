create proc [dbo].[User_Role_Update] (
	@id int,
	@userid int,
	@roleid int
) as
begin
	UPDATE dbo.User_Role SET UserID=@userid, RoleID=@roleid  WHERE Id=@id
end