USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_Role_Delete]    Script Date: 07.02.2021 15:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[User_Role_Delete] (
	@id int
) as
begin
	DELETE FROM dbo.User_Role WHERE Id = @id
end