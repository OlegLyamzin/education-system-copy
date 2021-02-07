USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[Homework_Tag_SelectById]    Script Date: 07.02.2021 15:25:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Homework_Tag_SelectById](@Id int)
as
begin
select
		ht.Id,
		ht.TagId,
		ht.HomeworkId,
		t.Id,
		t.Name
		from dbo.Homework_Tag as ht inner join dbo.Tag as t on ht.Id = t.Id
	where ht.Id = @id
end