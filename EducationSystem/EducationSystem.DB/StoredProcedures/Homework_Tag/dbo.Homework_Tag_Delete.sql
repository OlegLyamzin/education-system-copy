USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[Homework_Tag_Delete]    Script Date: 07.02.2021 15:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 ALTER proc [dbo].[Homework_Tag_Delete] (
@id int
) as
begin
	delete from dbo.Homework_Tag
	where Id = @id
end