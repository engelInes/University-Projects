def calendar1(year, date):
    '''

    :param year: represents the year of the calendar as an integer number
    :param date: the parameter date represents the day number inside the given year
    :return: the function returns a calendar date as year, month and day
    '''
    days = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    month = 0
    if (year % 4 == 0): #checking if the year is a leap year
        days[1] = days[1] + 1
    while (days[month] < date):
        date = date - days[month]
        month = month + 1
    return year, month + 1, date
