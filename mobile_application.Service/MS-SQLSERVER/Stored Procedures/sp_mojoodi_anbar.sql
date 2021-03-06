USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_mojoodi_anbar]    Script Date: 24/09/1400 12:21:26 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_mojoodi_anbar]
	@AnbarCode smallint ,
	@ObjectCode char(20)
AS
	Select CAST(1 as bigint) as id,CAST(CAST(SUM(Mojodi) as smallint) as varchar(20)) as [result]
	From (
    Select SUM(CASE WHEN Ahhv01<30 THEN Adhv05 ELSE -1*Adhv05 END) as Mojodi
    From Ahhvl with(nolock)
    Inner Join Adhvl On(Adhv01=Ahhv01 and Adhv02=Ahhv02 and Adhv03=Ahhv03)
    Where ((Ahhv01 not in (13,32,12,35)) Or (Adhv01=35 And ISNULL(Adhv31,0) NOT IN (13,14,21)) Or (Adhv01=12 And ISNULL(Adhv31,0) NOT IN (13,14,21,22)))
    And Ahhv02=@AnbarCode And Adhv04=@ObjectCode
    Union All
    Select SUM(CASE WHEN Fhfa01 in(1,31) THEN -Fdfa07 ELSE Fdfa07 END) as Mojodi
    From F_hfactor with(nolock)
    Inner Join F_dfactor b On(Fhfa00=Fdfa00 and Fhfa01=Fdfa01 and Fhfa02=Fdfa02)
    Where Fhfa01 in(1,31,4,34) And Fhfa23 IS NULL And Fdfa17 IS NULL
    And Fdfa04=@AnbarCode And Fdfa05=@ObjectCode
    Union All
    Select SUM(-Fdso09) as Mojodi
    From F_hSodor with(nolock)
    Inner Join F_dSodor On(Fhso00=Fdso00 and Fhso01=Fdso01 and Fhso02=Fdso02)
    Where Fhso01=1 And Fhso19=2
    And Fdso04=@AnbarCode And Fdso05=@ObjectCode
    Union All
    Select SUM(Fdbs11) as Mojodi
    From F_hSodor with(nolock)
    Inner Join F_dBarSodor On(Fhso00=Fdbs00 and Fhso01=Fdbs01 and Fhso02=Fdbs02)
    Where Fhso01=2 And Fdbs16 IS NULL
    And Fdbs06=@AnbarCode And Fdbs07=@ObjectCode
    Union All
    Select SUM(-Fdss06+ISNULL(Fdss21,0)) as Mojodi
    From F_hSefareshSeller a with(nolock) 
    Inner Join F_dSefareshSeller On(Fhss00=Fdss00 and Fhss01=Fdss01)
    Where Fdss04=@AnbarCode And Fdss05=@ObjectCode
    And NOT EXISTS(Select * From F_hSefareshSeller b Where b.Fhss00=a.Fhss00 And a.Fhss01=b.Fhss09)
) MTB


/* Adhv04=کد کالا
Ahhv02 = کد انبار
Ahhv02  كد انبار
Fdfa04  كد انبار
Fdso04  كد انبار
Fdbs06  كد انبار
Fdss04  كد انبار*/