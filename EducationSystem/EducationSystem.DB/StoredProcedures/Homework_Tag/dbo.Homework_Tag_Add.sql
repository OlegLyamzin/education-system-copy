USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[Homework_Tag_Add]    Script Date: 07.02.2021 15:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Homework_Tag_Add](
@TagId int,
@HomeworkId int)
as
begin
Insert Into dbo.Homework_Tag(TagId,HomeworkId) Values (@TagId,@HomeworkId)
end