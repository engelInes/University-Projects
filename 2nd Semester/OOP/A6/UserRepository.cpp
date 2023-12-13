#include "UserRepository.h"

bool UserRepository::add_userRepo(Movie movie)
{
	if (this->find_position_userRepo(movie) != -1)
		return false;

	this->user_repo.push_back(movie);
	return true;
}

bool UserRepository::remove_userRepo(Movie movie)
{
	if (this->find_position_userRepo(movie) == -1)
		return false;

	this->user_repo.erase(this->user_repo.begin() + this->find_position_userRepo(movie));
	return true; 
}

int UserRepository::find_position_userRepo(Movie movie)
{
	auto iterator = std::find(user_repo.begin(), user_repo.end(), movie);
	if (iterator != user_repo.end())
		return int(iterator - user_repo.begin());
	return -1;
}

std::vector<Movie> UserRepository::get_userRepo()
{
	return this->user_repo;
}
