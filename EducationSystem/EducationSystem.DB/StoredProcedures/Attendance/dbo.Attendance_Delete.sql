create proc [dbo].[Attendance_Delete](@Id int)
as
begin
Delete from dbo.Attendance where Id = @Id
end