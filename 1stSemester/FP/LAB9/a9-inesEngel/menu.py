
from Domain.board import Board
from Repos.repo import Repository
from Service.service import Services
from Ui.ui import UI

if __name__ == "__main__":
    computer_board = Board(10, 10, "computer")
    user_board = Board(10, 10, "user")
    repository = Repository(computer_board, user_board)
    services = Services(repository)
    ui = UI(services)
    ui.start()