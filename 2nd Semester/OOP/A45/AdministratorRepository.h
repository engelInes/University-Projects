#pragma once
#include "Movie.h"
#include "DynamicArray.h"

class AdministratorRepository {
private:
	DynamicArray<Movie> movies; 
public:
	int get_movies_size();

	bool add_admin(Movie movie);
	bool remove_admin(Movie movie);
	bool update_admin(Movie movie,Movie newMovie);
	DynamicArray<Movie> get_movies();

	int find_movie_position(Movie movie);
};