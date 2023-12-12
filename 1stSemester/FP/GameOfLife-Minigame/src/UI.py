from domain import Board
from copy import deepcopy

class UI:
    def __init__(self):
        self.board = Board()
        #self.repo=repo

    def read_input(self):
        option=input("Please type your command: ")
        option=option.split(" ",1)
        if option[0]=="exit":
            return False

        elif option[0]=="save":
            self.save(option[1])
            return True

        elif option[0]=="place":
            self.place(option[1])
            return True

        else:
            print("Wrong command!")
            return True

    def run(self):
        print(self.board)
        read=self.read_input()
        while read!=False:
            print(self.board)
            read=self.read_input()

    def place(self, coordinates):
        prev_data=deepcopy(self.board._data)
        patterns=self.board.read_pattern(r"C:\Users\Ines\PycharmProjects\e1-913-inesEngel\src\GameOfLife.txt")#the list of patterns
        parameters=coordinates.split()

        if len(parameters[1])!=3:
            print("Wrong input")
            return

        if len(parameters)!=2:
            print("Wrong input")
            return

        if parameters[1][1] != ",":
            print("Wrong input")
            return

        if parameters[1][0].isdigit() and parameters[1][2].isdigit():
            x=int(parameters[1][0])
            x=x-1
            y=int(parameters[1][2])
            y=y-1
            if x>7 or y>7:
                print("The move is outside the board")
                return
            #print(patterns)
            if parameters[0] in patterns:
                #print(parameters[0])
                for type_of_pattern in range(len(patterns)):
                    if patterns[type_of_pattern] == parameters[0]:#searching for the pattern in the list
                        for pattern_list in range(len(patterns[type_of_pattern+1])):
                            for row in range(len(patterns[type_of_pattern+1][pattern_list])):
                                if patterns[type_of_pattern+1][pattern_list][row]=="X":
                                    if x+pattern_list>7 or y+row>7:
                                        print("The move is outside the board")
                                        self.board._data=prev_data
                                        return
                                    if self.board._data[x+pattern_list][y+row]=="X":
                                        print("Life cells can't overlap!")
                                        self.board._data=prev_data
                                        return
                                    else:
                                        self.board._data[x+pattern_list][y+row]=patterns[type_of_pattern+1][pattern_list][row]
                                if patterns[type_of_pattern+1][pattern_list][row] == "+":
                                    if x+pattern_list>7 or y+row>7:
                                        print("The move is outside the board")
                                        self.board._data = prev_data
                                        return
                                    if self.board._data[x+pattern_list][y+row] == "X":
                                        print("Life cells can't overlap!")
                                        self.board._data=prev_data
                                        return
                                    self.board._data[x+pattern_list][y+row] = " "
            else:
                print("Invalid pattern")
        else:
            print("Enter a parameter that is not an integer")

    def save(self, file_name):
        self.board.write_to_file(file_name)