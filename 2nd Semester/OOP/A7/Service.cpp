#include "Service.h"

bool Service::add_admin_service(Movie movie)
{
    return this->admin_repo.add_adminRepo(movie);
}

bool Service::add_user_service(Movie movie)
{
    return this->user_repo.add_userRepo(movie);
}

bool Service::remove_user_service(Movie movie)
{
    return this->user_repo.remove_userRepo(movie);
}

bool Service::remove_admin_service(Movie movie)
{
    return this->admin_repo.remove_adminRepo(movie);
}

bool Service::update_admin_service(Movie movie, Movie new_movie)
{
    return this->admin_repo.update_adminRepo(movie, new_movie);
}

std::vector<Movie> Service::get_adminRepo()
{
    return this->admin_repo.get_adminRepo();
}

std::vector<Movie> Service::get_userRepo()
{
    return this->user_repo.get_userRepo();
}

AdministratorRepository Service::get_admin_repo()
{
    return this->admin_repo;
}

UserRepository Service::get_user_repo()
{
    return this->user_repo;
}

void Service::init_service()
{
    Movie movie1 = Movie("Mission impossible 7", "action", 2023, 1400000, "https://www.youtube.com/watch?v=2m1drlOZSDw");
    Movie movie2 = Movie("Top Gun 2", "action", 2022, 3500000, "https://www.youtube.com/watch?v=giXco2jaZ_4");
    Movie movie3 = Movie("Hacksaw Ridge", "thriller", 2016, 105000, "https://www.youtube.com/watch?v=RdjO0p4GJPA");
    Movie movie4 = Movie("Fast 10", "action", 2023, 1200000, "https://www.youtube.com/watch?v=MeF5QeZ_LLI");
    Movie movie5 = Movie("John Wick 4", "action", 2023, 100000, "https://www.youtube.com/watch?v=yjRHZEUamCc");
    Movie movie6 = Movie("Dunkirk", "thriller", 2017, 120000, "https://www.youtube.com/watch?v=F-eMt3SrfFU");
    Movie movie7 = Movie("The dictator", "comedy", 2012, 90000, "https://www.youtube.com/watch?v=cYplvwBvGA4");

    this->admin_repo.add_adminRepo(movie1);
    this->admin_repo.add_adminRepo(movie2);
    this->admin_repo.add_adminRepo(movie3);
    this->admin_repo.add_adminRepo(movie4);
    this->admin_repo.add_adminRepo(movie5);
    this->admin_repo.add_adminRepo(movie6);
    this->admin_repo.add_adminRepo(movie7);
}

void Service::save_data_to_file()
{
    user_repo.save_to_file_user();
}

void Service::load_data()
{
    user_repo.load_from_file_user();
}
