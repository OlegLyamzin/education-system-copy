create proc [dbo].[Attendance_Update]( 
@id int,
@IsAbsent bit,
@ReasonOfAbsence nvarchar(max))
as
begin
Update dbo.Attendance Set IsAbsent = @IsAbsent,ReasonOfAbsence = @ReasonOfAbsence where Id=@id
end