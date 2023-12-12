
class GenericRepo:
    def __init__(self):
        self._total=[]
        self._history=[]

    def _save(self, student):
        if student in self._total:
            raise ValueError("Student already exists")
        self._history.append(self._total[:])
        self._total.append(student)

    def print_all(self):
        return self._total

    def change_by_val(self, value):
        self._history.append(self._total[:])
        self._total=[student for student in self._total if student.get_group()<value or student.get_group()>value]
        return self._total

    def undo(self):
        self._total[:]=self._history[-1]
        self._history.pop()
        return self._total


