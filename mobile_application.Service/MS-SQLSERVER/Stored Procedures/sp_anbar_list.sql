USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_pishe_list]    Script Date: 18/09/1400 10:15:09 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_anbar_list]
	@BranchCode smallint
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Aanb01 as Code,Aanb02 as Sharh
	From Aanbar
		Inner Join F_dBranchAnbar on(Fdba02=Aanb01)
	Where Aanb01 is not null
		And Fdba01=1
		and Fdba03=1


/* Fdba01=کد شعبه */
/* Fdba03 = مقدار همیشه برابر با یک است*/

END
