USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[Group_SelectById]    Script Date: 21.01.2021 22:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Group_SelectById] (
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

