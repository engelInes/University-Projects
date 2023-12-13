#include <stdio.h>
#include <stdlib.h>
#include "UI.h"
#include "DynamicArray.h"
#include "Repo.h"
#include "Service.h"
#include "Country.h"
#include <string.h>

void countries_at_startup(dynamic_array* country_list)
{
	add_country_to_service(country_list, "Romania", "Europe", 195679842);
	add_country_to_service(country_list, "Germany", "Europe", 86736221);
	add_country_to_service(country_list, "China", "Asia", 27482000);
	add_country_to_service(country_list, "France", "Europe", 76234532);
	add_country_to_service(country_list, "Kenya", "Africa", 20345862);
	add_country_to_service(country_list, "Italy", "Europe", 60000456);
	add_country_to_service(country_list, "Thailand", "Asia", 98252982);
	add_country_to_service(country_list, "Hungary", "Europe", 7000234);
	add_country_to_service(country_list, "Egypt", "Africa", 39386732);
	add_country_to_service(country_list, "Mexic", "America", 77252155);
}
void add_a_country_ui(dynamic_array* country_list)
{
	char name[50];
	char continent[50];
	char population_string[50];
	unsigned int population;
	printf("Enter the name of the country:\n");
	scanf_s("%s", name, sizeof(name));

	printf("Enter the continent of the country:\n");
	scanf_s("%s", continent, sizeof(continent));

	printf("Enter the population of the country:\n");
	scanf_s("%d", &population);
	
	add_country_to_service(country_list, name, continent, population);
}

void delete_a_country_ui(dynamic_array* country_list)
{
	char country_to_be_deleted[50];
	char continent_of_the_country[50];
	printf("Enter the name of the country you want to delete\n");
	scanf_s("%s", country_to_be_deleted, sizeof(country_to_be_deleted));
	
	printf("Enter the continent of the country you want to delete\n");
	scanf_s("%s", continent_of_the_country, sizeof(continent_of_the_country));
	
	delete_country_from_service(country_list, country_to_be_deleted, continent_of_the_country);
}

void update_name_ui(dynamic_array* country_list)
{
	char name_to_be_updated[50];
	char continent_of_the_country[50];
	char new_name[50];
	printf("Enter the name of the country you want to update\n");
	scanf_s("%s", name_to_be_updated, sizeof(name_to_be_updated));
	
	printf("Enter the continent of the country you want to update\n");
	scanf_s("%s", continent_of_the_country, sizeof(continent_of_the_country));
	
	printf("Enter the new name of the country\n");
	scanf_s("%s", new_name, sizeof(new_name));
	
	update_country_by_name_to_service(country_list, name_to_be_updated, continent_of_the_country, new_name);

}

void update_continent_ui(dynamic_array* country_list)
{
	char name[50];
	char continent[50];
	unsigned int population;
	unsigned int new_population;
	printf("Enter the population you want to update\n");
	scanf_s("%d", &population);
	
	printf("Enter the name of the country\n");
	scanf_s("%s", name, sizeof(name));
	
	printf("Enter the continent\n");
	scanf_s("%s", continent, sizeof(continent));
	
	printf("Enter the new population of the country\n");
	scanf_s("%d", &new_population);
	
	update_country_by_population_to_service(country_list, name, continent, population, new_population);
}

void update_population_ui(dynamic_array* country_list)
{
	char name[50];
	char continent_to_be_updated[50];
	char new_continent[50];
	printf("Enter the continent you want to update\n");
	scanf_s("%s", continent_to_be_updated, sizeof(continent_to_be_updated));
	
	printf("Enter the country from the continent you want to update\n");
	scanf_s("%s", name, sizeof(name));
	
	printf("Enter the new name of the continent\n");
	scanf_s("%s", new_continent, sizeof(new_continent));
	
	update_country_by_continent_to_service(country_list, name, continent_to_be_updated, new_continent);
}

void display_by_a_given_string_ui(dynamic_array* country_list)
{
	char given_string[50];
	printf("Enter the name by which you want to display the countries\n");
	scanf_s("%s", &given_string);

	given_string[strlen(given_string) - 1] = '\0';
	dynamic_array* result=get_countries_by_a_given_string_to_service(country_list, given_string);
	for (int i = 0; i < get_dynamic_array_size(&result->elements); i++)
	{
		printf("%s %s %d\n", result->elements[i].name, result->elements[i].continent, result->elements[i].population);
	}
}

void list_all_countries(dynamic_array* country_list)
{
	for (int i = 0; i < get_dynamic_array_size(&country_list->elements); i++)
		printf("%s %s %d\n", country_list->elements[i].name, country_list->elements[i].continent, country_list->elements[i].population);
}

void print_menu()
{
	printf("1. Add a country\n");
	printf("2. Delete a country\n");
	printf("3. Update a country's name\n");
	printf("4. Update a country's continent\n");
	printf("5. Update a country's population\n");
	printf("6. Display all countries whose name contains a given string\n");
	printf("7. List all countries\n");
	printf("0. Exit\n");
}

void run_menu()
{
	dynamic_array* country_list = create_repo();
	char option_string[10];
	int option;
	countries_at_startup(country_list);
	while (1)
	{
		print_menu();
		printf("\n");
		printf("Choose an option: ");
		int option;
		scanf_s("%d", &option);

		if (option == 0)
		{
			break;
		}
		else if (option == 1)
			add_a_country_ui(country_list);
		else if (option == 2)
			delete_a_country_ui(country_list);
		else if (option == 3)
			update_name_ui(country_list);
		else if (option == 4)
			update_continent_ui(country_list);
		else if (option == 5)
			update_population_ui(country_list);
		else if (option == 6)
			display_by_a_given_string_ui(country_list);
		else if (option == 7)
			list_all_countries(country_list);
		else
			printf("Invalid command");	
		printf("\n");
	}

	printf("Program finished");
	destroy_dynamic_array(country_list);
}