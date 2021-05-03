create proc [dbo].[Lesson_Add](
@GroupID int,
@Description nvarchar(Max),
@Date datetime2)
as
	begin
		Insert Into dbo.Lesson(GroupID,Description,Date, IsDeleted) Values(@GroupID,@Description,@Date, 0)
		select SCOPE_IDENTITY()
	end