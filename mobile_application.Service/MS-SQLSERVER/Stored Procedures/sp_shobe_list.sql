USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_shobe_list]    Script Date: 15/08/1400 02:43:36 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست کالا با پارامتر نام کالا
-- =============================================
ALTER PROCEDURE [dbo].[sp_shobe_list]
	@code_karbar int,
	@code_karbar_per int
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Fhbr01 as Code,Fhbr02 as Sharh
	From F_hBranch
	Left Outer Join F_dBranchUser on(Fhbr01=Fdbu01)
	Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
	Where Fhbr95=1 And (Fdbu02=@code_karbar Or Fdtu03=@code_karbar_per)
	and (Fhbr02 Like '%%')

	/* Fdbu02= کد کاربر */
	/* Fdtu03= كد كاربر قابل دسترس */

END