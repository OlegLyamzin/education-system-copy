create proc [dbo].[Attendance_Update]( 
@id int,
@IsAbsent bit)
as
begin
Update dbo.Attendance Set IsAbsent = @IsAbsent where Id=@id
end