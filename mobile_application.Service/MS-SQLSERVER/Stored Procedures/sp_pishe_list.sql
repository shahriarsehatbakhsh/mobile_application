CREATE PROCEDURE [dbo].[sp_pishe_list]
	
AS
BEGIN
	SET NOCOUNT ON;

	Select Distinct Fjob01 as Code,Fjob02 as Sharh
	From F_Job
		Left Outer Join F_dGroupCenter on (Fdgc02=Fjob01)
		Left Outer Join F_dGroupCenterBranch on (Fdgb01=Fdgc01)
		Left Outer Join F_dGroupCenterUser on (Fdgu01=Fdgc01)
	Where Fjob01 is not null
		And   (Fdgb01 is null Or Fdgb02=2)
		And   (Fdgu01 is null Or Fdgu02=2)
		and (Fjob02 Like '%%')

END
