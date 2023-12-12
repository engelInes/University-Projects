from src.Repository.expenses_repository import *
from src.Domain.entities import Expense


class FileExpensesRepository(GenericRepository):
    def __init__(self, file):
        super().__init__()
        self._expenses_files = file
        self._load_file()

    def add_expense(self, expense):
        '''

        :param expense: an object with day, amount and type as instances
        :return: adds the expense to the list of all expenses
        '''
        super().add_expense(expense)
        self._save(expense)

    def _load_file(self):
        try:
            with open(self._expenses_files) as f:
                for line in f:
                    line = line.strip()
                    v = line.split(",")
                    expense = Expense(int(v[0]), int(v[1]), v[2])
                    super()._save(expense)
        except FileNotFoundError as e:
            pass
        except ValueError as e:
            pass

    def _save(self, expense):
        '''
                The function appends the expense to the list of all expenses and writes it in the file
                :param expense: an expense object with day, amount and type as instances
                :return:
        '''
        super()._save(expense)
        with open(self._expenses_files, "a") as f:
            f.write(str(expense.get_day()) + "," + str(expense.get_amount()) + "," + str(expense.get_type()) + "\n")

    def change_by_val(self, value):
        new_expenses = super().change_by_val(value)
        with open(self._expenses_files, "w") as f:
            for expense in new_expenses:
                f.write(str(expense.get_day()) + "," + str(expense.get_amount()) + "," + str(expense.get_type()) + "\n")
            f.close()

    def undo(self):
        new_expenses = super().undo()
        with open(self._expenses_files, "w") as f:
            for expense in new_expenses:
                f.write(str(expense.get_day()) + "," + str(expense.get_amount()) + "," + str(expense.get_type()) + "\n")
            f.close()

