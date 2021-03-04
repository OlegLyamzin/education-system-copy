﻿create proc [dbo].[User_SelectById]
(
	@id int
)
as
	SELECT  
	u.[Id]
      ,u.[FirstName]
      ,u.[LastName]
      ,u.[BirthDate]
      ,u.[Login]
      ,u.[Password]
      ,u.[Phone]
      ,u.[UserPic]
      ,u.[Email],
      u.IsDeleted,
      r.Id,
	  r.Name as [Role]
  FROM [dbo].[User] as u
  inner join dbo.[User_Role] as ur on u.Id = ur.UserID
  inner join dbo.[Role] as r on ur.RoleID = r.Id 
  where u.Id = @id