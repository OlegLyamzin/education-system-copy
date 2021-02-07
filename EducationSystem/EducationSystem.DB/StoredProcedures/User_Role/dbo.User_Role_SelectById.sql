create proc [dbo].[User_Role_SelectById] (
	@id int
) as
begin
	SELECT ur.Id, ur.UserID, r.Id, r.Name FROM  User_Role as ur INNER JOIN Role as r ON ur.RoleID = r.Id WHERE ur.Id = @id
end