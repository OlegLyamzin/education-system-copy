create proc [dbo].[User_Delete]
(
	@id int
)
as
begin
	UPDATE dbo.[User] SET IsDeleted=1 WHERE Id=@id
end