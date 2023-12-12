from domain import Board

class Repository:
    def __init__(self, file_name, board):
        self.file_name=file_name
        self._board=board

    def save(self, file_name):
        self.board.write_to_file(file_name)


