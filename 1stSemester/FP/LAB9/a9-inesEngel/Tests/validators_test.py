import unittest

from Domain.board import Board
from Domain.plane import Plane
from Repos.repo import Repository
from Service.service import Services
from Validators.validators import Validator
class TestValidator(unittest.TestCase):
    def setUp(self) -> None:
        self._validator = Validator()
        self._computer_board = Board(10, 10, "computer")
        self._user_board = Board(10, 10, "user")
        self._repository = Repository(self._computer_board, self._user_board)
        self._services = Services(self._repository)
    def tearDown(self) -> None:
        pass
    def test_orientation_regex(self):
        self.assertEqual(self._validator.orientation_regex("upu"), False)
        self.assertEqual(self._validator.orientation_regex("right"), True)

    def test_coordinate_regex(self):
        self.assertEqual(self._validator.coordinate_regex("10"), False)
        self.assertEqual(self._validator.coordinate_regex("2"), True)

    def test_validate_cell(self):
        board = Board(10, 10, "computer")
        self.assertEqual(self._validator.validate_cell(0, 10, board), False)
        self.assertEqual(self._validator.validate_cell(-1, 9, board), False)
        self.assertEqual(self._validator.validate_cell(0, 9, board), True)

    def test_validate_coordinate(self):
        self.assertEqual(self._validator.validate_coordinate(4, 0, 7), True)
        self.assertEqual(self._validator.validate_coordinate(5, 2, 2), False)

    def test_can_add_plane(self):
        plane1 = Plane(0, 2, "down")
        plane2 = Plane(3, 4, "up")
        plane3 = Plane(7, 8, "up")
        plane4 = Plane(3, 3, "right")
        plane5 = Plane(1, 5, "left")
        plane6 = Plane(2, 4, "left")
        plane7 = Plane(3, 8, "down")
        plane8 = Plane(6, 8, "left")
        plane9 = Plane(8, 9, "up")
        plane_added = Plane(5, 6, "left")
        self._services.add_plane(plane_added, "computer")
        self.assertEqual(self._validator.can_add_plane(plane1, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane2, self._services.repository.computer_board), True)
        self.assertEqual(self._validator.can_add_plane(plane3, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane4, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane5, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane6, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane7, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane8, self._services.repository.computer_board), False)
        self.assertEqual(self._validator.can_add_plane(plane9, self._services.repository.computer_board), False)

# if __name__=="__main__":
#     print(TestValidator(unittest.TestCase))