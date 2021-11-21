

ALTER PROCEDURE sp_CustomerCart
	@BranchCode smallint,
	@CustomerCode int,
	@UserCode int,
	@BalancePrice numeric(18,0) OUTPUT,
	@SumDebtorPrice numeric(18,0) OUTPUT,
	@SumCreditorPrice numeric(18,0) OUTPUT
AS

Select * Into #CartTB
From(
Select Fhms02 as CustomerCode, Fhms03 as CustomerName, NULL as SheetNo, NULL as SheetDate
	, Fhms25 as DebtorPrice, Fhms26 as CreditorPrice, NULL as SellerCode, NULL as SellerName, Fhms00 as BranchCode, Fhbr02 as BranchName
	,'مانده اول دوره' as SheetType
From F_hMoshtari
Inner Join F_hBranch On(Fhbr01=Fhms00)
Where Fhms01=2 And Fhms95=1
And Fhms00=@BranchCode
And Fhms02=@CustomerCode
And exists(Select Fdbu01 From F_dBranchUser
           Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))

Union All
Select Fhfa05 as CustomerCode, CustTB.Fhms03 as CustomerName, Fhfa02 as SheetNo, Fhfa03 as SheetDate
	,case When (Sum(isnull(Fdfa08,0))+Sum(isnull(Fdfa21,0))-Sum(isnull(Fdfa22,0))+Sum(isnull(Fdfa23,0))-Sum(isnull(Fdfa24,0)))>0 then Sum(isnull(Fdfa08,0))+Sum(isnull(Fdfa21,0))-Sum(isnull(Fdfa22,0))+Sum(isnull(Fdfa23,0))-Sum(isnull(Fdfa24,0)) end as DebtorPrice
	,case When (Sum(isnull(Fdfa08,0))+Sum(isnull(Fdfa21,0))-Sum(isnull(Fdfa22,0))+Sum(isnull(Fdfa23,0))-Sum(isnull(Fdfa24,0)))<0 then -Sum(isnull(Fdfa08,0))-Sum(isnull(Fdfa21,0))+Sum(isnull(Fdfa22,0))-Sum(isnull(Fdfa23,0))+Sum(isnull(Fdfa24,0)) end as CreditorPrice
	,Fhfa20 as SellerCode, SellTB.Fhms03 as SellerName, Fhfa00 as BranchCode, Fhbr02 as BranchName
	,'صورتحساب فروش' as SheetType
From F_hFactor
Inner Join F_dFactor on(Fhfa00=Fdfa00 and Fhfa01=Fdfa01 and Fhfa02=Fdfa02)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Fhfa00 and CustTB.Fhms01=Fhfa04 and CustTB.Fhms02=Fhfa05)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Fhfa00 and SellTB.Fhms01=Fhfa19 and SellTB.Fhms02=Fhfa20)
Inner Join F_hBranch on(Fhbr01=Fhfa00)
Where Fhfa01=31 and Fhfa95=1
And Fhfa00=@BranchCode
And Fhfa05=@CustomerCode
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
Group By Fhfa05,CustTB.Fhms03,Fhfa02,Fhfa03,Fhfa20,SellTB.Fhms03,Fhfa00,Fhbr02

Union All
Select Fhfa05 as CustomerCode, CustTB.Fhms03 as CustomerName, Fhfa02 as SheetNo, Fhfa03 as SheetDate
	,case When (Sum(isnull(Fdfa08,0))+Sum(isnull(Fdfa21,0))-Sum(isnull(Fdfa22,0))+Sum(isnull(Fdfa23,0))-Sum(isnull(Fdfa24,0)))<0 then -Sum(isnull(Fdfa08,0))-Sum(isnull(Fdfa21,0))+Sum(isnull(Fdfa22,0))-Sum(isnull(Fdfa23,0))+Sum(isnull(Fdfa24,0)) end as DebtorPrice
	,case When (Sum(isnull(Fdfa08,0))+Sum(isnull(Fdfa21,0))-Sum(isnull(Fdfa22,0))+Sum(isnull(Fdfa23,0))-Sum(isnull(Fdfa24,0)))>0 then Sum(isnull(Fdfa08,0))+Sum(isnull(Fdfa21,0))-Sum(isnull(Fdfa22,0))+Sum(isnull(Fdfa23,0))-Sum(isnull(Fdfa24,0)) end as CreditorPrice
	,Fhfa20 as SellerCode, SellTB.Fhms03 as SellerName, Fhfa00 as BranchCode, Fhbr02 as BranchName
	,'برگشت از فروش' as SheetType
