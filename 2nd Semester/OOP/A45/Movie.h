#pragma once
#include <string>

using namespace std;

class Movie
{
public:
	Movie(string title="empty", string genre="empty", int year_of_release=0, int number_of_likes=0, string trailer="empty");

	string get_title();
	string get_genre();
	int get_year_of_release();
	int get_number_of_likes();
	string get_trailer();

	string str_representation() const;

	~Movie();

private:
	string title;
	string genre;
	int year_of_release;
	int number_of_likes;
	string trailer;
};
