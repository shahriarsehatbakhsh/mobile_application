USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_pishe_list]    Script Date: 17/08/1400 01:47:22 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_masir_list]
	
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Fpat04 as Code,Fpat05 as Sharh
	From F_Path
	Where Fpat01 is not null
		And   Fpat01= 1 And Fpat02= 1 And Fpat03= 1
		And (Fpat05 Like '%%')


END
