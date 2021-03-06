USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_customer_information]    Script Date: 23/09/1400 07:54:22 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_customer_information]
	@CustomerCode int,
	@BranchCode smallint
AS
BEGIN
	SET NOCOUNT ON;

	select TOP 1 CAST(Fdmj00 as int) as Shobe,Fdmj02 as CodeMoshtari,Fdmj03 as CodePishe,CAST(Fdmj09 as int) as CodeOstan,Gost02 as NameOstan,CAST(Fdmj10 as int) as CodeShahr,gcit02 as NameShahr,CAST(Fdmj11 as int) as CodeMantaghe,Floc04 as NameMantaghe,CAST(Fdmj12 as int) as [CodeMasir], Fpat05 as NameMasir,Fdmj13 as [Tell],Fdmj14 as [Mobile],Fdmj15 as [Address],Fdmj17 as Vaziat,Fhms37 as [Message]
	from F_dMoshtariJob	left join Gostan on (Gost01=Fdmj09) left join Gcity on (Gcit01=Fdmj10 and Fdmj09=Gcit06) left join F_Location on (floc01=Fdmj09 and Floc02=Fdmj10 and Floc03=Fdmj11 ) left join F_Path on (Fpat01=Fdmj09 and fpat02=Fdmj10 and Fpat03=Fdmj11 and Fpat04=Fdmj12 ) left join f_hmoshtari on (Fdmj00=Fhms00 and Fdmj01=Fhms01 and Fdmj02=Fhms02 and Fdmj03=Fdmj03) 
	where Fhms01=2 And exists(
		Select Fhbr01 
		From F_hBranch Left Outer Join F_dBranchUser on(Fhbr01=Fdbu01) Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
		Where Fhbr01=Fhms00 And (Fdbu02=2 Or Fdtu03=2)) 
			AND (Fdmj02 = @CustomerCode) AND (Fdmj00 = @BranchCode)

/* Fhms00 = کد شعبه */
/* Fdtu01 = کد شعبه */
/* Fdbu01 = کد شعبه */
/* Fhbr01 = کد شعبه */
/* Fdbu02 = کد کاربر */
/* Fdtu02 = کد کاربر */
/* Fdtu03 = كد كاربر قابل دسترس */
/* fhms00 = کد شعبه */
/* fhms01 =  کد مشتری */

END
