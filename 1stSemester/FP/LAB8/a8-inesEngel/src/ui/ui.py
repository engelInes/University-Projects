import sys

class Console:
    def __init__(self,client_service, movie_service,rental_service):
        self.__client_service=client_service
        self.__movie_service=movie_service
        self.__rental_service=rental_service

    @staticmethod
    def print_menu():
        print("Choose a command: ")
        print("1. Manage the list of clients")
        print("2. Manage the list of movies")
        print("3. Rent a movie")
        print("4. Return a movie")
        print("5. Search for clients")
        print("6. Search for movies")
        print("7. Display statistics")
        print("8. Undo the operation")
        print("9. Exit the program")

    @staticmethod
    def print_one():
        print("Choose an option: ")
        print("1. Add a client")
        print("2. List all clients")
        print("3. Remove a client")
        print("4. Update a client's info")
        print("5. Back to main menu")

    @staticmethod
    def print_two():
        print("Choose an option: ")
        print("1. Add a movie")
        print("2. List all movies")
        print("3. Remove a movie")
        print("4. Update a movie's info")
        print("5. Back to main menu")

    @staticmethod
    def print_five():
        print("Choose an option: ")
        print("1. Search a client by id")
        print("2. Search a client by name")
        print("3. Back to main menu")

    @staticmethod
    def print_six():
        print("Choose an option: ")
        print("1. Search a movie by id")
        print("2. Search a movie by title")
        print("3. Search a movie by description")
        print("4. Search a movie by genre")
        print("5. Back to main menu")

    @staticmethod
    def print_seven():
        print("Choose which statistic to see: ")
        print("1. Display the most rented movies")
        print("2. Display the most active clients")
        print("3. Display the late rentals")

    def display_clients(self):
        if len(self.__client_service)==0:
            print("There are no clients")
        else:
            for client in self.__client_service:
                print(client)

    def display_movie(self):
        if len(self.__movie_service)==0:
            print("There are no movies")
        else:
            for movie in self.__movie_service:
                print(movie)

    @staticmethod
    def print_search_results(results):
        if len(results)==0:
            print("No results found")
        else:
            for result in results:
                print(result)

    def print_stat_one(self, results):




