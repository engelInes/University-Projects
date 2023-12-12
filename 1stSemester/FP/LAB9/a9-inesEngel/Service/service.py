import random
from Validators.errors import PlanePlacementError, AlreadyHitError, CellError
from Validators.validators import Validator

class Services:
    def __init__(self, repository):
        self._repository = repository
        self.__validator = Validator()

    @property
    def repository(self):
        return self._repository
    def add_plane(self, plane, owner):
        """
        Adds a plane
        :param plane: Plane object
        :param owner: string
        """
        if owner == "computer":
            if self.__validator.can_add_plane(plane, self._repository.computer_board):
                self._repository.add_plane(plane, owner)
            else:
                raise PlanePlacementError
        else:
            if self.__validator.can_add_plane(plane, self._repository.user_board):
                self._repository.add_plane(plane, owner)
            else:
                raise PlanePlacementError
    def hit_cell(self, x, y, owner):
        """
        Hits a cell
        :param x: integer
        :param y: integer
        :param owner: string
        :return: string
        """
        if owner == "computer":
            if self.__validator.validate_cell(x, y, self._repository.computer_board):
                if not self._repository.computer_board.board[x][y] == 'X':
                    ret = self._repository.hit_cell(x, y, owner)
                else:
                    raise AlreadyHitError
            else:
                raise CellError

        else:
            if self.__validator.validate_cell(x, y, self._repository.user_board):
                if not self._repository.user_board.board[x][y] == 'X':
                    ret = self._repository.hit_cell(x, y, owner)
                else:
                    raise AlreadyHitError
            else:
                raise CellError
        return ret

    def generate_computer_board(self):
        """
        Function that randomly places 3 planes
        """
        while self._repository.computer_board.number_of_planes < 3:
            try:
                orientation_list = ["up", "down", "left", "right"]
                orientation_index = random.randint(0, len(orientation_list)-1)
                x = random.randint(0, 9)
                y = random.randint(0, 9)
                orientation = orientation_list[orientation_index]
                plane = self._repository.create_plane(x, y, orientation)
                self.add_plane(plane, "computer")
            except PlanePlacementError:
                pass