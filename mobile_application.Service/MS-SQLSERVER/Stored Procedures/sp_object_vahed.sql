USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_object_vahed]    Script Date: 07/09/1400 08:43:54 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_object_vahed]
	@ObjectCode numeric(18,0)
AS
	Select Distinct CAST(Fkal01 as smallint) AS Code,Gvah02 as Sharh 
	from F_Kala inner join Gvahed on (Gvah01=Fkal05)
	where fkal01=@ObjectCode


