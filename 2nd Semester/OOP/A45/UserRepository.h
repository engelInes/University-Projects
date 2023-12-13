#pragma once
#include "DynamicArray.h"
#include "Movie.h"

class UserRepository {
private:
	DynamicArray<Movie> watchList;
public:

	bool add_userRepo(Movie movie);
	bool remove_userRepo(Movie movie);
	
	DynamicArray<Movie> get_watchList();
	int get_watchList_size();

	int find_movie_position(Movie movie);

};