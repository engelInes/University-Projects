import re
from datetime import datetime
from src.exceptions import ClientException
from src.exceptions import MovieException
class ClientValidator:
    @staticmethod
    def validate(client):
        if len(str(client.name))==0:
            raise ClientException("Empty input")
        if not client.name.replace(" ","").isaplha():
            raise ClientException("Invalid name")
        if int(client.client_id)<0:
            raise ClientException("Insert a positive ID")
    # def validate_name(name):
    #     '''
    #
    #     :param name:
    #     :return:
    #     '''
    #     for i in name:
    #         if i != " " and i != "-" and not i.isaplha():
    #             return False
    #     return True
    #
    # @staticmethod
    # def validate_id(id):
    #     """
    #     Validates the ID "n_id". It can only be an integer with a non-zero first digit.
    #     :param id: string
    #     :return: bool
    #     """
    #     if not re.match("^[1-9][0-9]*$", id):
    #         return False
    #     return True


class MovieValidator:
    @staticmethod
    def validate(movie):
        if int(movie.movie_id)<0:
            raise MovieException("Insert a valid movie ID")
        if len(str(movie.title))==0:
            raise MovieException("Empty input")
        if len(str(movie.description))==0:
            raise MovieException("Empty input")
        if len(str(movie.genre))==0:
            raise MovieException("Empty input")


