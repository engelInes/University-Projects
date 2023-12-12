from Domain.students import Student
from Repo.memo_repo import *
import os
import pickle

class BinaryRepo(GenericRepo):
    def __init__(self, file):
        super().__init__()
        self._file_name=file
        self._load_file()

    def _load_file(self):
        with open(self._file_name, "rb") as f:
            if os.path.getsize(self._file_name)>0:
                students_list=pickle.load(f)
                for student in students_list:
                    super()._save(student)
            f.close()

    def _save(self, student):
        super()._save(student)
        with open(self._file_name, "wb") as f:
            pickle.dump(self.print_all(),f) #the pickeled repr of self.print_all
            f.close()

    def change_by_val(self, value):
        new_students=super().change_by_val(value)
        with open(self._file_name, "wb") as f:
            pickle.dump(new_students,f)
        f.close()

    def undo(self):
        new_students=super().undo()
        with open(self._file_name, "wb") as f:
            pickle.dump(new_students,f)
        f.close()
