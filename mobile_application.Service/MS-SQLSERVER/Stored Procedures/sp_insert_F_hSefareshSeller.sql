USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_F_hSefareshSeller]    Script Date: 08/09/1400 09:05:11 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_insert_F_hSefareshSeller]
	-- Add the parameters for the stored procedure here
		   @CodeShobe smallint,
		   @sp_GetLatestAvailableSefareshHeaderCode_HeaderCode int,
		   @TarikhBarge char(10),
		   @CodeMoshtari int,
		   @CodeForooshande int,
		   @CodeMosavabe int,
		   @NoeTasvie int,
		   @ModdateTasvie tinyint,
		   @sp_GetAvailableCustomerJob smallint,
		   @sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial int,
		   @Supervisor int, 
		   @CodeSupervisor int,
		   @CodeKarbar smallint,
		   @TarikheRooz char(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF NOT(@Supervisor=NULL)
		set @Supervisor=5;  -- agar supervisor meghdar dasht 5 gharar midim (ke field badi ham code supervisor ro gharar midim) ELSE null .
    -- Insert statements for procedure here
	BEGIN TRY
		insert into F_hSefareshSeller (Fhss00,Fhss01,Fhss02,Fhss03,Fhss04,Fhss05,Fhss06,Fhss07,Fhss08,Fhss10,Fhss11,Fhss12,Fhss14,Fhss18,Fhss19,Fhss94,Fhss95,Fhss98,Fhss99)
		values(@CodeShobe,
			   @sp_GetLatestAvailableSefareshHeaderCode_HeaderCode,1,
			   @TarikhBarge,2,
			   @CodeMoshtari,1,
			   @CodeForooshande,
			   @CodeMosavabe,
			   @NoeTasvie,
			   @ModdateTasvie,
			   @sp_GetAvailableCustomerJob,
			   @sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial,
			   @Supervisor, 
			   @CodeSupervisor,0,0,
			   @CodeKarbar,
			   @TarikheRooz)

		SELECT 1,'DONE';
	END TRY
	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END
