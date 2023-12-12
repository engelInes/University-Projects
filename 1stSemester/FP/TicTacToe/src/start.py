from src.Domain.domain import Board
from src.Repo.repo import Repo
from src.UI.ui import UI

if __name__=="__main__":
    b=Board(3,3)
    repo=Repo(b,r"C:\Users\Ines\PycharmProjects\er-inesEngel\src\game.txt")
    ui=UI(repo)
    ui.start_game()
