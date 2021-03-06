USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_objects_list_get_object_name]    Script Date: 23/09/1400 09:15:33 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- دریافت لیست کالا با پارامتر نام کالا
-- =============================================
ALTER PROCEDURE [dbo].[sp_objects_list_get_object_name]
	@object_name NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT CAST(Fkal01 as smallint) AS Code,Fkal02 AS Sharh 
	FROM F_Kala 
	WHERE ISNULL(Fkal16,0)=0 AND Fkal00= 1 AND (Fkal02 Like '%' + @object_name + '%')
END
