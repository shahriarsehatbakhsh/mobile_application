USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_F_hSefareshSeller]    Script Date: 09/09/1400 01:14:05 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_F_hSefareshHeaderCodeSerial]
	-- Add the parameters for the stored procedure here
		   @BranchCode smallint

AS
DECLARE
	@LatestAvailableSefaresbHeaderCode numeric(18,0),
	@LatestAvailableSefaresbHeaderSerial numeric(18,0),
	@tmpLatestAvailableSefaresbHeaderCode numeric(18,0),	
	@tmpLatestAvailableSefaresbHeaderSerial numeric(18,0)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select @tmpLatestAvailableSefaresbHeaderCode = MAX(Fhss01)
	From F_hSefareshSeller
	Where Fhss00 = @BranchCode
	

	Select @tmpLatestAvailableSefaresbHeaderSerial = MAX(Fhss14)
	From F_hSefareshSeller
	

	SET @LatestAvailableSefaresbHeaderCode = ISNULL(@tmpLatestAvailableSefaresbHeaderCode,0) + 1
	SET @LatestAvailableSefaresbHeaderSerial = ISNULL(@tmpLatestAvailableSefaresbHeaderSerial,0) + 1

	Select @LatestAvailableSefaresbHeaderCode as HeaderCode, @LatestAvailableSefaresbHeaderSerial as HeaderSerial
END
