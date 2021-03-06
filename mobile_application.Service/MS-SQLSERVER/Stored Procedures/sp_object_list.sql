USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_object_list]    Script Date: 20/09/1400 08:26:55 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
ALTER PROCEDURE [dbo].[sp_object_list]
	@BranchCode smallint,
	@ObjectName Nvarchar(500)
AS
BEGIN
	SET NOCOUNT ON;

	Select CAST(Fkal01 AS smallint) AS Code,Fkal02 AS Sharh
	From F_Kala
	Where isnull(Fkal16,0)=0 And 
				 Fkal00= @BranchCode AND (
				 Fkal02 Like '%' + @ObjectName + '%') And 
				 Fkal95=1

END
