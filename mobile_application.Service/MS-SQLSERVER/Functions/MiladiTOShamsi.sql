
GO
/****** Object:  UserDefinedFunction [dbo].[MiladiTOShamsi]    Script Date: 16/09/1400 08:09:10 ق.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE FUNCTION [dbo].[MiladiTOShamsi] (@MDate  DateTime)
 RETURNS Varchar(10)
 AS
 BEGIN
   declare @Jalali_y int,@Jalali_m int,@Jalali_d int,@Georgian_y int,@Georgian_m int,@Georgian_d int
   set @Georgian_y = datepart(year,@MDate)
   set @Georgian_m = datepart(month,@MDate)
   set @Georgian_d = datepart(day,@MDate)
   declare @position int
   declare @Georgian_days_in_month char(100),
   	@Jalali_days_in_month char(100)
   declare
   	@gy int, @gm  int, @gd  int,
   	@jy  int, @jm  int, @jd  int,
   	@Georgian_day_no int,
   	@Jalali_day_no int,
   	@Jalali_np int,
   	@i int
   set @Georgian_days_in_month = ',31,28,31,30,31,30,31,31,30,31,30,31'
   set @Jalali_days_in_month = ',31,31,31,31,31,31,30,30,30,30,30,29'
   set @gy = @Georgian_y-1600
   set @gm = @Georgian_m-1
   set @gd= @Georgian_d-1
   set @Georgian_day_no = 365*@gy+(@gy+3) / 4-(@gy+99) / 100+(@gy+399) / 400
   set @position = 0
   set @i = 0
   while (@i<=@gm-1)
   begin
     set @Georgian_day_no = @Georgian_day_no + cast(substring(@Georgian_days_in_month, CHARINDEX ( ',', @Georgian_days_in_month, @position)+1 , 2) as int)
     set @position = @position + 3
     set @i = @i + 1
   end
   if ((@gm>1) and ((((@gy % 4)=0) and  ((@gy % 100)!=0)) or ((@gy % 400)=0)) )
     set @Georgian_day_no = @Georgian_day_no+1
   set @Georgian_day_no = @Georgian_day_no + @gd
   set @Jalali_day_no = @Georgian_day_no-79
   set @Jalali_np = @Jalali_day_no / 12053
   set @Jalali_day_no = @Jalali_day_no % 12053
   set @jy = 979+33*@Jalali_np+4*(@Jalali_day_no / 1461)
   set @Jalali_day_no = @Jalali_day_no % 1461
   if (@Jalali_day_no >= 366)
   begin
     set @jy = @jy+ (@Jalali_day_no-1) / 365
     set @Jalali_day_no = (@Jalali_day_no-1) % 365
   end
   set @position = 0
   set @i=0
   while ((@i<11) and (@Jalali_day_no >=
   cast(substring(@Jalali_days_in_month, CHARINDEX ( ',', @Jalali_days_in_month, @position)+1 , 2) as int)
   ))
   begin
   	set @Jalali_day_no = @Jalali_day_no - cast(substring(@Jalali_days_in_month, CHARINDEX ( ',', @Jalali_days_in_month, @position)+1 , 2) as int)
   	set @position = @position + 3
   	set @i = @i + 1;
   end
   set @jm = @i+1
   set @jd = @Jalali_day_no+1
   set @Jalali_y = @jy
   set @Jalali_m = @jm
   set @Jalali_d = @jd
   --if(@Jalali_y>1400)
   	--set @Jalali_y=@Jalali_y-1300
   	--set @Jalali_y=@Jalali_y
   RETURN str(@Jalali_y,4) + '/' + replace(str(@Jalali_m,2),' ','0') + '/' + replace(str(@Jalali_d,2),' ','0')
 END
