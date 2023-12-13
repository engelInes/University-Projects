#include "UI.h"
#include "Movie.h"
#include <Windows.h>
#include <shellapi.h>

#include <iostream>
#include <string>
#include <cstring>
#include <algorithm>

void UI::print_main_menu()
{
	std::cout << "Starting menu\n";
	std::cout << "1. Admin\n";
	std::cout << "2. User\n";
	std::cout << "3. Exit\n";
}

void UI::print_admin_menu()
{
	std::cout << "Administrator menu\n";
	std::cout << "1. Add\n";
	std::cout << "2. Remove\n";
	std::cout << "3. Update\n";
	std::cout << "4. Display\n";
	std::cout << "5. Exit\n";
}

void UI::print_user_menu()
{
	std::cout << "User menu\n";
	std::cout << "1. See movies by given genre\n";
	std::cout << "2. Remove from watchlist\n";
	std::cout << "3. Display watchlist\n";
	std::cout << "4. Exit\n";
}


void UI::run_menu()
{
	this->service.init_service();

	while (true)
	{
		this->print_main_menu();

		std::cout << "Enter option: ";
		std::string option;
		getline(std::cin, option);

		#define ADMIN_ROLE "1"
		#define USER_ROLE "2"
		#define EXIT "3"

		if (option == ADMIN_ROLE)
		{

			while (true)
			{
			this->print_admin_menu();

			std::cout << "Enter option: ";
			std::string option_admin;
			getline(std::cin, option_admin);

			#define ADD_ADMIN "1"
			#define REMOVE_ADMIN "2"
			#define UPDATE_ADMIN "3"
			#define DISPLAY_ADMIN "4"
			#define EXIT_ADMIN "5"

			if (option_admin == ADD_ADMIN)
				this->add_admin_ui();
			else if (option_admin == REMOVE_ADMIN)
				this->remove_admin_ui();
			else if (option_admin == UPDATE_ADMIN)
				this->update_admin_ui();
			else if (option_admin == DISPLAY_ADMIN)
				this->display_admin_ui();
			else if (option_admin == EXIT_ADMIN)
				break;
			else
				std::cout << "Invalid option";
			}

		}
		else if (option == USER_ROLE)
		{
			while (true)
			{
				this->print_user_menu();

				std::cout << "Enter option: ";
				std::string option_user;
				getline(std::cin, option_user);

				#define SEE_USER "1"
				#define REMOVE_USER "2"
				#define DISPLAY_USER "3"
				#define EXIT_USER "4"

				if (option_user == SEE_USER)
					this->see_movies_ui();
				else if (option_user == REMOVE_USER)
					this->remove_user_ui();
				else if (option_user == DISPLAY_USER)
					this->display_watchlist_ui();
				else if (option_user == EXIT_USER)
					break;
				else
					std::cout << "Invalid option";
			}
		}
		else if (option == EXIT)
			break;
		else
			std::cout << "Invalid option\n";
	}
}

void UI::add_admin_ui()
{
	std::string title, genre, trailer;
	int release_year, number_of_likes;
	std::cout << "Title: ";
	getline(std::cin, title);
	std::cout << "Genre: ";
	getline(std::cin, genre);
	std::cout << "Year of release: ";
	std::cin >> release_year;
	std::cout << "Number of likes: ";
	std::cin >> number_of_likes;
	std::cout << "Trailer: ";
	std::cin.ignore();
	getline(std::cin, trailer);

	Movie movie = Movie(title, genre, release_year, number_of_likes, trailer);

	bool result = this->service.add_admin_service(movie);
	if (result == false)
		std::cout << "Movie has not been added\n";
	else
		std::cout << "Movie added succesfully\n";
}

void UI::remove_admin_ui()
{
	std::string title, genre;
	std::cout << "Title: ";
	getline(std::cin, title);
	std::cout << "Genre: ";
	getline(std::cin, genre);

	Movie movie = Movie(title,genre,0,0,"...");

	bool result = this->service.remove_admin_service(movie);

	if (result == false)
		std::cout << "Movie does not exist\n";
	else
		std::cout << "Movie removed succesfully\n";
}

