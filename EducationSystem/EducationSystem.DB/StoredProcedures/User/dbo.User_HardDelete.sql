USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_HardDelete]    Script Date: 07.02.2021 15:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[User_HardDelete]
(
	@id int
)
as
begin
	delete dbo.[User] WHERE Id=@id
end