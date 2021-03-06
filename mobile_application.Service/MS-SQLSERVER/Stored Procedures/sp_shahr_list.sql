USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_customers_list_get_code_shobe]    Script Date: 17/08/1400 01:44:10 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
CREATE PROCEDURE [dbo].[sp_shahr_list]
	
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Gcit01 as Code,Gcit02 as Sharh
	From Gcity
		Left Outer Join F_dBranchLoc on(Fdbl02=Gcit06 and Fdbl03=Gcit01)
		Left Outer Join F_dBranchUser on(Fdbu01=Fdbl01)
	Where Gcit01 is not null
		And Fdbu02=2
		And Gcit06= 1
		and (Gcit02 Like '%%')

END
