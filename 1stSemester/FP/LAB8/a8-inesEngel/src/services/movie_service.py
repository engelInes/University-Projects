from dataclasses import dataclass
from src.domain.movie_entity import Movie
from src.repository.movie_repo import MovieRepo
@dataclass(frozen=True)
class MovieService:
    movieRepo: MovieRepo

    def add_movie(self, movie_id, title, description, genre):
        movie_id=int(movie_id)
        movie=Movie(movie_id,title,description,genre)
        self.movieRepo.save(movie)

    def list_movies(self):
        return self.movieRepo.list_movies()

    def remove_movie(self, movie_id):
        movie_id=int(movie_id)
        movie=self.movieRepo.get_movie_by_id(movie_id)
        self.movieRepo.remove(movie)

    def update_movie_by_id(self, movie_id, title, description, genre):
        movie_id=int(movie_id)
        movie=self.movieRepo.get_movie_by_id(movie_id)
        self.movieRepo.update_movie_by_id(movie,title,description,genre)

