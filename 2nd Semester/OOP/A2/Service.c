#include "Repo.h"
#include "DynamicArray.h"

void add_country_to_service(dynamic_array* repo, char* name, char* continent, unsigned int population)
{
	dynamic_array* array_of_all_countries = create_dynamic_array(2);
	for (int i = 0; i < get_dynamic_array_size(repo); i++)
	{
		add_element_to_dynamic_array(array_of_all_countries, repo->elements[i]);
	}
	int check_if_country_exists = 0;
	for (int i = 0; i < get_dynamic_array_size(array_of_all_countries); i++)
	{
		if (!strcmp(get_name(&array_of_all_countries->elements[i]), name) && !strcmp(get_continent(&array_of_all_countries->elements[i].continent), continent))
		{
			check_if_country_exists = 1;
		}
	}
	if (check_if_country_exists == 0)
	{
		add_country_to_repo(repo, name, continent, population);
	}
	destroy_dynamic_array(array_of_all_countries);
}

void delete_country_from_service(dynamic_array* repo, char* name, char* continent)
{
	delete_country_from_repo(repo, name, continent);
}

void update_country_by_name_to_service(dynamic_array* repo, char* name, char* continent, char* new_name)
{
	update_country_by_name_to_repo(repo, name, continent, new_name);
}

void update_country_by_continent_to_service(dynamic_array* repo, char* name, char* continent, char* new_continent)
{
	update_country_by_continent_to_repo(repo, name, continent, new_continent);
}

void update_country_by_population_to_service(dynamic_array* repo, char* name, char* continent, unsigned int population, unsigned int new_population)
{
	update_country_by_population_to_repo(repo, name, continent, population, new_population);
}

void update_migration_to_service(dynamic_array* repo, int old_country_index, int new_country_index, unsigned int number_of_migrators)
{
	update_migration_to_repo(repo, old_country_index, new_country_index, number_of_migrators);
}

dynamic_array* get_countries_by_a_given_string_to_service(dynamic_array* repo, char* given_string)
{
	dynamic_array* array_of_all_countries = create_dynamic_array(2);
	for (int i = 0; i < get_dynamic_array_size(repo); i++)
	{
		add_element_to_dynamic_array(array_of_all_countries, repo->elements[i]);
	}
	if (!strcmp(given_string, ""))
		return array_of_all_countries;

	dynamic_array* searched_countries = create_dynamic_array(2);
	for (int i = 0; i < get_dynamic_array_size(array_of_all_countries); i++)
	{
		if (strstr(repo->elements[i].name, given_string))
			add_element_to_dynamic_array(searched_countries, repo->elements[i]);
	}
	destroy_dynamic_array(array_of_all_countries);
	return searched_countries;
}