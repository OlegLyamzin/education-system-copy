create proc [dbo].[Lesson_Delete]
( @Id int
 )
as
begin
	update dbo.Lesson
	set
	IsDeleted = 1
	where Id=@id
end