declare @fixStartDate datetime
declare @fixEndDate datetime
declare @weekStartDate datetime
declare @weekEndDate datetime
declare @varStartDate datetime
declare @varEndDate datetime
declare @fixPrice decimal
declare @weekPrice decimal
declare @varPrice decimal
declare @fixAdultPrice decimal
declare @fixChildPrice decimal
declare @weekAduldPrice decimal
declare @weekChildPrice decimal
declare @varAdultPrice decimal
declare @varChildPrice decimal
declare @standardGuestCount int

set @fixStartDate = '06/01/2016'
set @fixEndDate = '06/30/2016'
set @weekStartDate = '06/09/2016'
set @weekEndDate = '06/13/2016'
set @varStartDate = '06/07/2016'
set @varEndDate = '06/11/2016'

set @fixPrice = 5000
set @fixAdultPrice = 1000
set @fixChildPrice = 800

set @weekPrice = 6000
set @weekAduldPrice = 1200
set @weekChildPrice = 1000

set @varPrice = 7000
set @varAdultPrice = 1500
set @varChildPrice = 1200

set @standardGuestCount = 4

declare @StartDate datetime
declare @EndDate datetime
declare @AdultCount int
declare @ChildCount int

set @StartDate = '06/01/2016'
set @EndDate = '06/15/2016'
set @AdultCount = 2
set @ChildCount = 1

declare @totalPrice decimal
declare @CurrentDate datetime
declare @totalDayStay int
declare @dayPrice decimal

set @totalDayStay = DATEDIFF(DAY, @EndDate, @StartDate)
Set @CurrentDate = @StartDate
Set @totalPrice = 0
While @EndDate >= @CurrentDate
Begin
	
	--print @CurrentDate

	if (@CurrentDate >= @varStartDate and @CurrentDate <= @varEndDate)
	begin
		set @dayPrice = @varPrice + @varAdultPrice * @AdultCount + @varChildPrice * @ChildCount
		set @totalPrice = @totalPrice + @dayPrice
		print 'Var Price for ' + convert(varchar, @CurrentDate, 5) + ' ' + convert(varchar, @dayPrice)
	end
	else if ((@CurrentDate >= @weekStartDate and @CurrentDate <= @weekEndDate) and (DATENAME(WEEKDAY, @CurrentDate) in ('Saturday', 'Sunday')))
	begin
		set @dayPrice = @weekPrice + @weekAduldPrice * @AdultCount + @weekChildPrice * @ChildCount
		set @totalPrice = @totalPrice + @dayPrice
		print 'Week Price for ' + convert(varchar, @CurrentDate, 5) + ' ' + convert(varchar, @dayPrice)
	end
	else
	begin
		set @dayPrice = @fixPrice + @fixAdultPrice * @AdultCount + @fixChildPrice * @ChildCount
		set @totalPrice = @totalPrice + @dayPrice
		print 'Standared Price for ' + convert(varchar, @CurrentDate, 5) + ' '  + convert(varchar, @dayPrice)
	end

	Set @CurrentDate = DATEADD(DAY, 1,@CurrentDate)

End

print 'Final Price' + ' ' +  convert(varchar, @totalPrice)
