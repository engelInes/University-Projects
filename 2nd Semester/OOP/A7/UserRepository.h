#pragma once
#include <iostream>
#include <vector>
#include "Movie.h"
#include <fstream>

class UserRepository {
private:
	std::vector<Movie> user_repo;
public:

	bool add_userRepo(Movie movie);
	bool remove_userRepo(Movie movie);
	int find_position_userRepo(Movie movie);
	std::vector<Movie> get_userRepo();
	void save_to_file_user();
	void load_from_file_user();
};