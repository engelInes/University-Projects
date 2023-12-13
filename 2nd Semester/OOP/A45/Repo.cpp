#include "Repo.h"

Repo::Repo(DynamicArray<Movie>* repo_array)
{
	this->dynamic_array = repo_array;
}

void Repo::initialise_repo()
{
	Movie movie1 = Movie("Scream", "Comedy", 1999, 85733, "https://www.youtube.com/watch?v=h74AXqw4Opc");
	Movie movie2 = Movie("Hotel Transilvanya", "Comedy", 2012, 921918, "https://www.youtube.com/watch?v=OjDuQ7O9XUo");
	Movie movie3 = Movie("The Godfather", "Drama", 1972, 8723978, "https://www.youtube.com/watch?v=UaVTIH8mujA");
	Movie movie4 = Movie("Schindler's List", "Drama", 1993, 3722092, "https://www.youtube.com/watch?v=gG22XNhtnoY");
	Movie movie5 = Movie("The Lord Of The Rings", "SF", 2003, 8493038, "https://www.youtube.com/watch?v=x8UAUAuKNcU");
	Movie movie6 = Movie("Pulp Fiction", "Crime", 1994, 897590, "https://www.youtube.com/watch?v=WSLMN6g_Od4");
	Movie movie7 = Movie("Forrest Gump", "Drama", 1994, 9298894, "https://www.youtube.com/watch?v=bLvqoHBptjg");
	Movie movie8 = Movie("Fight Club", "Action", 1999, 879574, "https://www.youtube.com/watch?v=CR5Jp_ag2M8");
	Movie movie9 = Movie("Creed", "Action", 2023, 8774019, "https://www.youtube.com/watch?v=Fp5A8CXyS_E");
	Movie movie10 = Movie("Whiplash", "Drama", 2014, 1324435, "https://www.youtube.com/watch?v=ZZY-Ytrw2co");
	this->dynamic_array->add_element(movie1);
	this->dynamic_array->add_element(movie2);
	this->dynamic_array->add_element(movie3);
	this->dynamic_array->add_element(movie4);
	this->dynamic_array->add_element(movie5);
	this->dynamic_array->add_element(movie6);
	this->dynamic_array->add_element(movie7);
	this->dynamic_array->add_element(movie8);
	this->dynamic_array->add_element(movie9);
	this->dynamic_array->add_element(movie10);
}

Movie* Repo::get_all_from_repo()
{
	return (Movie*)this->dynamic_array->get_element();
}

int Repo::get_size_from_repo()
{
	return this->dynamic_array->get_size();
}

int Repo::get_capacity_from_repo()
{
	return this->dynamic_array->get_capacity();
}

void Repo::add_element_to_repo(const Movie& new_movie)
{
	this->dynamic_array->add_element(new_movie);
}

void Repo::delete_element_from_repo(int index_of_deleted_element)
{
	this->dynamic_array->delete_element(index_of_deleted_element);
}

void Repo::update_element_from_repo(int index_of_updated_element, const Movie& new_movie)
{
	this->dynamic_array->update_element(index_of_updated_element, new_movie);
}

int Repo::find_movie_by_name(string searched_title)
{
	int searched_index = -1;
	int length = this->get_size_from_repo();
	for (int i = 0; i < length; i++)
	{
		Movie current_movie = this->dynamic_array->get_element()[i];
		if (current_movie.get_title() == searched_title)
		{
			searched_index = i;
			break;
		}
	}
	return searched_index;
}

Repo::~Repo() = default;