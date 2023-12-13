#pragma once
#include <iostream>
#include <vector>

#include "Movie.h"

class AdministratorRepository {
private:
	std::vector<Movie> admin_repo;

public:
	bool add_adminRepo(Movie movie);
	bool remove_adminRepo(Movie movie);
	bool update_adminRepo(Movie movie, Movie new_movie);
	int find_position_adminRepo(Movie movie);
	std::vector<Movie> get_adminRepo();
};