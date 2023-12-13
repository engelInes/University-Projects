#pragma once
#include "DynamicArray.h"

class Repo
{
private:
	DynamicArray<Movie>* dynamic_array;
public:
	Repo(DynamicArray<Movie>* repo_array);

	void initialise_repo();

	Movie* get_all_from_repo();

	int get_size_from_repo();

	int get_capacity_from_repo();

	void add_element_to_repo(const Movie& new_movie);

	void delete_element_from_repo(int index_of_deleted_element);

	void update_element_from_repo(int index_of_updated_element, const Movie& new_movie);

	int find_movie_by_name(string searched_title);

	~Repo();
};