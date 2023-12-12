from src.Domain.entities import Expense
from src.Repository.expenses_repository import GenericRepository
import pickle
import os

class BinaryRepository(GenericRepository):
    def __init__(self,file):
        super().__init__()
        self._file_name = file
        self._load_file()

    def _load_file(self):
        with open(self._file_name,"rb") as f:
            if os.path.getsize(self._file_name) > 0:
                expenses_list = pickle.load(f)
                for expense in expenses_list:
                    super()._save(expense)
            f.close()

    def _save(self,expense):
        '''
            The function appends the expense to the list of all expenses and writes it in the file
            :param expense: an expense object with day, amount and type as instances
            :return:
        '''
        super()._save(expense)
        with open(self._file_name,"wb") as f:
            pickle.dump(self.print_all(), f)
            f.close()

    def change_by_val(self, value):
        new_expenses = super().change_by_val(value)
        with open(self._file_name, "wb") as f:
            pickle.dump(new_expenses,f)
        f.close()

    def undo(self):
        new_expenses = super().undo()
        with open(self._file_name, "wb") as f:
            pickle.dump(new_expenses,f)
        f.close()
