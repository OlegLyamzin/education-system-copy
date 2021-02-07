create proc [dbo].[Material_Tag_Update] (
      @id int,
	  @tagid int,
	  @materialid int
) as
begin
  update dbo.Material_Tag
  set
  TagId=@tagid,
  MaterialId=@materialid
  where Id=@id
end