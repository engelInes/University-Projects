#from dataclasses import dataclass

#@dataclass(frozen=True) #order=True)# frozen le face immutable
#asdict (ti le afiseaza ca un dictionar)
#order-putem itera printre ele de ex daca avem o lista
#@dataclass
class Client:
    def __init__(self,client_id:int,name:str):
        self.__client_id=client_id
        self.__name=name

    @property
    def client_id(self):
        return self.__client_id

    @property
    def name(self):
        return self.__name

    @client_id.setter
    def client_id(self,value):
        self.__client_id=value

    @name.setter
    def name(self,name):
        self.__name=name

    def __str__(self):
        return f"{self.__client_id},{self.__name}"

