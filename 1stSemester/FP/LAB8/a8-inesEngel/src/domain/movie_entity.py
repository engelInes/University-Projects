#from dataclasses import dataclass
#@dataclass(frozen=True)
#@dataclass
class Movie:
    def __init__(self,movie_id:int,title:str,description:str,genre:str):
        self._movie_id=movie_id
        self._title=title
        self._description=description
        self._genre=genre

    @property
    def movie_id(self):
        return self._movie_id

    @movie_id.setter
    def movie_id(self,value):
        self._movie_id=value

    @property
    def title(self):
        return self._title

    @title.setter
    def title(self, string):
        self._title=string

    @property
    def description(self):
        return self._description

    @description.setter
    def description(self, string):
        self._description = string

    @property
    def genre(self):
        return self._genre

    @genre.setter
    def genre(self, string):
        self._genre = string

    def __str__(self):
        return f"{self._movie_id},{self._title},{self._description},{self._genre}"



