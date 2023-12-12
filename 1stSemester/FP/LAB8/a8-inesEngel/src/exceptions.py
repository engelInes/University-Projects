class ClientException(Exception):
    def __init__(self, message=''):
        self.message=message

    def __str__(self):
        return self.message


class MovieException(Exception):
    def __init__(self, message=''):
        self.message = message

    def __str__(self):
        return self.message


class RepoException(Exception):
    def __init__(self, message=''):
        self.message = message

    def __str__(self):
        return self.message


class UndoRedoException(Exception):
    def __init__(self, message=''):
        self.message = message

    def __str__(self):
        return self.message