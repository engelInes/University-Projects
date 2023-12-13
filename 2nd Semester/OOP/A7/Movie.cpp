#include "Movie.h"
#include <sstream>
#include <vector>

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
	output << "Title: " << this->get_title() << "; ";
	output << "Genre: " << this->get_genre() << "; ";
	output << "Year : " << this->get_release_year() << "; ";
	output << "Likes : " << this->get_likes_number() << "; ";
	output << "Trailer : " << this->get_trailer() << "\n";
	return output.str();
}

void Movie::set_title(std::string new_title)
{
	this->title = new_title;
}

void Movie::set_genre(std::string new_genre)
{
	this->genre = new_genre;
}

void Movie::set_release_year(int new_release_year)
{
	this->release_year = new_release_year;
}

void Movie::set_likes_number(int new_likes_number)
{
	this->number_of_likes = new_likes_number;
}

void Movie::set_trailer(std::string new_trailer)
{
	this->trailer = new_trailer;
}

std::vector<std::string> tokenize(std::string& string, char delimiter)
{
	std::vector<std::string> result;
	std::stringstream ss(string);
	std::string(token);

	while (getline(ss, token, delimiter))
		result.push_back(token);

	return result;
}


//inline Movie& Movie::operator=(Movie& newMovie)
//{
//	if (this == &newMovie)
//		return *this;
//
//	this->title = newMovie.title;
//	this->genre = newMovie.genre;
//	this->releaseYear = newMovie.releaseYear;
//	this->likesNumber = newMovie.likesNumber;
//	this->trailer = newMovie.trailer;
//
//	return *this;
//}

std::istream& operator>>(std::istream& input_stream, Movie movie)
{
	std::string line;
	getline(input_stream, line);

	std::vector<std::string> tokens = tokenize(line, ',');

	/*if (tokens.size() != 5)
		return inputStream;*/

	movie.set_title(tokens[0]);
	movie.set_genre(tokens[1]);
	movie.set_release_year(stoi(tokens[2]));
	movie.set_likes_number(stoi(tokens[3]));
	movie.set_trailer(tokens[4]);

	return input_stream;
}

std::ostream& operator<<(std::ostream& output_stream, const Movie movie)
{
	output_stream << movie.get_title() << "," << movie.get_genre() << "," << movie.get_release_year() << "," << movie.get_likes_number() << "," << movie.get_trailer() << "\n";

	return output_stream;
}
