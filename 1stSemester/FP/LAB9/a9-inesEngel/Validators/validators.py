import re
class Validator:
    def overlap(self, plane, board, i1, i2, r1, r2, reverse=False):
        """
        Checks if a plane would overlap with planes already placed.
        :param plane: Plane object
        :param board: Board object
        :param i1: integer
        :param i2: integer
        :param r1: integer
        :param r2: integer
        :param reverse: boolean
        :return: boolean
        """
        for i in range(r1, r2):
            left = 0
            right = 0
            if i == i1:
                left=left-2
                right=right+2
            elif i == i2:
                left=left-1
                right=right+1
            for j in range(left, right + 1):
                if reverse:
                    if self.validate_coordinate(plane.cabin["x"] + j, 0, board.height) and self.validate_coordinate(plane.cabin["y"] + i, 0, board.width):
                        if board.board[plane.cabin["x"] + j][plane.cabin["y"] + i] == "A" or board.board[plane.cabin["x"] + j][plane.cabin["y"] + i] == "C":
                            return True
                else:
                    if self.validate_coordinate(plane.cabin["x"] + i, 0, board.height) and self.validate_coordinate(plane.cabin["y"] + j, 0, board.width):
                        if board.board[plane.cabin["x"] + i][plane.cabin["y"] + j] == "A" or board.board[plane.cabin["x"] + i][plane.cabin["y"] + j] == "C":
                            return True
        return False

    def can_add_plane(self, plane, board):
        """
        Checks if a plane can be added: it does not overlap and it does not outrun the board.
        :param plane: Plane object
        :param board: Board object
        :return: boolean
        """
        if plane.orientation == "up" and (plane.cabin["x"] < 0 or plane.cabin["x"]+3 >= board.height or plane.cabin["y"]-2 < 0 or plane.cabin["y"]+2 >= board.width):
            return False
        if plane.orientation == "down" and (plane.cabin["x"]-3 < 0 or plane.cabin["x"] >= board.height or plane.cabin["y"]-2 < 0 or plane.cabin["y"]+2 >= board.width):
            return False
        if plane.orientation == "left" and (plane.cabin["x"]-2 < 0 or plane.cabin["x"]+2 >= board.height or plane.cabin["y"] < 0 or plane.cabin["y"]+3 >= board.width):
            return False
        if plane.orientation == "right" and (plane.cabin["x"]-2 < 0 or plane.cabin["x"]+2 >= board.height or plane.cabin["y"]-3 < 0 or plane.cabin["y"] >= board.width):
            return False
        if plane.orientation == "up" and self.overlap(plane, board, 1, 3, 0, 4):
            return False
        if plane.orientation == "down" and self.overlap(plane, board, -1, -3, -3, 1):
            return False
        if plane.orientation == "left" and self.overlap(plane, board, 1, 3, 0, 4, reverse=True):
            return False
        if plane.orientation == "right" and self.overlap(plane, board, -1, -3, -3, 1, reverse=True):
            return False
        return True
    @staticmethod
    def validate_coordinate(x, lb, ub):
        """
        Checks if x is in the bounds
        :param x: integer
        :param lb: integer
        :param ub: integer
        :return: boolean
        """
        if x < lb or x >= ub:
            return False
        return True
    def validate_cell(self, x, y, board ):
        """
        Checks if the cell is inside the board
        :param x: integer
        :param y: integer
        :param board: Board object
        :return: boolean
        """
        if not self.validate_coordinate(x, 0, board.height):
            return False
        if not self.validate_coordinate(y, 0, board.width):
            return False
        return True
    @staticmethod
    def coordinate_regex(x):
        """
        Regex for coordinates input
        :param x: string
        :return: boolean
        """
        if not re.match("^[0-9]{1}$", x):
            return False
        return True
    @staticmethod
    def orientation_regex(orientation):
        """
        Regex for orientation input
        :param orientation: string
        :return: boolean
        """
        if not re.match("^(up|down|left|right){1}$", orientation):
            return False
        return True