From F_hFactor
Inner Join F_dFactor on(Fhfa00=Fdfa00 and Fhfa01=Fdfa01 and Fhfa02=Fdfa02)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Fhfa00 and CustTB.Fhms01=Fhfa04 and CustTB.Fhms02=Fhfa05)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Fhfa00 and SellTB.Fhms01=Fhfa19 and SellTB.Fhms02=Fhfa20)
Inner Join F_hBranch on(Fhbr01=Fhfa00)
Where Fhfa01=34 and Fhfa95=1
And Fhfa00=@BranchCode
And Fhfa05=@CustomerCode
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
Group By Fhfa05,CustTB.Fhms03,Fhfa02,Fhfa03,Fhfa20,SellTB.Fhms03,Fhfa00,Fhbr02

Union All
Select Fhfa05 as CustomerCode, CustTB.Fhms03 as CustomerName, Fhfa02 as SheetNo, Fhfa03 as SheetDate
	,case when isnull(Sum(isnull(case when Fmot03=0 then Fdfa08 end,0)-isnull(case when Fmot03=1 then Fdfa08 end,0)),0) >=0 then
	 		   isnull(Sum(isnull(case when Fmot03=0 then Fdfa08 end,0)-isnull(case when Fmot03=1 then Fdfa08 end,0)),0) end as DebtorPrice
	,case when isnull(Sum(isnull(case when Fmot03=0 then Fdfa08 end,0)-isnull(case when Fmot03=1 then Fdfa08 end,0)),0) < 0 then
			   isnull(Sum(isnull(case when Fmot03=1 then Fdfa08 end,0)-isnull(case when Fmot03=0 then Fdfa08 end,0)),0) end as CreditorPrice
	,Fhfa20 as SellerCode, SellTB.Fhms03 as SellerName, Fhfa00 as BranchCode, Fhbr02 as BranchName
	,'متمم فروش' as SheetType
From F_hFactor
Inner Join F_dFactor on(Fhfa00=Fdfa00 and Fhfa01=Fdfa01 and Fhfa02=Fdfa02)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Fhfa00 and CustTB.Fhms01=Fhfa04 and CustTB.Fhms02=Fhfa05)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Fhfa00 and SellTB.Fhms01=Fhfa19 and SellTB.Fhms02=Fhfa20)
Inner Join F_hBranch on(Fhbr01=Fhfa00)
Inner Join F_Motamem on(Fmot01=Fdfa12)
Where Fhfa01=36 and Fhfa95=1
And Fhfa00=@BranchCode
And Fhfa05=@CustomerCode
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
Group By Fhfa05,CustTB.Fhms03,Fhfa02,Fhfa03,Fhfa20,SellTB.Fhms03,Fhfa00,Fhbr02

Union All
Select Mhel17 as CustomerCode, CustTB.Fhms03 as CustomerName, Mhel01 as SheetNo, Mhel02 as SheetDate
	,Sum(case when Mhel03=0 then isnull(Mdel04,0) end) as DebtorPrice
	,Sum(case when Mhel03=1 then isnull(Mdel04,0) end) as CreditorPrice
	,Mhel19 as SellerCode, SellTB.Fhms03 as SellerName, Mhel20 as BranchCode, Fhbr02 as BranchName
	,case when Mhel03=0 then 'اعلامیه بدهکار' else 'اعلامیه بستانکار' end as SheetType
