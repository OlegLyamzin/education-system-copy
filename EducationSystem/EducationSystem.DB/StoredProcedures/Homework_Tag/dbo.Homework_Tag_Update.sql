create proc [dbo].[Homework_Tag_Update] (
      @id int,
	  @tagid int,
	  @Homeworkid int
) as
begin
  update dbo.Homework_Tag
  set
  TagId=@tagid,
  HomeworkId=@Homeworkid
  where Id=@id
end