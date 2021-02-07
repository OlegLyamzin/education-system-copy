USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_Role_Update]    Script Date: 07.02.2021 15:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[User_Role_Update] (
	@id int,
	@userid int,
	@roleid int
) as
begin
	UPDATE dbo.User_Role SET UserID=@userid, RoleID=@roleid  WHERE Id=@id
end