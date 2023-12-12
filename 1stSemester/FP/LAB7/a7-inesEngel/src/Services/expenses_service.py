
from src.Domain.entities import Expense
import random
import os

class Services:
    def __init__(self,repo,implementation):
        self._repo=repo
        self._implementation=implementation
        self.start()

    def add_expense(self, day, amount, type):
        '''

        :param day: an integer number between 1 and 30
        :param amount: positive integer
        :param type: a string
        :return: adds the expense to the list containing all the expenses
        '''
        expense=Expense(int(day), int(amount), type)
        self._repo._save(expense)
        #verif

    def get_all(self):
        return self._repo.print_all()

    def change_by_val(self,value):
        return self._repo.change_by_val(value)

    def undo(self):
        self._repo.undo()

    def start(self):
        if self._implementation == "memory":
            self.generate()
        if self._implementation == "file":
            if os.path.getsize(r'C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.txt') < 1:
                self.generate()
        if self._implementation == "binary":
            if os.path.getsize(r"C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.bin") < 1:
                self.generate()

    def generate(self):
        for i in range(10):
                day = random.randint(1,30)
                amount = random.randint(1,10000)
                type_list = ["food","film","fuel","taxi","football","books","clothes"]
                type = random.choice(type_list)
                self.add_expense(day,amount,type)

