create proc [dbo].[Tag_Delete] (
@id int
) as
begin
	delete from dbo.Tag
	where Id = @id
end