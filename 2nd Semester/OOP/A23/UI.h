#pragma once
#include "DynamicArray.h"

void print_menu();
void run_menu();
void add_a_country_ui(dynamic_array* country_list, operation_dynamic_array* undo_array);
void delete_a_country_ui(dynamic_array* country_list, operation_dynamic_array* undo_array);
void update_name_ui(dynamic_array* country_list, operation_dynamic_array* undo_array);
void update_continent_ui(dynamic_array* country_list, operation_dynamic_array* undo_array);
void update_population_ui(dynamic_array* country_list, operation_dynamic_array* undo_array);
void display_by_a_given_string_ui(dynamic_array* country_list);
void list_all_countries(dynamic_array* country_list, operation_dynamic_array* undo_array);
void undo_ui(dynamic_array * repo, operation_dynamic_array * undo_array);
void get_countries_on_a_continent_ui(dynamic_array* repo, char* continent, unsigned int value);
