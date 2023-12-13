#pragma once
#include "Repo.h"

class Service
{
private:
	Repo* repo;
public:
	Service(Repo* repo);

	Movie* get_all_from_service();

	int get_size_from_service();

	int get_capacity_from_service();

	int add_element_to_service(string title, string genre, int year_of_release, int number_of_likes, string trailer);

	int delete_element_from_service(string title);

	int update_element_from_service(string old_title, string new_title, string new_genre, int new_year_of_release, int new_number_of_likes, string new_trailer);

	~Service();
};