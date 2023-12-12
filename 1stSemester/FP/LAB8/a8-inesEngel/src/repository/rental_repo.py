#from dataclasses import dataclass, field
from src.domain.rental_entity import Rental
import datetime
#@dataclass(frozen=True)
class RentalRepo:
    #rentals: list[Rental]=field(default_factory=list)
    def __init__(self):
        self._rentals=[]

    def list_rentals(self):
        return self._rentals

    def save(self, rental):
        self._rentals.append(rental)

    def remove(self,rental):
        self._rentals.remove(rental)

    def get_rental_by_id(self, id):
        for rental in self._rentals:
            if rental.rental_id==id:
                return rental
        return None

    def today_date(self):
        today=datetime.datetime.now()
        year=today.year
        month=today.month
        day=today.day
        new_date=date(year,month,day)
        return new_date

    def update_rental_by_id(self,rental,movie_id,client_id,rented_date,due_date,returned_date):
        index=self._rentals.index(rental)
        rental.movie_id=movie_id
        rental.client_id=client_id
        rental.rented_date=rented_date
        rental.due_date=due_date
        rental.returned_date=returned_date
        self._rentals[index]=rental

    def check_if_available(self, movie_id, client_id):
        found=False
        for rent in self._rentals:
            if rent.movie_id==movie_id:
                found=True
            if rent.client_id==client_id:
                date1=rent.due_date
                date2=self.
# if __name__=="__main__":
#     repo=ClientRepo()
#     client=Client(1,"inesina")
#     repo.save(client)
#     print(repo.clients)