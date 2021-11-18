USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_objects_list_get_object_name]    Script Date: 15/08/1400 02:24:54 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست کالا با پارامتر نام کالا
-- =============================================
CREATE PROCEDURE [dbo].[sp_seller_list]
	@code_karbar int,
	@code_shobe int
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Fhms02 as Code,Fhms03 as Sharh,Null as Job,Fhms07 as Address,Fhms05 as Tel,Fhms00 as Branch
	From F_hMoshtari
	Left Outer Join (Select Fdmj00 MaxFdmj00,Fdmj01 MaxFdmj01,Fdmj02 MaxFdmj02,Max(Fdmj03) MaxFdmj03 From F_dMoshtariJob Group by Fdmj00,Fdmj01,Fdmj02) MaxF_dMoshtariJob on(MaxFdmj00=Fhms00 and MaxFdmj01=Fhms01 and MaxFdmj02=Fhms02)
	Left Outer Join F_dMoshtariJob on(Fdmj00=Fhms00 and Fdmj01=Fhms01 and Fdmj02=Fhms02 and Fdmj03=MaxFdmj03)
	Left Outer Join F_hBranch on(Fhbr01=Fhms00)
	Left Outer Join Gcity on(Gcit01=Fdmj10)
	Where Fhms95=1 And isnull(Fhbr95,0)=1 
	And   Fhms02 is not null 
	And   Fhms01=1
	And exists(Select Fdbu01
           From F_dBranchUser 
           Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@code_karbar Or Fdtu03=@code_karbar))
	And   Fhms00=@code_shobe
	and (isnull(Fhms03,'') Like '%%')

	/* Fhms00=1   کد شعبه */
	/* Fdbu02=2 کد کاربر */
	/* Fdtu02 = کد کاربر */
	/* Fdtu01 = کد شعبه */
	/* Fdbu01 = کد شعبه */
	/* Fhbr01 = کد شعبه */

END