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

void UserRepository::save_to_file_user()
{
	std::ofstream file("C:\\Users\\Ines\\Desktop\\OOP\\A7\\user_data2.txt");
	if (file.is_open()) {
		for (const Movie& movie : user_repo) {
			file << movie << '\n';
		}
		file.close();
	}
	else {
		std::cerr << "Failed to open file for writing: " << "user_data.txt" << '\n';
	}
}

void UserRepository::load_from_file_user()
{
	std::ifstream file("user_data.txt");
	if (!file)
	{
		std::ofstream createFile("user_data.txt");
		createFile.close();
	}
	else
	{
		//if (file.is_open()) {
		user_repo.clear();
		Movie movie;
		while (file >> movie) {
			user_repo.push_back(movie);
		}
		file.close();
		//}
		//else {
			//std::cerr << "Failed to open file for reading: " << "user_data.txt" << '\n';
		//}
	}
}
