#pragma once
#include <string>
#include <iostream>
using namespace std;

class Movie {
private:
	string title;
	string genre;
	int release_year;
	int number_of_likes;
	string trailer;

public:
	Movie(string title, string genre, int releaseYear, int likesNumber, string trailer);
	Movie();

	string get_title();
	string get_genre();
	int get_releaseYear();
	int get_likesNumber();
	string get_trailer();
	string representation();
};