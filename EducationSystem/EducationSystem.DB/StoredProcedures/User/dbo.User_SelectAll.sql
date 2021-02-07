USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_SelectAll]    Script Date: 07.02.2021 15:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[User_SelectAll] as
begin
	SELECT  [Id]
      ,[FirstName]
      ,[LastName]
      ,[BirthDate]
      ,[Login]
      ,[Password]
      ,[Phone]
      ,[UserPic]
      ,[Email]
      ,[RegistrationDate]
      ,[IsDeleted]
  FROM [DevEdu].[dbo].[User] WHERE IsDeleted=0
end