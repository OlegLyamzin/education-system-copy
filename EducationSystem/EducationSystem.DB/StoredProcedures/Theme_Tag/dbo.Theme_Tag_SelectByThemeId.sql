create proc [dbo].[Theme_Tag_SelectByThemeId](
	@id int
) as
begin 
select
		tt.Id,
		tt.TagId,
		tt.ThemeId
		from dbo.Theme_Tag as tt where tt.ThemeId=@id
end