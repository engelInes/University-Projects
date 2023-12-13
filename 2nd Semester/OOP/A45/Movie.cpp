#include "Movie.h"
#include <sstream>

Movie::Movie(string title, string genre, int release_year, int number_of_likes, string trailer): title{title},genre{genre},release_year{release_year},number_of_likes{number_of_likes},trailer{trailer}{}

Movie::Movie()
{
	this->title = "";
	this->genre = "";
	this->release_year = 0;
	this->number_of_likes = 0;
	this->trailer = "";
}

string Movie::get_title()
{
	return this->title;
}

string Movie::get_genre()
{
	return this->genre;
}

int Movie::get_releaseYear()
{
	return this->release_year;
}

int Movie::get_likesNumber()
{
	return this->number_of_likes;
}

string Movie::get_trailer()
{
	return this->trailer;
}

string Movie::representation()
{
	ostringstream output;

	output << "Title: " << this->title << " |Genre: " << this->genre << " |Year: " << this->release_year << " |Likes: " << this->number_of_likes << " |Trailer: " << this->trailer<<"\n";
	return output.str();
}
