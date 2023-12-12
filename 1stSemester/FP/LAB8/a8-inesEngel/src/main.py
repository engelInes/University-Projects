from src.repository.client_repo import ClientRepo
from src.services.client_service import ClientService
from src.ui.ui import Console

if __name__ == "__main__":
    clientRepo = ClientRepo()
    movieRepo=MovieRepo()
    clientService = ClientService(clientRepo)
    movieService=MovieService(movieRepo)
    console = Console(clientService,movieService)
    console.run_console()
