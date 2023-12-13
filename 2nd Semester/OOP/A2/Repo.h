#pragma once
#include "Country.h"
#include "DynamicArray.h"

dynamic_array* create_repo();
void add_country_to_repo(dynamic_array* repo, char* name, char* continent, unsigned int population);
void delete_country_from_repo(dynamic_array* repo, char* name, char* continent);
void update_country_by_name_to_repo(dynamic_array* repo, char* name, char* continent, char* new_name);
void update_country_by_continent_to_repo(dynamic_array* repo, char* name, char* continent, char* new_continent);
void update_country_by_population_to_repo(dynamic_array* repo, char* name, char* continent, unsigned int population, unsigned int new_population);
void update_migration_to_repo(dynamic_array* array, int old_country_index, int new_country_index, unsigned int number_of_migrators);
