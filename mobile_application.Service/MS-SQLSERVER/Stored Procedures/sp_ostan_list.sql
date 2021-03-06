USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_customers_list_get_code_shobe]    Script Date: 17/08/1400 01:42:14 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
CREATE PROCEDURE [dbo].[sp_ostan_list]

AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Gost01 as Code,Gost02 as Sharh
	From Gostan
		Left Outer Join F_dBranchLoc on(Fdbl02=Gost01)
		Left Outer Join F_dBranchUser on(Fdbu01=Fdbl01)
	Where Fdbu02=2
		and (Gost02 Like '%%')

END
