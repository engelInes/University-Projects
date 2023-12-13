#pragma once
#include <iostream>


class Movie {
private:
	std::string title,genre,trailer;
	int release_year, number_of_likes;

public:
	Movie(std::string title, std::string genre, int release_year, int number_of_likes, std::string trailer):title{ title },
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
	bool operator==(const Movie movie);
};