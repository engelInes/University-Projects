from src.Domain.domain import Board
from src.Repo.repo import Repo
class UI:
    def __init__(self, repo):
        self._repo=repo

    def start_game(self):
        #while True:
            b=Board(3,3)
            print(b)
            option=input("Which piece do you want to play with?")
            if option=="X":
                x_pieces=4
                while x_pieces:
                    row = int(input("Choose a row"))
                    col = int(input("Choose a column"))
                    self._repo.place_human(row, col, "X")
                    x_pieces = x_pieces - 1
                    print(self._repo._board)
                    # if self._repo.check_win("X")==1:
                    #     print("Game over")
                    #     return
                    self._repo.place_computer("O")
                    print(self._repo._board)
                    # if self._repo.check_win("O")==1:
                    #     print("Game over")
                    #     return
                game_over=0
                print("movement phase")
                while game_over==0:
                    row=int(input("Choose a row"))
                    col=int(input("Choose a column"))
                    row=row-1
                    col=col-1
                    self._repo.player_move(row, col, "X")
                    print(self._repo._board)
                    if self._repo.check_win("X")==1:
                        print("Game over")
                        game_over=1
                    self._repo.computer_move("O")
                    print(self._repo._board)
                    if self._repo.check_win("O")==1:
                        print("Game over")
                        game_over=1

            elif option=="O":
                x_pieces = 4
                while x_pieces:
                    self._repo.place_computer("X")
                    # if self._repo.check_win("O")==1:
                    #     print("Game over")
                    #     return
                    print(self._repo._board)
                    row = int(input("Choose a row"))
                    col = int(input("Choose a column"))
                    self._repo.place_human(row, col, "O")
                    x_pieces = x_pieces - 1
                    print(self._repo._board)
                    # if self._repo.check_win("X")==1:
                    #     print("Game over")
                    #     return
                game_over = 0
                print("movement phase")
                while game_over == 0:
                    self._repo.computer_move("X")
                    print(self._repo._board)
                    if self._repo.check_win("O") == 1:
                        print("Game over")
                        game_over = 1
                    row = int(input("Choose a row"))
                    col = int(input("Choose a column"))
                    row = row - 1
                    col = col - 1
                    self._repo.player_move(row, col, "O")
                    print(self._repo._board)
                    if self._repo.check_win("X") == 1:
                        print("Game over")
                        game_over = 1
            # save=input("Do you want to save the game?")
            # if save=="Yes":
            else:
                print("Invalid command")

            self._repo.save(r"C:\Users\Ines\PycharmProjects\er-inesEngel\src\game.txt")

