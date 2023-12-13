#include "Service.h"

Service::Service(Repo* repo_array)
{
	this->repo = repo_array;
}

Movie* Service::get_all_from_service()
{
	return this->repo->get_all_from_repo();
}

int Service::get_size_from_service()
{
	return this->repo->get_size_from_repo();
}

int Service::get_capacity_from_service()
{
	return this->repo->get_capacity_from_repo();
}

int Service::add_element_to_service(string title, string genre, int year_of_release, int number_of_likes, string trailer)
{
	int length = this->repo->get_size_from_repo();
	for (int i = 0; i < length; i++)
	{
		string current_element = this->get_all_from_service()[i].get_title();
		if (current_element == title)
			return 1;
	}
	this->repo->add_element_to_repo(Movie(title, genre, year_of_release, number_of_likes, trailer));
	return 0;
}

int Service::delete_element_from_service(string title)
{
	int index_of_deleted_element = this->repo->find_movie_by_name(title);
	if (index_of_deleted_element == -1)
		return 0;
	this->repo->delete_element_from_repo(index_of_deleted_element);
	return 1;
}

int Service::update_element_from_service(string old_title, string new_title, string new_genre, int new_year_of_release, int new_number_of_likes, string new_trailer)
{
	int index_of_updated_element = this->repo->find_movie_by_name(old_title);
	if (index_of_updated_element == -1)
		return 0;
	Movie new_movie = Movie(new_title, new_genre, new_year_of_release, new_number_of_likes, new_trailer);
	this->repo->update_element_from_repo(index_of_updated_element, new_movie);
	return 1;
}

Service::~Service()=default;