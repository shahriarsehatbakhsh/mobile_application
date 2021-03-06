USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_object_nerkh]    Script Date: 07/09/1400 08:42:36 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_object_nerkh]
	@BranchCode smallint,
	@MosavabeCode numeric(18,0) ,
	@ObjectCode numeric(18,0)
AS
	Select CAST(Fdmo01 as smallint) as Code,CAST(Fdmo04 as nvarchar(20)) as Sharh
	From F_hMosavab 
	Left Outer Join F_dMosavab on (Fdmo01=Fhmo01)
	Where Fhmo01=@MosavabeCode
	And   Fdmo02=@BranchCode
	And   Fdmo03=@ObjectCode


/* Fdmo01= شماره مصوبه */
/* Fdmo02= کد انبار */
/* Fdmo03= کد کالا */