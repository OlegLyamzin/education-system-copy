create proc [dbo].[User_DeleteOrRecover]
(	
	@id int,
	@isDeleted bit
)
as
begin
	update dbo.[User]
		set IsDeleted=@isDeleted
	where Id=@id
end