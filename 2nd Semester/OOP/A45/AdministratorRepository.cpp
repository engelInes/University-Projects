#include "AdministratorRepository.h"

int AdministratorRepository::get_movies_size()
{
	return this->movies.get_size();
}

bool AdministratorRepository::add_admin(Movie movie)
{
	int position = this->find_movie_position(movie);
	if (position != -1)
		return false;
	
	this->movies.add(movie);
	return true;
}

bool AdministratorRepository::remove_admin(Movie movie)
{
	int position = this->find_movie_position(movie);
	if(position==-1)
		return false;

	this->movies.remove(position);
	return true;
}

bool AdministratorRepository::update_admin(Movie movie,Movie newMovie)
{
	int position = this->find_movie_position(movie);
	if (position == -1)
		return false;

	this->movies.update(position, newMovie);
	return true;
}

DynamicArray<Movie> AdministratorRepository::get_movies()
{
	return this->movies;
}

int AdministratorRepository::find_movie_position(Movie movie)
{
	for(int i=0;i<this->movies.get_size();i++)
		if (this->movies.get_element(i).get_title() == movie.get_title() && this->movies.get_element(i).get_genre() == movie.get_genre())
			return i;
	return -1;
}
