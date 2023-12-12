
class Student:
    def __init__(self, id:int, name:str, group:int):
        self.__id=id
        self.__name=name
        self.__group=group

    def get_id(self):
        return self.__id

    def set_id(self, value):
        self.__id=value

    def get_name(self):
        return self.__name

    def set_name(self, new_name):
        self.__name=new_name

    def get_group(self):
        return self.__group

    def set_group(self, value):
        self.__group=value

    def __repr__(self):
        return f"{self.__id},{self.__name},{self.__group}"

    def __str__(self):
        return f"{self.__id},{self.__name},{self.__group}"