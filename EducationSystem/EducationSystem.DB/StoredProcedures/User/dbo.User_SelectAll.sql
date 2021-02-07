create proc [dbo].[User_SelectAll] as
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