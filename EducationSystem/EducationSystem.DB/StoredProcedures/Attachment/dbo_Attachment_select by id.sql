create  proc [dbo].[Attachment_SelectById] (
@id int
) as begin
	select 
		a.Id, 
		a.Path,
		a.AttachmentTypeID,
		at.Name

from [dbo].[Attachment] a
	inner join [dbo].[AttachmentType] at 
	on a.AttachmentTypeID = at.Id
	where a.Id = @id
end