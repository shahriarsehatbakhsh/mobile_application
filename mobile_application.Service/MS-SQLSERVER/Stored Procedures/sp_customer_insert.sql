USE [MaliDB00_11]
GO
/****** Object:  StoredProcedure [dbo].[sp_customer_insert]    Script Date: 23/09/1400 08:54:06 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_customer_insert]
	@CodeShobe INT,
	@sp_GetLatestAvailableCustomerCode_code INT,
	@Sharh NVARCHAR(500),
	@sp_GetLatestAvailableCustomerCode_serial INT,
	@CodeKarbareVaredShodeBeSystem INT,
	@TairkheRooz CHAR(12),
	@CodePishe INT,
	@CodeOstan INT,
	@CodeShahr INT,
	@CodeMantaghe INT,
	@CodeMasir INT,
	@Tel NVARCHAR(20),
	@Mobile NVARCHAR(20),
	@Address NVARCHAR(200)
AS

BEGIN
	SET NOCOUNT ON;

	set @TairkheRooz = REPLACE(@TairkheRooz,'D','/');

	INSERT INTO F_hMoshtari (Fhms00,Fhms01,Fhms02,Fhms03,Fhms04,Fhms27,Fhms28,fhms29,Fhms38,Fhms39,Fhms53,Fhms54,Fhms95,Fhms98,Fhms99)
	VALUES (@CodeShobe,2,@sp_GetLatestAvailableCustomerCode_code,@Sharh,1,1,1,@sp_GetLatestAvailableCustomerCode_serial,0,0,0,0,1,@CodeKarbareVaredShodeBeSystem,@TairkheRooz)

------------------------
	INSERT INTO F_dMoshtariJob (Fdmj00,Fdmj01,Fdmj02,Fdmj03,Fdmj04,Fdmj05,Fdmj06,Fdmj09,Fdmj10,Fdmj11,Fdmj12,Fdmj13,Fdmj14,Fdmj15,Fdmj17,Fdmj95,Fdmj98,Fdmj99)
	VALUES (@CodeShobe,2,@sp_GetLatestAvailableCustomerCode_code,1,@TairkheRooz,@TairkheRooz,@CodePishe,@CodeOstan,@CodeShahr,@CodeMantaghe,@CodeMasir,@Tel,@Mobile,@Address,1,1,@CodeKarbareVaredShodeBeSystem,@TairkheRooz)

END
