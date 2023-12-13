#include "UI.h"
#include <iostream>

using namespace std;

UI::UI(Service* service_array)
{
	this->service_array = service_array;
}

void UI::add_ui()
{
	string title;
	string genre;
	int year_of_release;
	int number_of_likes;
	string string_year_of_release;
	string string_number_of_likes;
	string trailer;
	cout << "Enter the title" << endl;
	getline(cin, title);

	cout << "Enter the genre" << endl;
	getline(cin, genre);

	cout << "Enter the year_of_release" << endl;
	getline(cin, string_year_of_release);
	year_of_release = stoi(string_year_of_release);

	cout << "Enter the number_of_likes" << endl;
	getline(cin, string_number_of_likes);
	number_of_likes = stoi(string_number_of_likes);

	cout << "Enter the trailer" << endl;
	getline(cin, trailer);
	
	int check_if_added = this->service_array->add_element_to_service(title, genre, year_of_release, number_of_likes, trailer);
	if (check_if_added == 1)
		cout << "The film has been added" << "\n";
	else
		cout << "The film already exists" << "\n";
}

void UI::delete_ui()
{
	string title;
	cout << "Enter the title of the film you want to delete" << "\n";
	getline(cin, title);

	int check_if_deleted = this->service_array->delete_element_from_service(title);
	if (check_if_deleted == 1)
		cout << "The film has been deleted" << "\n";
	else
		cout << "The film does not exist" << "\n";
}

void UI::update_ui()
{
	string old_title;
	string new_title;
	string new_genre;
	int new_year_of_release;
	int new_number_of_likes;
	string string_new_year_of_release;
	string string_new_number_of_likes;
	string new_trailer;
	cout << "Enter the title of the film you want to update" << endl;
	getline(cin, old_title);

	cout << "Enter the new title" << endl;
	getline(cin, new_title);

	cout << "Enter the new genre" << endl;
	getline(cin, new_genre);

	cout << "Enter the new year_of_release" << endl;
	getline(cin, string_new_year_of_release);
	new_year_of_release = stoi(string_new_year_of_release);

	cout << "Enter the new number_of_likes" << endl;
	getline(cin, string_new_number_of_likes);
	new_number_of_likes = stoi(string_new_number_of_likes);

	cout << "Enter the new trailer" << endl;
	getline(cin, new_trailer);

	int check_if_updated = this->service_array->update_element_from_service(old_title, new_title, new_genre, new_year_of_release, new_number_of_likes, new_trailer);
	if (check_if_updated == 1)
		cout << "The film has been updated" << "\n";
	else
		cout << "The film does not exist" << "\n";

}

void UI::print_all()
{
	Movie* all_movies = this->service_array->get_all_from_service();
	int number_of_movies = this->service_array->get_size_from_service();
	if (number_of_movies == 0)
		throw "There are no movies to be listed";
	for (int i = 0; i < number_of_movies; i++)
		cout << all_movies[i].str_representation() << "\n";
}

void UI::print_administrator_options()
{
	cout << "1. List all movies" << "\n";
	cout << "2. Add a new movie" << "\n";
	cout << "3. Delete a movie" << "\n";
	cout << "4. Update a movie" << "\n";
	cout << "0. Exit the program" << "\n";
}

void UI::administrator_menu()
{
	bool run = true;
	while (run)
	{
		print_administrator_options();
		cout << "Choose an option: " << "\n";
		string option_string;
		getline(cin, option_string);
		int option = stoi(option_string);
		if (option == 1)
			this->print_all();
		else if (option == 2)
			this->add_ui();
		else if (option == 3)
			this->delete_ui();
		else if (option == 4)
			this->update_ui();
		else if (option == 0)
		{
			run = false;
			cout << "Program finished" << "\n";
		}
		else
			cout << "Invalid command" << "\n";
	}
}

UI::~UI() = default;
