#pragma once
#include "DynamicArray.h"
#include "Repo.h"

void add_country_to_service(dynamic_array* repo, char* name, char* continent, unsigned int population);
void delete_country_from_service(dynamic_array* repo, char* name, char* continent);
void update_country_by_name_to_service(dynamic_array* repo, char* name, char* continent, char* new_name);
void update_country_by_continent_to_service(dynamic_array* repo, char* name, char* continent, char* new_continent);
void update_country_by_population_to_service(dynamic_array* repo, char* name, char* continent, unsigned int population, unsigned int new_population);
void update_migration_to_service(dynamic_array* array, int old_country_index, int new_country_index, unsigned int number_of_migrators);
dynamic_array* get_countries_by_a_given_string_to_service(dynamic_array* repo, char* given_string);