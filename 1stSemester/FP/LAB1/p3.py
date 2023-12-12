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
    num_of_bisect_years = int((current_year - year - 1) / 4)
    sum = (current_year- year- num_of_bisect_years-1) * 365 + num_of_bisect_years * 366 #computing the number of days in leap years and the days in the remaining years
    for i in range(month-1):
        sum = sum + days[i]
    sum = sum + current_day
    return sum


def menu():
    birth_year = int(input("Choose a year: "))
    birth_month= int(input("Choose a month: "))
    birth_day = int(input("Choose a day: "))
    today_year = int(input("Choose today's year: "))
    today_month = int(input("Choose today's month: "))
    today_day = int(input("Choose today's day: "))
    res = calendar2(birth_year, birth_month, birth_day, today_year, today_month, today_day)
    print("The person has: ", res, "days as an age")

menu()