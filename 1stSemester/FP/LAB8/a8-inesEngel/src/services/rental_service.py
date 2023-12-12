from dataclasses import dataclass
from src.domain.rental_entity import Rental
from src.repository.rental_repo import RentalRepo
@dataclass(frozen=True)
class RentalService:
    rentalRepo:RentalRepo

    def add_rental(self, rental_id,movie_id,client_id,rented_date,due_date,returned_date):
        rental_id=int(rental_id)
        movie_id=int(movie_id)
        client_id=int(client_id)
        rental=Rental(rental_id,movie_id,client_id,rented_date,due_date,returned_date)
        self.rentalRepo.save(rental)

    def list_rentals(self):
        return self.rentalRepo.list_rentals()

    def remove_rental(self, rental_id):
        rental_id=int(rental_id)
        rental=self.rentalRepo.get_rental_by_id(rental_id)
        self.rentalRepo.remove(rental)

    def update_rental_by_id(self,rental_id,movie_id,client_id,rented_date,due_date,returned_date):
        rental_id=int(rental_id)
        movie_id=int(movie_id)
        client_id=int(client_id)
        rental=self.rentalRepo.get_rental_by_id(rental_id)
        self.rentalRepo.update_rental_by_id(rental,movie_id,client_id,rented_date,due_date,returned_date)

    def return_movie(self,date,rental):
        rental.returned_date=date

    def rent_movie(self,rental,date):
        if rental.due_date>date:


