USE [CentralDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_mantaghe_list]    Script Date: 27/08/1400 12:31:21 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[sp_login]
	@Password nvarchar,
	@Username nvarchar	
AS
DECLARE @UserID bigint;
    
  BEGIN

	
	SELECT @UserID=dbo.Users.Use01 FROM dbo.Users WHERE dbo.Users.Use09=@Username and dbo.Users.Use15=@Password and dbo.Users.Use14=1


	IF (@UserID IS NOT NULL)
	BEGIN
		SELECT CAST(1 AS BIGINT) AS id,CAST(@UserID AS NVARCHAR(50)) AS [Resault]
	END
	ELSE
	BEGIN
		SELECT CAST(1 AS BIGINT) AS id,CAST('E' AS nvarchar(50)) AS [Resault]
	END
END 

