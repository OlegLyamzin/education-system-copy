create proc [dbo].[Attendance_Update]( 
@id int,
@LessonId int, 
@UserId int,
@IsAbsent bit)
as
begin
Update dbo.Attendance Set LessonId = @LessonId, UserId = @UserId, IsAbsent = @IsAbsent where Id=@id
end