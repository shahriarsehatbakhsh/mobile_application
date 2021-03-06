USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLatestAvailableCustomerCode]    Script Date: 23/09/1400 08:46:08 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetLatestAvailableCustomerCode]
	@BranchCode smallint
AS
	DECLARE	
		@tmpLatestAvailableCustomerCode numeric(18,0) ,	
		@tmpLatestAvailableCustomerSerial numeric(18,0) ,
		@LatestAvailableCustomerCode int ,
		@LatestAvailableCustomerSerial int

	Select @tmpLatestAvailableCustomerCode = MAX(Fhms02)
	From F_hMoshtari
	Where Fhms00 = @BranchCode
	And Fhms01 = 2

	Select @tmpLatestAvailableCustomerSerial = MAX(Fhms29)
	From F_hMoshtari
	Where Fhms01 = 2

	SET @LatestAvailableCustomerCode = ISNULL(@tmpLatestAvailableCustomerCode,0) + 1
	SET @LatestAvailableCustomerSerial = ISNULL(@tmpLatestAvailableCustomerSerial,0) + 1

	Select @LatestAvailableCustomerCode  as CustomerCode, @LatestAvailableCustomerSerial as CustomerSerial


----------EXAMPLE----------
---------------------------

/*Declare @Code numeric(18,0) = NULL, @Serial numeric(18,0) = NULL

Exec sp_GetLatestAvailableCustomerCode @BranchCode = 2, @LatestAvailableCustomerCode = @Code Output, @LatestAvailableCustomerSerial = @Serial Output;

Select @Code, @Serial*/
