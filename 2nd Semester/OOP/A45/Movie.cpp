#include "Movie.h"
#include <iostream>
#include <sstream>

Movie::Movie(string title, string genre, int year_of_release, int number_of_likes, string trailer)
{
	this->title = title;
	//this->title = std::move(title);
	this->genre = genre;
	this->year_of_release = year_of_release;
	this->number_of_likes = number_of_likes;
	this->trailer = trailer;

}

string Movie::get_title()
{
	return this->title;
}

string Movie::get_genre()
{
	return this->genre;
}

int Movie::get_year_of_release()
{
	return this->year_of_release;
}

int Movie::get_number_of_likes()
{
	return this->number_of_likes;
}

string Movie::get_trailer()
{
	return this->trailer;
}

string Movie::str_representation() const
{
	ostringstream output;
	output << "Title: " << this->title << ", ";
	output << "Genre: " << this->genre << ", ";
	output << "Year of release: " << this->year_of_release << ", ";
	output << "Number of likes: " << this->number_of_likes << ", ";
	output << "Trailer link: " << this->trailer << "\n";

	return output.str();
}

Movie::~Movie() = default;