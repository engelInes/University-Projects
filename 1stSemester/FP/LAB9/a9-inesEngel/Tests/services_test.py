import unittest
from Domain.board import Board
from Domain.plane import Plane
from Repos.repo import Repository
from Service.service import Services
from Validators.errors import PlanePlacementError, AlreadyHitError, CellError
class TestServices(unittest.TestCase):
    def setUp(self) -> None:
        self.__computer_board = Board(10, 10, "computer")
        self.__user_board = Board(10, 10, "user")
        self.__repository = Repository(self.__computer_board, self.__user_board)
        self.__services = Services(self.__repository)
    def tearDown(self) -> None:
        pass
    def test_add_plane(self):
        p1 = Plane(2, 4, "down")
        p2 = Plane(0, 0, "up")
        p3 = Plane(4, 7, "right")
        p4 = Plane(1, 3, "left")
        self.__services.add_plane(p1, "user")
        with self.assertRaises(PlanePlacementError):
            self.__services.add_plane(p2, "user")
        self.__services.add_plane(p3, "computer")
        self.__services.add_plane(p4, "computer")
        self.assertEqual(self.__services.repository.user_board.number_of_planes, 1)
        self.assertEqual(self.__services.repository.computer_board.number_of_planes, 2)

    def test_hit_cell(self):
        p1 = Plane(6, 6, "down")
        p2 = Plane(6, 6, "up")
        self.__services.add_plane(p1, "computer")
        self.__services.add_plane(p2, "user")
        self.assertEqual(self.__services.hit_cell(1, 1, "computer"), "air")
        self.assertEqual(self.__services.hit_cell(6, 6, "computer"), "shot down")
        self.assertEqual(self.__services.hit_cell(4, 5, "computer"), "hit")
        with self.assertRaises(AlreadyHitError):
            self.__services.hit_cell(1, 1, "computer")
        with self.assertRaises(CellError):
            self.__services.hit_cell(0, 10, "computer")
        self.assertEqual(self.__services.hit_cell(7, 1, "user"), "air")
        self.assertEqual(self.__services.hit_cell(3, 3, "user"), "shot down")
        self.assertEqual(self.__services.hit_cell(4, 3, "user"), "hit")
        with self.assertRaises(AlreadyHitError):
            self.__services.hit_cell(7, 1, "user")
        with self.assertRaises(CellError):
            self.__services.hit_cell(-1, 9, "user")
    def test_generate_computer_board(self):
        self.__services.generate_computer_board()
        self.assertEqual(self.__services.repository.computer_board.number_of_planes, 3)

# if __name__=="__main__":
#     print(TestServices(unittest.TestCase))