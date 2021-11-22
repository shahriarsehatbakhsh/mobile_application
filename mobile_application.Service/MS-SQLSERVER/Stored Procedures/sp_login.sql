USE [CentralDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 01/09/1400 11:02:41 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_login]
	@Password nvarchar(50),
	@Username nvarchar(50)	
AS
DECLARE @UserID bigint;
    
  BEGIN

	
	SELECT @UserID=dbo.Users.Use01 FROM dbo.Users WHERE dbo.Users.Use09=@Username and dbo.Users.Use15=@Password and dbo.Users.Use14=1


	IF (@UserID IS NOT NULL)
	BEGIN
		SELECT CAST(1 AS BIGINT) AS id,CAST(@UserID AS NVARCHAR(50)) AS [result]
	END
	ELSE
	BEGIN
		SELECT CAST(1 AS BIGINT) AS id,CAST('E' AS nvarchar(50)) AS [result]
	END
END 

