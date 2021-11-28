USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_object_list]    Script Date: 07/09/1400 08:38:33 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
ALTER PROCEDURE [dbo].[sp_object_list]

AS
BEGIN
	SET NOCOUNT ON;

	Select CAST(Fkal01 AS smallint) AS Code,Fkal02 AS Sharh
	From F_Kala
	Where isnull(Fkal16,0)=0 And 
				 Fkal00= 1	AND (
				 Fkal02 Like '%%')	And 
				 Fkal95=1

END
