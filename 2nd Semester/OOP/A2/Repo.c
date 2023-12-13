#include <stdlib.h>
#include "Country.h"
#include "DynamicArray.h"
#include "Repo.h"

dynamic_array* create_repo()
{
	return create_dynamic_array(2);
}

void add_country_to_repo(dynamic_array* repo, char* name, char* continent, unsigned int population)
{
	Country new_country;
	strcpy(new_country.name, name);
	strcpy(new_country.continent, continent);
	new_country.population = population;
	add_element_to_dynamic_array(repo, new_country);

}
void delete_country_from_repo(dynamic_array* repo, char* name, char* continent)
{
	int element_found_on_index = -1;
	for (int i = 0; i < get_dynamic_array_size(repo); i++)
	{
		if (!strcmp(repo->elements[i].name, name) && !strcmp(repo->elements[i].continent, continent))
		{
			element_found_on_index = i;
			break;
		}
	}
	if (element_found_on_index != -1)
	{
		for (int i = element_found_on_index; i < get_dynamic_array_size(repo) - 1; i++)
			repo->elements[i] = repo->elements[i + 1];
		repo->size--;
	}
}

void update_country_by_name_to_repo(dynamic_array* repo, char* name, char* continent, char* new_name)
{
	int element_found_on_index = -1;
	for (int i = 0; i < get_dynamic_array_size(repo); i++)
	{
		if (!strcmp(get_name(&repo->elements[i]), name) && !strcmp(get_continent(&repo->elements[i]), continent))
		{
			element_found_on_index = i;
		}
	}
	if (element_found_on_index != -1)
	{
		strcpy(repo->elements[element_found_on_index].name, new_name);
	}
}

void update_country_by_continent_to_repo(dynamic_array* repo, char* name, char* continent, char* new_continent)
{
	int element_found_on_index = -1;
	for (int i = 0; i < get_dynamic_array_size(repo); i++)
	{
		if (!strcmp(get_name(&repo->elements[i]), name) && !strcmp(get_continent(&repo->elements[i]), continent))
		{
			element_found_on_index = i;
		}
	}
	if (element_found_on_index != -1)
	{
		strcpy(repo->elements[element_found_on_index].continent, new_continent);
	}
}

void update_country_by_population_to_repo(dynamic_array* repo, char* name, char* continent, unsigned int population, unsigned int new_population)
{
	int element_found_on_index = -1;
	for (int i = 0; i < get_dynamic_array_size(repo); i++)
	{
		if (!strcmp(get_name(&repo->elements[i]), name) && !strcmp(get_continent(&repo->elements[i]), continent))
		{
			element_found_on_index = i;
		}
	}
	if (element_found_on_index != -1)
	{
		repo->elements[element_found_on_index].population = new_population;
	}
}

void update_migration_to_repo(dynamic_array* repo, int old_country_index, int new_country_index, unsigned int number_of_migrators)
{
	repo->elements[old_country_index].population = repo->elements[old_country_index].population - number_of_migrators;
	repo->elements[new_country_index].population = repo->elements[new_country_index].population + number_of_migrators;
}
