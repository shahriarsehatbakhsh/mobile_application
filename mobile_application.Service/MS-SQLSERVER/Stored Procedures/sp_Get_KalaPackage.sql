USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLatestAvailableBargashtSodoorCode]    Script Date: 18/09/1400 08:21:25 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[sp_Get_KalaPackage]
	@BranchCode smallint,
	@KalaCode char(20)
AS
	Select Distinct Fpac01 as Code,Fpac02 as Sharh,Fkpa04 as [Value],CAST(Fkpa07 as int) as [Type]
	From F_Package
		Left Outer Join F_KalaPackage on(Fpac01=Fkpa01)
	Where Fkpa01 is not null
		And Fkpa02=@BranchCode
		And Fkpa03=@KalaCode
		And (Fpac02 Like '%%')
		AND (Fkpa06 = 1)

/* Fkpa02=کد انبار */
/* Fkpa03=کد کالا */