From MhElamieh
Inner Join MdElamieh on(Mhel01=Mdel01)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Mhel20 and CustTB.Fhms01=Mhel16 and CustTB.Fhms02=Mhel17)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Mhel20 and SellTB.Fhms01=Mhel18 and SellTB.Fhms02=Mhel19)
Inner Join F_hBranch On(Fhbr01=Mhel20)
Where Mhel14=1 And Mhel16=2 And Mhel95=1
And Mhel20=@BranchCode
And Mhel17=@CustomerCode
And exists(Select Fdbu01 From F_dBranchUser
           Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
Group by Mhel17,CustTB.Fhms03,Mhel01,Mhel02,Mhel19,SellTB.Fhms03,Mhel20,Fhbr02,Mhel03

Union All
Select Mdel14 as CustomerCode, CustTB.Fhms03 as CustomerName, Mhel01 as SheetNo, Mhel02 as SheetDate
	,Sum(case when Mhel03=1 then isnull(Mdel04,0) end) as DebtorPrice
	,Sum(case when Mhel03=0 then isnull(Mdel04,0) end) as CreditorPrice
	,Mdel16 as SellerCode, SellTB.Fhms03 as SellerName, Mhel20 as BranchCode, Fhbr02 as BranchName
	,case when Mhel03=1 then 'اعلامیه بدهکار' else 'اعلامیه بستانکار' end as SheetType
From MhElamieh
Inner Join MdElamieh on(Mhel01=Mdel01)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Mdel12 and CustTB.Fhms01=Mdel13 and CustTB.Fhms02=Mdel14)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Mdel12 and SellTB.Fhms01=Mdel15 and SellTB.Fhms02=Mdel16)
Inner Join F_hBranch On(Fhbr01=Mdel12)
Where Mhel14=1 And Mdel13=2 And Mhel95=1
And Mdel12=@BranchCode
And Mdel14=@CustomerCode
And exists(Select Fdbu01 From F_dBranchUser
           Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
Group by Mdel14,CustTB.Fhms03,Mhel01,Mhel02,Mdel16,SellTB.Fhms03,Mhel20,Fhbr02,Mhel03

Union All
Select case isnull(Fdrv01,0) when 0 then Fddv18 else Fdrv05 end as CustomerCode, CustTB.Fhms03 as CustomerName, Fhdv01 as SheetNo, Fhdv02 as SheetDate
	,0.0 as DebtorPrice
	,case isnull(Fdrv01,0) when 0 then Fddv07 else Fdrv09 end as CreditorPrice
	,case isnull(Fdrv01,0) when 0 then Fddv20 else Fdrv07 end as SellerCode, SellTB.Fhms03 as SellerName, Fhdv00 as BranchCode, Fhbr02 as BranchName
	,'دریافت وجه' as SheetType
From F_hDaryaftVajh
Inner Join F_dDaryaftVajh on(Fhdv00=Fddv00 And Fhdv01=Fddv01)
Left Join F_dRizDaryaftVajh on(Fdrv00=Fddv00 And Fdrv01=Fddv01 And Fdrv02=Fddv02)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Fhdv00 and CustTB.Fhms01=2 and CustTB.Fhms02=case isnull(Fdrv01,0) when 0 then Fddv18 else Fdrv05 end)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Fhdv00 and SellTB.Fhms01=1 and SellTB.Fhms02=case isnull(Fdrv01,0) when 0 then Fddv20 else Fdrv07 end)
Inner Join F_hBranch On(Fhbr01=Fhdv00)
Where Fhdv95=1 and Fddv03=1
And Fhdv00=@BranchCode
And ((isnull(Fdrv01,0)=0 And Fddv18=@CustomerCode) Or (isnull(Fdrv01,0)<>0 And Fdrv05=@CustomerCode))
And exists(Select Fdbu01 From F_dBranchUser
           Left Outer Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))

