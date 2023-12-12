
from Domain.students import Student
import os
import random

class Service:
    def __init__(self, repo, implementation):
        self._repo=repo
        self._implementation=implementation
        self.start()

    def add_student(self, id, name, group):
        student=Student(int(id), name, int(group))
        self._repo._save(student)

    def display_all(self):
        return self._repo.print_all()

    def filter_by_group(self):
        return self._repo.change_by_val(value)

    def undo(self):
        self._repo.undo

    def start(self):
        if self._implementation=="memory":
            self.generate()
        if self._implementation=="file":
            if os.path.getsize(r"locatie fisier")<1:
                self.generate()
        if self._implementation=="binary":
            if os.path.getsize(r"locatie fisier")<1:
                self.generate()


    def generate(self):
        for i in range(10):
            id= random.randint(1,1000000)
            list_of_names=["Engel Ines", "Andreican Rares", "Pop Vasi", "Nas frumos"]
            name= random.choice(list_of_names)
            group= random.randint(1,1000)
            self.add_student(id,name,group)
