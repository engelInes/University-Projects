#from dataclasses import dataclass, field
from src.domain.movie_entity import Movie
#@dataclass(frozen=True)
class MovieRepo:
    #movies: list[Movie] = field(default_factory=list)
    def __init__(self):
        self._movies=[]
        self._movies_rents={}

    def list_movies(self):
        return self._movies

    def save(self, movie):
        self._movies.append(movie)

    def remove(self, movie):
        self._movies.remove(movie)

    def get_movie_by_id(self, id):
        for movie in self._movies:
            if movie.movie_id== id:
                return movie
        return None

    def update_movie_by_id(self, movie, title, description, genre):
        index=0
        count=0
        for movie in self._movies:
            count=count+1
            if movie.movie_id== id:
                index=count
        #index = self.movies.index(movie)
        movie.title=title
        movie.description=description
        movie.genre=genre
        self._movies[index] =movie

    def search(self, method):
        found = ""
        for movie in self._movies:
            id = movie.movie_id
            title = movie.title
            description = movie.description
            genre = movie.genre
            method = method.lower()
            if method in title.lower() or method in description.lower() or method in genre.lower():
                found = found + str(id) + " " + str(title) + " " + str(description) + " " + str(genre) + "\n"
        if found=="":
            found = "Unfound search"
        return found

    def topMovies(self):
        movielist = self._movies
        rentDict = self._movies_rents
        for i in range(0, len(movielist)):
            for j in range(i + 1, len(movielist)):
                if int(rentDict[str(movielist[i].movie_id)]) < int(rentDict[str(movielist[j].movie_id)]):
                    movielist[i], movielist[j] = movielist[j], movielist[i]
        top = ""
        for movie in movielist:
            top = top + " " + str(movie.movie_id) + " " + str(movie.title)+" "+str(movie.description)+" "+str(movie.genre)
        return top