Union All
Select case isnull(Fdrv01,0) when 0 then Fddv18 else Fdrv05 end as CustomerCode, CustTB.Fhms03 as CustomerName, Fhdv01 as SheetNo, Fhdv02 as SheetDate
	,0.0 as DebtorPrice
	,case isnull(Fdrv01,0) when 0 then Fddv07 else Fdrv09 end as CreditorPrice
	,case isnull(Fdrv01,0) when 0 then Fddv20 else Fdrv07 end as SellerCode, SellTB.Fhms03 as SellerName, Fhdv00 as BranchCode, Fhbr02 as BranchName
	,'دریافت وجه' as SheetType
From F_hDaryaftVajh
Inner Join F_dDaryaftVajh on(Fhdv00=Fddv00 And Fhdv01=Fddv01)
Left Join F_dRizDaryaftVajh on(Fdrv00=Fddv00 And Fdrv01=Fddv01 And Fdrv02=Fddv02)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Fhdv00 and CustTB.Fhms01=2 and CustTB.Fhms02=case isnull(Fdrv01,0) when 0 then Fddv18 else Fdrv05 end)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Fhdv00 and SellTB.Fhms01=1 and SellTB.Fhms02=case isnull(Fdrv01,0) when 0 then Fddv20 else Fdrv07 end)
Inner Join F_hBranch On(Fhbr01=Fhdv00)
Where Fhdv95=1 and Fddv03=2
And Fhdv00=@BranchCode
And ((isnull(Fdrv01,0)=0 And Fddv18=@CustomerCode) Or (isnull(Fdrv01,0)<>0 And Fdrv05=@CustomerCode))
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))


Union All
Select case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end as CustomerCode, CustTB.Fhms03 as CustomerName, Bhba02 as SheetNo, Bhba03 as SheetDate
	,case isnull(Bdrb01,0) when 0 then Sum(Bdba06) else Sum(Bdrb09) end as DebtorPrice
	,0.0 as CreditorPrice
	,case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end as SellerCode, SellTB.Fhms03 as SellerName, Bdba34 as BranchCode, Fhbr02 as BranchName
	,'واخواست چک' as SheetType
From BhBarge b
Inner Join BdBarge a on(Bhba01=Bdba01 and Bhba02=Bdba02)
Left Join BdrBarge on(Bdrb01=Bdba01 and Bdrb02=Bdba02 and Bdrb03=Bdba15)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Bdba34 and CustTB.Fhms01=2 and CustTB.Fhms02=case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Bdba34 and SellTB.Fhms01=1 and SellTB.Fhms02=case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end)
Inner Join F_hBranch On(Fhbr01=Bdba34)
Where Bdba01 is not null And a.Bdba01=22 And a.Bdba11=1
And Bdba34=@BranchCode
And ((isnull(Bdrb01,0)=0 And Bdba36=@CustomerCode) Or (isnull(Bdrb01,0)<>0 And Bdrb19=@CustomerCode))
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
Group By case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end,CustTB.Fhms03,Bhba02,Bhba03 
	,case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end,SellTB.Fhms03,Bdba34,Fhbr02,isnull(Bdrb01,0)

Union All
Select case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end as CustomerCode, CustTB.Fhms03 as CustomerName, Bhba02 as SheetNo, Bhba03 as SheetDate
	,case isnull(Bdrb01,0) when 0 then Sum(Bdba06) else Sum(Bdrb09) end as DebtorPrice
	,0.0 as CreditorPrice
	,case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end as SellerCode, SellTB.Fhms03 as SellerName, Bdba34 as BranchCode, Fhbr02 as BranchName
	,'استرداد چک' as SheetType
