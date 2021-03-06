USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_pishe_list]    Script Date: 17/08/1400 01:46:17 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_mantaghe_list]
	
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Floc03 as Code,Floc04 as Sharh
	From F_Location
		Left Outer Join F_dBranchLoc on(Fdbl02=Floc01 and Fdbl03=Floc02 and (Fdbl04=Floc03 or Fdbl04=Null))
		Left Outer Join F_dBranchUser on(Fdbu01=Fdbl01)
	Where Floc01 is not null 
		And   Floc01= 1 And Floc02= 1
		And   Fdbu02= 2
		And (Floc04 Like '%%')


END
