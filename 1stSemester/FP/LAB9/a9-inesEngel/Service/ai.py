import random
from Validators.validators import Validator
class AI:
    def __init__(self, board):
        self.__board = board
        self.__validator = Validator()
    def generate(self, x1, x2, y1, y2):
        """
        A function that randomly chooses a valid cell to hit
        :return: the coordinates
        """
        rand_cells = [(0, 0), (0, 1), (1, 0), (1, 1), (0, 8), (0, 9), (1, 8), (1, 9), (8, 0), (8, 1), (9, 0), (9, 1), (8, 8), (8, 9), (9, 8), (9, 9)]
        x = random.randint(x1, x2)
        y = random.randint(y1, y2)
        while (self.__board.board[x][y] == "X") or ((x, y) in rand_cells):
            x = random.randint(x1, x2)
            y = random.randint(y1, y2)
        return x, y
