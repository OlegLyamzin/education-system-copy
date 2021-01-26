create proc [dbo].[Group_SelectById] (
	@id int
) as
begin
	select
		g.Id,
		g.StartDate,
		c.Id,
		c.Name,
		gs.Id,
		gs.Name
from dbo.[Group] g inner join dbo.Course c on g.CourseID = c.Id
	inner join dbo.GroupStatus gs on g.StatusId = gs.Id
	where g.Id = @id
end

