USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAvailableCustomerJob]    Script Date: 09/09/1400 02:50:21 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_GetAvailableCustomerJob]
	@BranchCode smallint,
	@CustomerCode smallint,
	@SefareshDate char(10),
	@JobNo int  = NULL 

AS
	DECLARE	@tmpJobNo int

	set @SefareshDate = REPLACE(@SefareshDate, 'D', '/');

	Select top 1 @tmpJobNo = Fdmj03 From F_dMoshtariJob
Where Fdmj95=1 And Fdmj00=@BranchCode And Fdmj01=2 And Fdmj02=@CustomerCode
And   Fdmj05<=@SefareshDate
Order by Fdmj03 Desc

SET @JobNo = ISNULL(@tmpJobNo,0) 
	Select @JobNo  as JobNo




