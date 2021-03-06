USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_object_list_search]    Script Date: 07/09/1400 08:40:12 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
ALTER PROCEDURE [dbo].[sp_object_list_search]
	@object nvarchar(500)
AS
BEGIN
	SET NOCOUNT ON;

	Select CAST(Fkal01 AS smallint) AS Code,Fkal02 AS Sharh
	From F_Kala
	Where isnull(Fkal16,0)=0 And 
				 Fkal00= 1	AND (
				 Fkal02 Like '%' + @object + '%')	And 
				 Fkal95=1

END
