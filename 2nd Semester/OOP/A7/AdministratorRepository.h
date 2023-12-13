#pragma once
#include <iostream>
#include <vector>
#include <string>
#include "Movie.h"
#include <fstream>
#include <fstream>


#define FILE_NAME "C:\Users\Ines\Desktop\OOP\A7"
class AdministratorRepository {
private:
	std::vector<Movie> admin_repo;
	std::string file_name;

public:
	AdministratorRepository(std::string file_name) :file_name{ file_name }
	{
		this->admin_repo = this->read_from_file();
	}
	AdministratorRepository() {}
	bool add_adminRepo(Movie movie);
	bool remove_adminRepo(Movie movie);
	bool update_adminRepo(Movie movie, Movie new_movie);
	int find_position_adminRepo(Movie movie);
	std::vector<Movie> get_adminRepo();

	std::vector<Movie> read_from_file();
	void write_to_file();
	std::string get_file_name();
};