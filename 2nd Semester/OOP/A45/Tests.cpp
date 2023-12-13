#include "Movie.h"
#include "DynamicArray.h"
#include "Repo.h"
#include "Service.h"
#include <cassert>
#include <cstring>

void test_domain()
{
	Movie movie("Mission Impossible", "Action", 2000, 3248542, "https://www.youtube.com/watch?v=2m1drlOZSDw");
	assert(movie.get_title() == "Mission Impossible");
	assert(movie.get_genre() == "Action");
	assert(movie.get_year_of_release() == 2000);
	assert(movie.get_number_of_likes() == 3248542);
	assert(movie.get_trailer() == "https://www.youtube.com/watch?v=2m1drlOZSDw");
}

void test_repo()
{
	auto* dynamic_array = new DynamicArray<Movie>(10);
	Repo repo = Repo(dynamic_array);
	repo.initialise_repo();

	assert(repo.get_size_from_repo() == 10);
	assert(repo.get_capacity_from_repo() == 10);
	assert(repo.get_all_from_repo()[0].get_title() == "Scream");
	assert(repo.get_all_from_repo()[0].get_genre() == "Comedy");
	assert(repo.get_all_from_repo()[0].get_year_of_release() == 1999);
	assert(repo.get_all_from_repo()[0].get_number_of_likes() == 85733);
	assert(repo.get_all_from_repo()[0].get_trailer() == "https://www.youtube.com/watch?v=h74AXqw4Opc");

	Movie new_movie = Movie("300", "Action", 2011, 487584, "https://www.youtube.com/watch?v=h74AXqw4Opc");
	repo.add_element_to_repo(new_movie);
	assert(repo.get_size_from_repo() == 11);
	assert(repo.get_all_from_repo()[10].get_title() == "300");
	assert(repo.get_all_from_repo()[10].get_genre() == "Action");
	assert(repo.get_all_from_repo()[10].get_year_of_release() == 2011);
	assert(repo.get_all_from_repo()[10].get_number_of_likes() == 487584);
	assert(repo.get_all_from_repo()[10].get_trailer() == "https://www.youtube.com/watch?v=h74AXqw4Opc");

	int index_of_deleted_element = 2;
	repo.delete_element_from_repo(index_of_deleted_element);
	assert(repo.get_size_from_repo() == 10);
	assert(repo.get_all_from_repo()[index_of_deleted_element].get_title() == "Schindler's List");
	assert(repo.get_all_from_repo()[index_of_deleted_element].get_genre() == "Drama");
	assert(repo.get_all_from_repo()[index_of_deleted_element].get_year_of_release() == 1993);
	assert(repo.get_all_from_repo()[index_of_deleted_element].get_number_of_likes() == 3722092);
	assert(repo.get_all_from_repo()[index_of_deleted_element].get_trailer() == "https://www.youtube.com/watch?v=gG22XNhtnoY");

	int index_of_updated_movie = 0;
	Movie new_movie2 = Movie("300", "Action", 2011, 487584, "https://www.youtube.com/watch?v=h74AXqw4Opc");
	repo.update_element_from_repo(index_of_updated_movie, new_movie2);
	assert(repo.get_all_from_repo()[0].get_title() == "300");
	assert(repo.get_all_from_repo()[0].get_genre() == "Action");
	assert(repo.get_all_from_repo()[0].get_year_of_release() == 2011);
	assert(repo.get_all_from_repo()[0].get_number_of_likes() == 487584);
	assert(repo.get_all_from_repo()[0].get_trailer() == "https://www.youtube.com/watch?v=h74AXqw4Opc");

	string searched_title = "300";
	assert(repo.find_movie_by_name(searched_title) == 0);
}

void test_service()
{
	auto* dynamic_array = new DynamicArray<Movie>(10);
	auto* repo = new Repo(dynamic_array);
	repo->initialise_repo();
	Service service = Service(repo);

	assert(service.get_all_from_service()[0].get_title() == "Scream");
	assert(service.get_all_from_service()[0].get_genre() == "Comedy");
	assert(service.get_all_from_service()[0].get_year_of_release() == 1999);
	assert(service.get_all_from_service()[0].get_number_of_likes() == 85733);
	assert(service.get_all_from_service()[0].get_trailer() == "https://www.youtube.com/watch?v=h74AXqw4Opc");

	service.add_element_to_service("300", "Action", 2011, 487584, "https://www.youtube.com/watch?v=h74AXqw4Opc");
	assert(service.get_all_from_service()[10].get_title()=="300");
	assert(service.get_all_from_service()[10].get_genre() == "Action");
	assert(service.get_all_from_service()[10].get_year_of_release() == 2011);
	assert(service.get_all_from_service()[10].get_number_of_likes() == 487584);
	assert(service.get_all_from_service()[10].get_trailer() == "https://www.youtube.com/watch?v=h74AXqw4Opc");

	string title_of_deleted_element = "300";
	assert(service.delete_element_from_service(title_of_deleted_element) == 1);

	string old_title = "Scream";
	string new_title = "Taken";
	string new_genre="Action";
	int new_year_of_release = 2016;
	int new_number_of_likes=909812;
	string new_trailer = "https://www.youtube.com/watch?v=h74AXqw4Opc";
	assert(service.update_element_from_service(old_title, new_title, new_genre, new_year_of_release, new_number_of_likes, new_trailer)==1);

}

void test_all()
{
	test_domain();
	test_repo();
	test_service();
}