From BhBarge b
Inner Join BdBarge a on(Bhba01=Bdba01 and Bhba02=Bdba02)
Left Join BdrBarge on(Bdrb01=Bdba01 and Bdrb02=Bdba02 and Bdrb03=Bdba15)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Bdba34 and CustTB.Fhms01=2 and CustTB.Fhms02=case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Bdba34 and SellTB.Fhms01=1 and SellTB.Fhms02=case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end)
Inner Join F_hBranch On(Fhbr01=Bdba34)
Where Bdba01 is not null And a.Bdba01=22 And a.Bdba11=3
And Bdba34=@BranchCode
And ((isnull(Bdrb01,0)=0 And Bdba36=@CustomerCode) Or (isnull(Bdrb01,0)<>0 And Bdrb19=@CustomerCode))
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
And not exists(Select c.Bdba01 From BdBarge c Where c.Bdba01 in(21,22) And c.Bdba11=1 And c.Bdba03=a.Bdba03 And c.Bdba04=a.Bdba04)
Group By case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end,CustTB.Fhms03,Bhba02,Bhba03
	,case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end,SellTB.Fhms03,Bdba34,Fhbr02,isnull(Bdrb01,0)

Union All
Select case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end as CustomerCode, CustTB.Fhms03 as CustomerName, Bhba02 as SheetNo, Bhba03 as SheetDate
	,0.0 as DebtorPrice
	,case isnull(Bdrb01,0) when 0 then Sum(Bdba06) else Sum(Bdrb09) end as CreditorPrice
	,case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end as SellerCode, SellTB.Fhms03 as SellerName, Bdba34 as BranchCode, Fhbr02 as BranchName
	,'وصول چک' as SheetType
From BhBarge b
Inner Join BdBarge a on(Bhba01=Bdba01 and Bhba02=Bdba02)
Left Join BdrBarge on(Bdrb01=Bdba01 and Bdrb02=Bdba02 and Bdrb03=Bdba15)
Inner Join F_hMoshtari CustTB on(CustTB.Fhms00=Bdba34 and CustTB.Fhms01=2 and CustTB.Fhms02=case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end)
Inner Join F_hMoshtari SellTB on(SellTB.Fhms00=Bdba34 and SellTB.Fhms01=1 and SellTB.Fhms02=case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end)
Inner Join F_hBranch On(Fhbr01=Bdba34)
Where Bdba01 is not null And a.Bdba01=22 And isnull(a.Bdba11,0)=0 And a.Bdba10=1
And Bdba34=@BranchCode
And ((isnull(Bdrb01,0)=0 And Bdba36=@CustomerCode) Or (isnull(Bdrb01,0)<>0 And Bdrb19=@CustomerCode))
And exists(Select Fdbu01 From F_dBranchUser
           Left Join F_dtBranchUser on(Fdtu01=Fdbu01 and Fdtu02=Fdbu02)
           Where Fdbu01=Fhbr01 And (Fdbu02=@UserCode Or Fdtu03=@UserCode))
And exists(Select c.Bdba01 From BdBarge c Where c.Bdba01=22 And (c.Bdba11=1 or c.Bdba11=3) And c.Bdba03=a.Bdba03 And c.Bdba04=a.Bdba04)
Group By case isnull(Bdrb01,0) when 0 then Bdba36 else Bdrb19 end,CustTB.Fhms03,Bhba02,Bhba03
	,case isnull(Bdrb01,0) when 0 then Bdba38 else Bdrb21 end,SellTB.Fhms03,Bdba34,Fhbr02,isnull(Bdrb01,0)
) as TB

Select @BalancePrice = ISNULL(SUM(DebtorPrice),0) - ISNULL(SUM(CreditorPrice),0)
	,@SumDebtorPrice = SUM(DebtorPrice)
	,@SumCreditorPrice = SUM(CreditorPrice)
From #CartTB

Select #CartTB.*
From #CartTB
Order By CustomerCode,BranchCode,SheetDate,SheetType,SheetNo