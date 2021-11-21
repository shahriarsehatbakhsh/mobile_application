USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_ostan_list]    Script Date: 30/08/1400 12:53:14 ب.ظ ******/
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
	@BargeDate NVARCHAR

AS
DECLARE 
	@CustState INT

BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 @CustState = fdmj17 
	FROM F_dmoshtarijob 
	WHERE Fdmj01=2 and Fdmj00=@BranchCode and Fdmj02=@CustomerCode and fdmj05<=REPLACE(@BargeDate, 'D', '/')
	ORDER BY fdmj05 desc

	
	SELECT CAST(1 AS bigint) AS [id],CAST(@CustState AS NVARCHAR) AS [Result]
	
END





--1=قبول
--2=مشروط
--3=رد