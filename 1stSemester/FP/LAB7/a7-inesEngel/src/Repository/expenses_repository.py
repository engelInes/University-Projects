import copy
import random

from src.Domain.entities import Expense

class GenericRepository:
    def __init__(self):
        self._total=[]
        self._history=[]

    def _save(self,expense):
        '''
        The function appends the expense to the list of all expenses
        :param expense: an expense object with day, amount and type as instances
        :return:
        '''
        if expense in self._total:
            raise ValueError("Expense already exists")
        self._history.append(self._total[:])
        self._total.append(expense)

    def print_all(self):
        return self._total

    def change_by_val(self, value):
        self._history.append(self._total[:])
        self._total = [expense for expense in self._total if expense.get_amount() > value]
        return self._total

    def undo(self):
        self._total[:]=self._history[-1]
        self._history.pop()
        return self._total


