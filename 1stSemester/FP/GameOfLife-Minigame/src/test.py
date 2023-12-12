from unittest import TestCase
from domain import Board

class Test(TestCase):
    def test_board_placing(self):
        board = Board()
        pattern = board.read_pattern(r"C:\Users\Ines\PycharmProjects\e1-913-inesEngel\src\GameOfLife.txt")
        assert "spaceship" in pattern
        assert "blinker" in pattern
        assert [["X", "X"], ["X", "X"]] in pattern
        assert [["X", "X"], ["X", " "]] not in pattern


if __name__ == '__main__':
    testing=Test()
