#pragma once
#include <iostream>

#include "Movie.h"
#include "AdministratorRepository.h"
#include "UserRepository.h"

class Service {
private:
	AdministratorRepository admin_repo;
	UserRepository user_repo;
public:
	Service(AdministratorRepository admin_repo, UserRepository user_repo) :admin_repo{ admin_repo }, user_repo{ user_repo }
	{};
	Service() {};

	bool add_admin_service(Movie movie);
	bool remove_admin_service(Movie movie);
	bool update_admin_service(Movie movie, Movie new_movie);

	bool add_user_service(Movie movie);
	bool remove_user_service(Movie movie);

	std::vector<Movie> get_adminRepo();
	std::vector<Movie> get_userRepo();

	AdministratorRepository get_admin_repo();
	UserRepository get_user_repo();
	void init_service();
	void save_data_to_file();
	void load_data();
};