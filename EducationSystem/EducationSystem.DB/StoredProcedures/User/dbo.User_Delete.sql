create proc [dbo].[User_Delete]
(	
	@id int
)
as
begin
	update dbo.[User]
	set IsDeleted=1
	where Id=@id
end