#pragma once
#include "DynamicArray.h"

void print_menu();
void run_menu();
void add_a_country_ui(dynamic_array* country_list);
void delete_a_country_ui(dynamic_array* country_list);
void update_name_ui(dynamic_array* country_list);
void update_continent_ui(dynamic_array* country_list);
void update_population_ui(dynamic_array* country_list);
void display_by_a_given_string_ui(dynamic_array* country_list);
void list_all_countries(dynamic_array* country_list);
void undo_ui(dynamic_array* repo);