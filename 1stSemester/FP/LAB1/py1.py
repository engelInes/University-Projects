import math

def is_prime(n):
    '''

    :param n: this function takes as parameter a natural number n and checks whether it is prime
    :return: the function returns True if the number is prime, False otherwise
    '''
    if n < 2:
        return False
    if n == 2:
        return True
    if n % 2 == 0:
        return False
    for d in range(3, int(math.sqrt(n)) + 1, 2):
        if n % d == 0:
            return False
    return True


def greater_than_n(n):
    '''

    :param n: the function has as a parameter a natural number n
    :return: it returns the first value greater than n that is a prime number
    '''
    k = n
    found = False
    while (found == False):
        k = k + 1
        if is_prime(k):
            found = True
    return k