#include "AdministratorRepository.h"
#include <algorithm>
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

	this->admin_repo.erase(this->admin_repo.begin()+this->find_position_adminRepo(movie));
	return true;
}

bool AdministratorRepository::update_adminRepo(Movie movie,Movie new_movie)
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
		return int(iterator-admin_repo.begin());
	return -1;
}

std::vector<Movie> AdministratorRepository::get_adminRepo()
{
	return this->admin_repo;
}
