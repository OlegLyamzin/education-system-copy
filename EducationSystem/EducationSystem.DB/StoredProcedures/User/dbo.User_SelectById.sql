create proc [dbo].[User_SelectById]
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