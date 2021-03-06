USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_F_dSefareshSeller]    Script Date: 13/09/1400 12:52:33 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_insert_F_dSefareshSeller]
	-- Add the parameters for the stored procedure here
		    @CodeShobe smallint,  --Fdss00
			@ShomareBarge_Header int,  --Fdss01
			@ShomareRadif int,  --Fdss03
			@CodeAnbaar smallint,  --Fdss04
			@CodeKala char(20),  --Fdss05
			@Meghdar numeric(18,0),  --Fdss06
			@Nerkh float,  --Fdss07
			@Mablagh numeric(18,0),  --Fdss08
			@NoeBaste smallint,  --Fdss16
			@TedadBaste numeric(18,0),  --Fdss17
			@TedadDarHarBaste numeric(18,0),  --Fdss18,Fdss19=0
			@CodeKarbar smallint,  --Fdss98
			@TarikhRooz char(10),  --Fdss99,Fdss23=0.000
			@BranchCode smallint,
			@MoshtariCode char(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	Select top 1 @TedadDarHarBaste=Fkpa04 
	From F_KalaPackage 
	Where Fkpa02=@BranchCode And Fkpa03=@MoshtariCode And isnull(Fkpa06,0)=1
    -- Insert statements for procedure here
	BEGIN TRY
		INSERT INTO  F_dSefareshSeller (Fdss00,Fdss01,Fdss03,Fdss04,Fdss05,Fdss06,Fdss07,Fdss08,Fdss16,Fdss17,Fdss18,Fdss19,Fdss98,Fdss99,Fdss23)
		VALUES (@CodeShobe,
				@ShomareBarge_Header,
				@ShomareRadif,
				@CodeAnbaar,
				@CodeKala,
				@Meghdar,
				@Nerkh,
				@Mablagh,
				@NoeBaste,
				@TedadBaste,
				@TedadDarHarBaste,0,
				@CodeKarbar,
				@TarikhRooz,0.000)
		SELECT CAST(1 as bigint)AS [id],'DONE' as [result];
	END TRY
	BEGIN CATCH
		SELECT CAST(ERROR_NUMBER() as bigint) AS [id], ERROR_MESSAGE() AS [result];
	END CATCH
END
