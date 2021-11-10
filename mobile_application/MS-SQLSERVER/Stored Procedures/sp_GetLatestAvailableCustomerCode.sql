CREATE PROCEDURE [dbo].[sp_GetLatestAvailableCustomerCode]
	@BranchCode smallint,
	@LatestAvailableCustomerCode numeric(18,0) = NULL OUTPUT,
	@LatestAvailableCustomerSerial numeric(18,0) = NULL OUTPUT
AS
	DECLARE	@tmpLatestAvailableCustomerCode numeric(18,0),	@tmpLatestAvailableCustomerSerial numeric(18,0)

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