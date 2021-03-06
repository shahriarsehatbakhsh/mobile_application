USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_customer_state]    Script Date: 01/09/1400 10:32:32 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- دریافت لیست مشتری با پارامتر کد شعبه
-- =============================================
ALTER PROCEDURE [dbo].[sp_customer_state]
	@BranchCode INT,
	@CustomerCode INT,
	@BargeDate NVARCHAR(15)

AS
DECLARE
	@id bigint = 1,
	@result nvarchar(15)

BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 @result = CAST(fdmj17 AS bigint)
	FROM F_dmoshtarijob 
	WHERE Fdmj01=2 and 
		  Fdmj00=@BranchCode and 
		  Fdmj02=@CustomerCode and 
		  fdmj05<=REPLACE(@BargeDate, 'D', '/')
	ORDER BY fdmj05 desc

	select @id AS [id],@result AS [result]
	
END





--1=قبول
--2=مشروط
--3=رد