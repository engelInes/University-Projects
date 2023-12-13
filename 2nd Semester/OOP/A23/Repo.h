#pragma once
#include "Country.h"
#include "DynamicArray.h"

dynamic_array* create_repo();
Country add_country_to_repo(dynamic_array* repo, char* name, char* continent, unsigned int population);
Country delete_country_from_repo(dynamic_array* repo, char* name, char* continent);
Country update_country_by_name_to_repo(dynamic_array* repo, char* name, char* continent, char* new_name);
Country update_country_by_continent_to_repo(dynamic_array* repo, char* name, char* continent, char* new_continent);
Country update_country_by_population_to_repo(dynamic_array* repo, char* name, char* continent, unsigned int population, unsigned int new_population);
Country update_migration_to_repo(dynamic_array* array, int old_country_index, int new_country_index, unsigned int number_of_migrators);
