create proc [dbo].[Lesson_DeleteOrRecover]
	@id int,
	@isDeleted bit
as
begin
	update dbo.Lesson
	set
		IsDeleted = @isDeleted
	where Id=@id
end