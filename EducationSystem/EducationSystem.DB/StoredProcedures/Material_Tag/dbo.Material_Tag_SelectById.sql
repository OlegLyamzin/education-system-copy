create proc [dbo].[Material_Tag_SelectById](
	@id int
) as
begin
	select
		mt.Id,
		mt.TagId,
		t.Name,
		mt.MaterialId
		from dbo.Material_Tag as mt inner join dbo.Tag as t on mt.Id = t.Id where mt.Id = @id
end