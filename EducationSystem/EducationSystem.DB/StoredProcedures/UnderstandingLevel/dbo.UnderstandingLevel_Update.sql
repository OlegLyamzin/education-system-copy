create proc [dbo].[UnderstandingLevel_Update]( @id int, @Name nvarchar(100))
as
begin
Update dbo.UnderstandingLevel Set Name = @Name where Id=@id
end