void UI::update_admin_ui()
{
	std::string title, genre, new_title, new_genre, new_trailer;
	int new_release_year, new_likes_number;
	std::cout << "Title: ";
	getline(std::cin, title);
	std::cout << "Genre: ";
	getline(std::cin, genre);

	std::cout << "New title: ";
	getline(std::cin, new_title);
	std::cout << "New genre: ";
	getline(std::cin, new_genre);
	std::cout << "New year of release: ";
	std::cin >> new_release_year;
	std::cout << "New number of likes: ";
	std::cin >> new_likes_number;
	std::cout << "New trailer: ";
	std::cin.ignore();
	getline(std::cin, new_trailer);

	Movie movie = Movie(title, genre, 0, 0, "...");
	Movie new_movie = Movie(new_title,new_genre,new_release_year,new_likes_number,new_trailer);

	bool result = this->service.update_admin_service(movie, new_movie);
	if (result == false)
		std::cout << "The movie has not been updated\n";
	else
		std::cout << "Movie updated\n";
}

bool compare(const Movie& movie1,const Movie& movie2)
{
	return movie1.get_title()<movie2.get_title();
}

void UI::display_admin_ui()
{
	auto repo_copy = this->service.get_adminRepo();

	std::sort(repo_copy.begin(), repo_copy.end(), compare);

	for (auto& movie : repo_copy) {
		std::cout <<movie.representation()<<std::endl;
	}
}

void UI::see_movies_ui()
{
	#define ADD_YES "yes"
    #define SEE_NO "no"

	std::string genre="";
	std::cout << "Give genre: ";
	getline(std::cin, genre);

	if (genre == "")
	{
		int current_size = 0;
		int watched_movies=0;

		while (current_size < this->service.get_adminRepo().size())
		{
			Movie movie = this->service.get_adminRepo()[current_size];

			if (this->service.get_user_repo().find_position_userRepo(movie) == -1)
			{
				std::cout << "Playing " << movie.representation() << "\n";
				std::string trailer = movie.get_trailer();

				ShellExecuteA(NULL, "open", trailer.c_str(), 0, 0, SW_SHOWNORMAL);

				std::cout << "Do you want to add the movie to watchlist? 1-yes/2-no";
				std::string option1;
				getline(std::cin, option1);

				if (option1 == ADD_YES)
					this->service.add_user_service(movie);

				std::cout << "Do you want to watch further?";
				std::string option2;
				getline(std::cin, option2);

				if (option2 == SEE_NO)
					break;

				watched_movies++;
			}
			current_size++;
			if (current_size == this->service.get_adminRepo().size())
			{
				current_size = 0;
				if (watched_movies == 0)
				{
					std::cout << "no movies left\n";
					break;
				}
			}
		}
	}
	else
	{
		int current_size = 0,counter=0,watched_movies=0;
		std::vector<Movie> new_list;

		for (int i = 0; i < this->service.get_adminRepo().size(); i++)
			if (this->service.get_adminRepo()[i].get_genre() == genre)
				new_list.push_back(this->service.get_adminRepo()[i]);
		counter = new_list.size();


		while (current_size < counter)
		{
			Movie movie = new_list[current_size];
			if (this->service.get_user_repo().find_position_userRepo(movie) == -1)
			{
				std::cout << "Playing " << movie.representation() << "\n";
				std::string trailer = movie.get_trailer();

				ShellExecuteA(NULL, "open", trailer.c_str(), 0, 0, SW_SHOWNORMAL);

				std::cout << "Do you want to add the movie to watchlist? 1-yes/2-no";
				std::string option1;
				getline(std::cin, option1);

				if (option1 == ADD_YES)
					this->service.add_user_service(movie);

				std::cout << "Do you want to watch further? 1-yes/2-no";
				std::string option2;
				getline(std::cin, option2);

				if (option2 == SEE_NO)
					break;

				watched_movies++;
			}
			current_size++;
			if (current_size == this->service.get_adminRepo().size())
			{
				current_size = 0;
				if (watched_movies == 0)
				{
					std::cout << "No movies left\n";
					break;
				}
			}
		}
	}
}

void UI::remove_user_ui()
{
	std::string title, genre;
	std::cout << "Title: ";
	getline(std::cin, title);
	std::cout << "Genre: ";
	getline(std::cin, genre);

	Movie movie = Movie(title, genre, 0, 0, "...");
	bool result = this->service.remove_user_service(movie);

	if (result == false)
		std::cout << "Movie doesnt exist\n";
	else
		std::cout << "Movie removed succesfully form watchlist\n";
}

void UI::display_watchlist_ui()
{
	for (int i = 0; i < this->service.get_userRepo().size(); i++)
		std::cout <<this->service.get_userRepo()[i].representation() <<"\n";
}
