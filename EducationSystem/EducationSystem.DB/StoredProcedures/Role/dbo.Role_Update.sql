create proc [dbo].[Role_Update](
	@id int,
	@name nvarchar(60)
) as
begin
	update dbo.Role set Name = @name
end