create proc [dbo].[Homework_Tag_Add](
@TagId int,
@HomeworkId int)
as
begin
Insert Into dbo.Homework_Tag(TagId,HomeworkId) Values (@TagId,@HomeworkId)
select SCOPE_IDENTITY()
end