import copy
import random
import string

from matplotlib.testing.jpl_units import day


class Expense:
    def __init__(self, day: int, amount: int, type: str):
        self.__day = day
        self.__amount = amount
        self.__type = type

    # @property
    def get_day(self):
        return self.__day

    # @day.setter
    def set_day(self, value):
        self.__day = value

    # @property
    def get_amount(self):
        return self.__amount

    # @amount.setter
    def set_amount(self, value):
        self.__amount = value

    # @property
    def get_type(self):
        return self.__type

    # @type.setter
    def set_type(self, value):
        self.__type = value

    def __repr__(self):
        return f"{self.__day},{self.__amount},{self.__type}"

    def __str__(self):
        return f"{self.__day},{self.__amount},{self.__type}"


