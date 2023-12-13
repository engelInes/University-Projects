#include "AdministratorRepository.h"
#include <algorithm>
#include <fstream>
#include <sstream>
#include "Exceptions.h"

bool AdministratorRepository::add_adminRepo(Movie movie)
{
	if (this->find_position_adminRepo(movie) != -1)
		return false;

	this->admin_repo.push_back(movie);
	return true;
}

bool AdministratorRepository::remove_adminRepo(Movie movie)
{
	if (this->find_position_adminRepo(movie) == -1)
		return false;

	this->admin_repo.erase(this->admin_repo.begin() + this->find_position_adminRepo(movie));
	return true;
}

bool AdministratorRepository::update_adminRepo(Movie movie, Movie new_movie)
{
	if (this->find_position_adminRepo(movie) == -1)
		return false;

	this->admin_repo[this->find_position_adminRepo(movie)] = new_movie;
	return true;
}

int AdministratorRepository::find_position_adminRepo(Movie movie)
{
	auto iterator = std::find(admin_repo.begin(), admin_repo.end(), movie);
	if (iterator != admin_repo.end())
		return int(iterator - admin_repo.begin());
	return -1;
}

std::vector<Movie> AdministratorRepository::get_adminRepo()
{
	return this->admin_repo;
}

std::vector<std::string> tokenise(std::string& string, char delimiter)
{
	std::vector<std::string> result;
	std::stringstream ss(string);
	std::string(token);

	while (getline(ss, token, delimiter))
		result.push_back(token);

	return result;
}

std::vector<Movie> AdministratorRepository::read_from_file()
{
	std::ifstream file("user_data2.txt");

	if (!file.is_open())
		throw FileException("[File Exception] reading admin repository\n");

	std::vector<Movie> movies;
	Movie movie;
	std::string movie_string;

	while (getline(file, movie_string))
	{
		std::vector<std::string> tokens = tokenise(movie_string, ',');

		Movie movie{ tokens[0], tokens[1], stoi(tokens[2]), stoi(tokens[3]), tokens[4] };

		movies.push_back(movie);
	}

	file.close();

	return movies;
}

void AdministratorRepository::write_to_file()
{
	std::ofstream file("user_data2.txt");

	if (!file.is_open())
		throw FileException("[File Exception] writing admin repo\n");

	for (auto movie : this->admin_repo)
		file << movie;

	file.close();
}

std::string AdministratorRepository::get_file_name()
{
	return this->file_name;
}
