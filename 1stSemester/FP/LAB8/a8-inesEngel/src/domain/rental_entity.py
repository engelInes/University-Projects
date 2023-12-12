import datetime
#from dataclasses import dataclass

#@dataclass#(frozen=True)
class Rental:
    def __init__(self,rental_id: int,movie_id: int,client_id: int,rented_date: datetime.datetime,due_date: datetime.datetime,returned_date: datetime.datetime):
        self._rental_id=rental_id
        self._movie_id=movie_id
        self._client_id=client_id
        self._rented_date=rented_date
        self._due_date=due_date
        self._returned_date=returned_date

    @property
    def rental_id(self):
        return self._rental_id

    @rental_id.setter
    def rental_id(self,value):
        self._rental_id=value

    @property
    def movie_id(self):
        return self._movie_id

    @movie_id.setter
    def movie_id(self,value):
        self._movie_id=value

    @property
    def client_id(self):
        return self._client_id

    @client_id.setter
    def client_id(self,value):
        self._client_id=value

    @property
    def rented_date(self):
        return self._rented_date

    @rented_date.setter
    def rented_date(self,date):
        self._rented_date=date

    @property
    def due_date(self):
        return self._due_date

    @due_date.setter
    def due_date(self,date):
        self._due_date=date

    @property
    def returned_date(self):
        return self._returned_date

    @returned_date.setter
    def returned_date(self,date):
        self._returned_date=date

    def __str__(self):
        return f"{self._rental_id}, {self._movie_id}, {self._client_id}, {self._rented_date} ,{self._due_date}, {self._returned_date}"

def testRental():
    pass