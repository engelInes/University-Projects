def calendar2(year, month, day, current_year, current_month, current_day):
    '''

    :param year: a natural number, representing the year the person was born
    :param month: a natural number, representing the month the person was born
    :param day: a natural number, representing the day the person was born
    :param current_year: a natural number, representing the current year
    :param current_month: a natural number, representing the current month
    :param current_day: a natural number, representing the current day
    :return: the function returns the age of a person in a number of days
    '''
    days = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31] #days[i] contains the number of days in the i month
    num_of_bisect_years = int((current_year-year - 1) / 4)
    sum = (current_year- year- num_of_bisect_years-1) * 365 + num_of_bisect_years * 366 #computing the number of days in leap years and the days in the remaining years
    for i in range(month):
        sum = sum + days[i]
    sum = sum + day
    return sum
