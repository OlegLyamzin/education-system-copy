create proc [dbo].[User_Role_Add] (
	@userid int,
	@roleid int
) as
begin
	INSERT INTO dbo.User_Role (UserID, RoleID) VALUES(@userid, @roleid)
end