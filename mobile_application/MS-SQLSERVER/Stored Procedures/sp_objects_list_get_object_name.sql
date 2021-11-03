USE [PayaPakhsh]
GO
/****** Object:  StoredProcedure [dbo].[sp_objects_list_get_object_name]    Script Date: 12/08/1400 10:53:01 ق.ظ ******/
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

	SELECT DISTINCT Fkal01 AS Code,Fkal02 AS Sharh 
	FROM F_Kala 
	WHERE ISNULL(Fkal16,0)=0 AND Fkal00= 1 AND (Fkal02 Like '%'+@object_name+'%')
END
