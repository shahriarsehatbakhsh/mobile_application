USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_mojoodi_anbar_BargeDate]    Script Date: 24/09/1400 12:41:43 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_mojoodi_anbar_BargeDate]
	@TarikhBarge char(10),
	@AnbarCode smallint ,
	@ObjectCode char(20)
AS
	SET @TarikhBarge = REPLACE(@TarikhBarge,'D','/');
	Select CAST(1 as bigint) as id, CAST(CAST(SUM(CASE WHEN Ahhv01<30 THEN Adhv05 ELSE -1*Adhv05 END) as smallint) as varchar) as [result]
	From Ahhvl with(nolock)
		Inner Join Adhvl On(Adhv01=Ahhv01 and Adhv02=Ahhv02 and Adhv03=Ahhv03)
	Where 
		Ahhv01 not in (13,32)	And 
		Ahhv02 = @AnbarCode And 
		Adhv04 = @ObjectCode And 
		Ahhv04 <=@TarikhBarge

/* Ahhv04<=تاریخ برگه */
/* Adhv04=کد کالا */
/* Ahhv02 = کد انبار */

-- exec sp_mojoodi_date @TarikhBarge='1400/07/25',@AnbarCode=1,@ObjectCode='                   1'