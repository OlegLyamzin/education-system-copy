create proc [dbo].[User_Recover]
(	
	@id int
)
as
begin
	update dbo.[User]
	set IsDeleted=0
	where Id=@id
end