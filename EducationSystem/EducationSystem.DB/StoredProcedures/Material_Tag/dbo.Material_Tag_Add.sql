create proc [dbo].[Material_Tag_Add] (
	@TagId int,
	@MaterialId int
) as
begin
	insert into dbo.Material_Tag(TagId,MaterialId)
	values (@TagId,@MaterialId)
	select SCOPE_IDENTITY()
end