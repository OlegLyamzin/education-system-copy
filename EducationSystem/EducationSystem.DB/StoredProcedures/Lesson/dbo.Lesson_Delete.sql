create proc [dbo].[Lesson_Delete](@Id int)
as
begin
	UPDATE dbo.Lesson SET IsDeleted = 1 WHERE Id=@id
end