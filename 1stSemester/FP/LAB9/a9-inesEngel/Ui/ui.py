from Service.ai import AI
from Validators.errors import PlanePlacementError, AlreadyHitError, CellError, InputError
from Validators.validators import Validator
class UI:
    def __init__(self, services):
        self.__setup = False
        self.__validator = Validator()
        self.__services = services
        self.__ai = AI(self.__services.repository.user_board)
    def print_main_menu(self):
        if not self.__setup:
            print("The computer has placed its planes. Please place 3 planes on the board.")
        else:
            print("Try guessing the position of the cabin of one of the computer's planes")
    def print_user_board(self):
        print("")
        print("Your board: ")
        for i in range(self.__services.repository.user_board.height):
            for j in range(self.__services.repository.user_board.width):
                print(self.__services.repository.user_board.board[i][j], end="")
            print("")
        if self.__services.repository.user_board.number_of_planes < 3:
            print(f"Planes placed: {self.__services.repository.user_board.number_of_planes}/3")
        else:
            print(f"Planes shot down: {self.__services.repository.user_board.score}")
        print("")

    def print_computer_board(self):
        print("")
        print("Computer board: ")
        for i in range(self.__services.repository.computer_board.height):
            for j in range(self.__services.repository.computer_board.width):
                if self.__services.repository.computer_board.board[i][j] == "X":
                    print("X", end=" ")
                else:
                    print("0", end=" ")
            print("")
        print(f"Planes shot down: {self.__services.repository.computer_board.score}")
        print("")

    def print_computer_board_revealed(self):
        print("")
        print("Computer board: ")
        for i in range(self.__services.repository.computer_board.height):
            for j in range(self.__services.repository.computer_board.width):
                print(self.__services.repository.computer_board.board[i][j], end=" ")
            print("")
        print(f"Planes shot down: {self.__services.repository.computer_board.score}")
        print("")
    def place_plane(self):
        print("""Insert the coordinates of the plane (row in range [0, 9], column in range[0, 9]) and the orientation ("up", "down", "left" or "right")""")
        option = input(">>> ")
        if len(option.split()) != 3:
            raise InputError
        x = option.split()[0]
        y = option.split()[1]
        orientation = option.split()[2]
        if not self.__validator.coordinate_regex(x) or not self.__validator.coordinate_regex(y) or not self.__validator.orientation_regex(orientation):
            raise InputError
        return int(x), int(y), orientation
    def hit(self):
        print("Insert the coordinates of the cell you want to attack: ")
        option = input(">>> ")
        if len(option.split()) != 2:
            raise InputError
        x = option.split()[0]
        y = option.split()[1]
        if not self.__validator.coordinate_regex(x) or not self.__validator.coordinate_regex(y):
            raise InputError
        return int(x), int(y)
    @staticmethod
    def print_input_error():
        print("Invalid input")
    @staticmethod
    def print_plane_placement_error():
        print("Invalid placement. A plane cannot overlap with another plane or outrun the board.")
    @staticmethod
    def print_already_hit_error():
        print("Cell already hit")
    @staticmethod
    def print_cell_error():
        print("Incorrect cell")
    @staticmethod
    def print_shot_status(message):
        print(f"Shot status: {message}")
    @staticmethod
    def print_computer_shot(x, y, message):
        print(f"Last cell hit by the computer: ({x}, {y}) - {message}")
    @staticmethod
    def print_user_win():
        print("Game over! You shot down all the planes. This is how the boards looked like: ")
    @staticmethod
    def print_computer_win():
        print("Game over! The computer shot down all your planes.This is how the boards looked like: ")
    def start(self):
        self.__services.generate_computer_board()
        cont = 1
        while True:
            self.print_main_menu()
            if self.__services.repository.user_board.number_of_planes < 3:
                self.print_user_board()
                try:
                    x, y, orientation = self.place_plane()
                    plane = self.__services.repository.create_plane(x, y, orientation)
                    try:
                        self.__services.add_plane(plane, "user")
                    except PlanePlacementError:
                        self.print_plane_placement_error()
                except InputError:
                    self.print_input_error()
                if self.__services.repository.user_board.number_of_planes == 3:
                    self.__setup = True
            else:
                try:
                    if cont == 1:
                        x, y = self.__ai.generate(0, self.__services.repository.user_board.height - 1, 0, self.__services.repository.user_board.width - 1)
                        message = self.__services.hit_cell(x, y, "user")
                        self.print_user_board()
                        self.print_computer_shot(x, y, message)
                        if self.__services.repository.user_board.score == 3:
                            self.print_computer_win()
                            self.print_user_board()
                            self.print_computer_board_revealed()
                            return
                        self.print_computer_board()
                    if cont == -1:
                        cont=cont*(-1)
                    x, y = self.hit()
                    try:
                        message = self.__services.hit_cell(x, y, "computer")
                        self.print_shot_status(message)
                        if self.__services.repository.computer_board.score==3:
                            self.print_user_win()
                            self.print_user_board()
                            self.print_computer_board_revealed()
                            return
                    except AlreadyHitError:
                        self.print_already_hit_error()
                        cont=cont*(-1)
                    except CellError:
                        self.print_cell_error()
                        cont=cont*(-1)
                except InputError:
                    self.print_input_error()
                    cont=cont*(-1)