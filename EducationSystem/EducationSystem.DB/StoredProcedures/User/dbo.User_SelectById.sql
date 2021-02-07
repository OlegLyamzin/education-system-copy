USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_SelectById]    Script Date: 07.02.2021 15:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[User_SelectById]
(
	@id int
)
as
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
  FROM [DevEdu].[dbo].[User] WHERE Id=@id AND IsDeleted=0
end