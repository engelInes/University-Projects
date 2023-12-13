#include "Repo.h"
#include "DynamicArray.h"

void add_country_to_service(dynamic_array* repo, operation_dynamic_array* undo_array, char* name, char* continent, unsigned int population)
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
		Country country = add_country_to_repo(repo, name, continent, population);
		Operation undo;
		strcpy(undo.operation, "add");
		undo.country = country;
		add_element_to_operation_dynamic_array(undo_array, undo);
	}
	destroy_dynamic_array(array_of_all_countries);
}

void delete_country_from_service(dynamic_array* repo, operation_dynamic_array* undo_array, char* name, char* continent)
{
	Country country = delete_country_from_repo(repo, name, continent);
	Operation undo;
	strcpy(undo.operation, "delete");
	undo.country = country;
	add_element_to_operation_dynamic_array(undo_array, undo);
}

void update_country_by_name_to_service(dynamic_array* repo, operation_dynamic_array* undo_array, char* name, char* continent, char* new_name)
{
	Country country = update_country_by_name_to_repo(repo, name, continent, new_name);
	Operation undo;
	strcpy(undo.operation, "update name");
	undo.country = country;
	add_element_to_operation_dynamic_array(undo_array, undo);
}

void update_country_by_continent_to_service(dynamic_array* repo, operation_dynamic_array* undo_array, char* name, char* continent, char* new_continent)
{
	Country country = update_country_by_continent_to_repo(repo, name, continent, new_continent);
	Operation undo;
	strcpy(undo.operation, "update continent");
	undo.country = country;
	add_element_to_operation_dynamic_array(undo_array, undo);
}

void update_country_by_population_to_service(dynamic_array* repo, operation_dynamic_array* undo_array, char* name, char* continent, unsigned int population, unsigned int new_population)
{
	Country country = update_country_by_population_to_repo(repo, name, continent, population, new_population);
	Operation undo;
	strcpy(undo.operation, "update population");
	undo.country = country;
	add_element_to_operation_dynamic_array(undo_array, undo);
}

void update_migration_to_service(dynamic_array* repo, operation_dynamic_array* undo_array, int old_country_index, int new_country_index, unsigned int number_of_migrators)
{
	Country country = update_migration_to_repo(repo, old_country_index, new_country_index, number_of_migrators);
	Operation undo;
	strcpy(undo.operation, "update migration");
	undo.country = country;
	add_element_to_operation_dynamic_array(undo_array, undo);
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

void sort_countries_ascending_by_population(dynamic_array* countries)
{
	for (int i = 0; i < countries->size - 1; i++)
	{
		for (int j = i; j < countries->size; j++)
		{
			if (countries->elements[i].population > countries->elements[j].population)
			{
				Country auxiliary_element = countries->elements[i];
				countries->elements[i] = countries->elements[j];
				countries->elements[j] = auxiliary_element;
			}
		}
	}
}
dynamic_array* get_countries_on_a_continent_to_service(dynamic_array* repo, char* continent, unsigned int value)
{
	dynamic_array* searched_countries = create_dynamic_array(2);
	for (int i = 0; i < repo->size; i++)
	{
		if (strcmp(repo->elements[i].continent, continent) == 0 && repo->elements[i].population > value)
		{
			add_element_to_dynamic_array(searched_countries, repo->elements[i]);
		}
	}
	sort_countries_ascending_by_population(searched_countries);
	return searched_countries;
}

int undo_service(dynamic_array* repo, operation_dynamic_array* undo)
{

}