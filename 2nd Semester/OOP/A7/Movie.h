#pragma once
#include <iostream>
#include <string>

class Movie {
private:
	std::string title, genre, trailer;
	int release_year, number_of_likes;

public:
	Movie() {}
	Movie(std::string title, std::string genre, int release_year, int number_of_likes, std::string trailer) :title{ title },
		genre{ genre },
		release_year{ release_year },
		number_of_likes{ number_of_likes },
		trailer{ trailer } {};
	std::string get_title() const;
	std::string get_genre() const;
	int get_release_year() const;
	int get_likes_number() const;
	std::string get_trailer() const;
	std::string representation();

	void set_title(std::string new_title);
	void set_genre(std::string new_genre);
	void set_release_year(int new_release_year);
	void set_likes_number(int new_likes_number);
	void set_trailer(std::string new_trailer);

	friend std::istream& operator>>(std::istream& input_stream, Movie movie);
	friend std::ostream& operator>>(std::ostream& output_stream, const Movie movie);
	/*bool operator==(const Movie movie);

	friend std::ostream& operator<<(std::ostream& os, const Movie& movie) {
		os << movie.title << ',' << movie.genre << ',' << movie.release_year << ',' << movie.number_of_likes << ',' << movie.trailer;
		return os;
	}

	friend std::istream& operator>>(std::istream& is, Movie& movie) {
		std::getline(is, movie.title, ',');
		std::getline(is, movie.genre, ',');
		is >> movie.release_year;
		is.ignore();
		is >> movie.number_of_likes;
		is.ignore();
		std::getline(is, movie.trailer);
		return is;
	}*/
};