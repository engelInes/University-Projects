from Domain.students import Student
from Repo.memo_repo import *


class FileStudentRepo(GenericRepo):
    def __init__(self, file):
        super().__init__()
        self._students_files = file
        self._load_file()

    def add_student(self, student):
        super(FileStudentRepo, self).add_student(student)
        self._save(student)

    def _load_file(self):
        try:
            with open(self._students_files) as f:
                for line in f:
                    line = line.strip()
                    v = line.split(",")
                    student = Student(int(v[0]), v[1], int(v[2]))
                    super._save(student)
        except FileNotFoundError as e:
            print("File has not been found")
        except ValueError as e:
            print("Value error")

    def _save(self, student):
        super()._save(student)
        with open(self._students_files, "a") as f:
            f.write(str(student.get_id()) + "," + str(student.get_name()) + "," + str(student.get_group()) + "\n")

    def change_by_val(self, value):
        new_students = super().change_by_val(value)
        with open(self._students_files, "w") as f:
            for student in new_students:
                f.write(str(student.get_id()) + "," + str(student.get_name()) + "," + str(student.get_group()) + "\n")
            f.close()

    def undo(self):
        new_students = super().undo()
        with open(self._students_files, "w") as f:
            for student in new_students:
                f.write(str(student.get_id()) + "," + str(student.get_name()) + "," + str(student.get_group()) + "\n")
            f.close()
