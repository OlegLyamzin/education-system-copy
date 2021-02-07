USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_Role_SelectAll]    Script Date: 07.02.2021 15:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[User_Role_SelectAll] as
begin
	SELECT ur.Id, ur.UserID, r.Id, r.Name FROM  User_Role as ur INNER JOIN Role as r ON ur.RoleID = r.Id 
end