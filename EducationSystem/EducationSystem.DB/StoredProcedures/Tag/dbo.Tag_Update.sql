create proc [dbo].[Tag_Update] (
      @id int,
	  @name nvarchar(30)
) as
begin
  update dbo.Tag
  set
 Name=@name
  where Id=@id
end