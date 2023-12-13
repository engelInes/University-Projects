#include "Movie.h"
#include <sstream>

std::string Movie::get_title() const
{
	return this->title;
}

std::string Movie::get_genre() const
{
	return this->genre;
}

int Movie::get_release_year() const
{
	return this->release_year;
}

int Movie::get_likes_number() const
{
	return this->number_of_likes;
}

std::string Movie::get_trailer() const
{
	return this->trailer;
}

std::string Movie::representation()
{
	std::ostringstream output;
	output << "Title: " << this->get_title() << " |Genre: " << this->get_genre() << " |Year: " << this->get_release_year() << " |Likes: " << this->get_likes_number() << " |Trailer: " << this->get_trailer();
	return output.str();
}

bool Movie::operator==(const Movie movie)
{
	return (this->title.compare(movie.title) == 0 && (this->genre.compare(movie.genre) == 0));
}

