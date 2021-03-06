USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_mosavabe_list]    Script Date: 30/08/1400 10:23:49 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
ALTER PROCEDURE [dbo].[sp_mosavabe_list]
	@Fhmo05 nvarchar,
	@Fdmb02 smallint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @Fhmo05 = REPLACE(@Fhmo05, 'D', '/');

	Select Distinct CAST(Fhmo01 AS smallint) as [Code],Fhmo03 as [Sharh]
	From F_hMosavab
		Left Outer Join F_dMosavab on(Fhmo01=Fdmo01)
		Left Outer Join Aanbar on(Fdmo02=Aanb01)
		Left Outer Join F_Kala on(Fdmo02=Fkal00 and Fdmo03=Fkal01)
		Left Outer Join F_dMosavabBranch on (Fdmb01=Fhmo01) 
		Left Outer Join F_dMosavabGroupCustomer on (Fdmc01=Fhmo01)
		Left Outer Join F_dGroup on (Fdgr01=Fdmc02)
	Where (Fhmo01 is not null )
		And   (Fhmo04=0 or (Fhmo04=1 And Fhmo05>=@Fhmo05))  -- به جای مقدار تاریخ، تاریخ برگه قرار گیرد 
		And( Fdmb02>=@Fdmb02 and Fdmb02<=@Fdmb02)   -- به جای مقادیر، کد شعبه قرار گیرد
		And( Fhmo01>=1 and Fhmo01<=999999)

END
