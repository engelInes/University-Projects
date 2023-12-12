from Domain.plane import Plane
class Repository:
    def __init__(self, computer_board, user_board):
        self._computer_board = computer_board
        self._user_board = user_board
    @property
    def computer_board(self):
        return self._computer_board
    @property
    def user_board(self):
        return self._user_board
    @staticmethod
    def add_by_orientation(plane, var_board, i1, i2, r1, r2, rev=False):
        """
        Function that adds a plane with a certain orientation
        :param plane: Plane object
        :param var_board: Board object
        :param i1: integer
        :param i2: integer
        :param r1: integer
        :param r2: integer
        :param rev: boolean
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
            for j in range(left, right+1):
                if rev:
                    var_board.board[plane.cabin["x"]+j][plane.cabin["y"]+i]="A"
                else:
                    var_board.board[plane.cabin["x"]+i][plane.cabin["y"]+j]="A"
    def add_by_owner(self, plane, var_board):
        """
        Adds the computer's or the player's plane
        :param plane: Plane object
        :param var_board: Board object
        """
        var_board.board[plane.cabin["x"]][plane.cabin["y"]] = "C"
        var_board.number_of_planes=var_board.number_of_planes+1
        if plane.orientation == "up":
            self.add_by_orientation(plane, var_board, 1, 3, 1, 4)
        elif plane.orientation == "down":
            self.add_by_orientation(plane, var_board, -1, -3, -3, 0)
        if plane.orientation == "left":
            self.add_by_orientation(plane, var_board, 1, 3, 1, 4, rev=True)
        if plane.orientation == "right":
            self.add_by_orientation(plane, var_board, -1, -3, -3, 0, rev=True)
    def add_plane(self, plane, owner):
        """
        adds a plane.
        :param plane: Plane object
        :param owner: string
        """
        if owner == "computer":
            self.add_by_owner(plane, self._computer_board)
        else:
            self.add_by_owner(plane, self._user_board)
    def hit_cell(self, x, y, owner):
        """
        function that implements hitting a cell. If the cell is a cabin, the computer's board score will be implemented, marking the cell with "X"
        otherwise.
        :param x: integer
        :param y: integer
        :param owner: string
        :return: string
        """
        if owner == "computer":
            if self._computer_board.board[x][y] == "C":
                self._computer_board.board[x][y] = "X"
                self._computer_board.score=self._computer_board.score+1
                return "shot down"
            elif self._computer_board.board[x][y] == "A":
                self._computer_board.board[x][y] = "X"
                return "hit"
            else:
                self._computer_board.board[x][y] = "X"
                return "air"
        else:
            if self._user_board.board[x][y] == "C":
                self._user_board.board[x][y] = "X"
                self._user_board.score=self._user_board.score+1
                return "shot down"
            elif self._user_board.board[x][y] == "A":
                self._user_board.board[x][y] = "X"
                return "hit"
            else:
                self._user_board.board[x][y] = "X"
                return "air"
    @staticmethod
    def create_plane(x, y, orientation):
        """
        :param x: integer
        :param y: integer
        :param orientation
        :return: Plane object
        """
        plane = Plane(x, y, orientation)
        return plane