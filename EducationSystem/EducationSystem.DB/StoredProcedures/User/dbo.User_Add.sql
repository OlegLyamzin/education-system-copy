USE [DevEdu]
GO
/****** Object:  StoredProcedure [dbo].[User_Add]    Script Date: 07.02.2021 15:40:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[User_Add]
(
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@birthDate datetime2,
	@login nvarchar(50),
	@password nvarchar(30),
	@phone nvarchar(20),
	@userPic nvarchar(1000),
	@email nvarchar(60)
)
as
begin
	INSERT INTO	dbo.[User] (FirstName, LastName, BirthDate, Login, Password, Phone, UserPic, Email) 
	VALUES(@firstName, @lastName, @birthDate, @login, @password, @phone, @userPic, @email)
	select SCOPE_IDENTITY()
end
