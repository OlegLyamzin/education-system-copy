create proc [dbo].[Material_Tag_Delete] (
@id int
) as
begin
	delete from dbo.Material_Tag
	where Id = @id
end