USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_F_hSefareshSeller]    Script Date: 16/09/1400 08:55:58 ق.ظ ******/
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
	if(@CodeSupervisor=0 or @CodeSupervisor=null)
	begin
		set @CodeSupervisor = null;
		set @Supervisor = null;
	end
	else
	begin
		set @Supervisor = 5;
	end

	set @TarikheRooz = REPLACE(@TarikheRooz,'D','/');
	set @TarikhBarge = REPLACE(@TarikhBarge,'D','/');

	-- agar supervisor meghdar dasht 5 gharar midim (ke field badi ham code supervisor ro gharar midim) ELSE null .
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

		SELECT CAST(1 as bigint)AS [id],'DONE' as [result];
	END TRY
	BEGIN CATCH
		SELECT CAST(ERROR_NUMBER() as bigint) AS [id], ERROR_MESSAGE() AS [result];
	END CATCH
END
