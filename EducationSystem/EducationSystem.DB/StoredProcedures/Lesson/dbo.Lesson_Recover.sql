create proc [dbo].[Lesson_Recover]
	@Id int
as
begin
	update dbo.Lesson
	set
	IsDeleted = 0
	where Id=@id
end