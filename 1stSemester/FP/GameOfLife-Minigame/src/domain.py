from copy import deepcopy
from texttable import Texttable

class Board:

    def __init__(self):
        self._data=[[" " for j in range(8)] for i in range(8)]

    def modify_board(self):
        copy=deepcopy(self._data)

        for i in range(8):
            for j in range(8):
                number_alive=0
                number_dead=0

                if i-1>=0 and j-1>=0:
                    if copy[i-1][j-1]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if i-1>=0:
                    if copy[i-1][j]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if j-1>=0:
                    if copy[i][j-1]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if i+1<8 and j+1<8:
                    if copy[i+1][j+1]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if i+1<8:
                    if copy[i+1][j]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if j+1<8:
                    if copy[i][j+1]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if i-1>=0 and j+1<8:
                    if copy[i-1][j+1]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if i+1<8 and j-1>=0:
                    if copy[i+1][j-1]=="X":
                        number_alive= number_alive+1
                    else:
                        number_dead=number_dead+1

                if copy[i][j]=="X":#a cell with more than 3 neighbours dies
                    if number_alive>3 or number_alive<2:
                        self._data[i][j]=" "

                if copy[i][j]==" ":#reproduction
                    if number_alive==3:
                        self._data[i][j]="X"

    def read_from_file(self, file_name):
        with open(file_name, 'r') as f:
            lines=f.readlines()
            i=0
            for line in lines:
                for j in range(8):
                    if line[j]=="+":
                        self._data[i][j]=" "
                    elif line[j] == "X":
                        self._data[i][j]="X"
                i=i+1
        f.close()

    def write_to_file(self, file_name):
        with open(file_name, "w") as f:
            for line in self._data:
                for i in line:
                    if i==" ":
                        f.write("+")
                    else:
                        f.write(i)
                f.write("\n")
        f.close()

    def read_pattern(self, file_name):
        patterns=[]

        with open(file_name, "r") as f:
            lines=f.readlines()
            new_lines=[]
            for line in lines:
                newline=line.strip()
                new_lines.append(newline)
            lines=new_lines

            #for each pattern we create a list consisting of the name of the pattern followed by its representation
            for i in range(len(lines)):
                if lines[i]=="block":
                    block_list=[]
                    line=[lines[i+1][0],lines[i+1][1]]
                    block_list.append(line)
                    line=[lines[i+2][0], lines[i+2][1]]
                    block_list.append(line)
                    patterns.append("block")
                    patterns.append(block_list)

                if lines[i]=="tub":
                    tub_list=[]
                    line=[lines[i+1][0], lines[i+1][1], lines[i+1][2]]
                    tub_list.append(line)
                    line = [lines[i+2][0], lines[i+2][1], lines[i+2][2]]
                    tub_list.append(line)
                    line = [lines[i+3][0], lines[i+3][1], lines[i+3][2]]
                    tub_list.append(line)
                    patterns.append("tub")
                    patterns.append(tub_list)

                if lines[i]=="blinker":
                    blinker_list=[]
                    line=[lines[i+1][0], lines[i+1][1], lines[i+1][2]]
                    blinker_list.append(line)
                    line=[lines[i+2][0], lines[i+2][1], lines[i+2][2]]
                    blinker_list.append(line)
                    line=[lines[i+3][0], lines[i+3][1], lines[i+3][2]]
                    blinker_list.append(line)
                    patterns.append("blinker")
                    patterns.append(blinker_list)

                if lines[i] == "beacon":
                    beacon_list=[]
                    line=[lines[i+1][0], lines[i+1][1], lines[i+1][2],lines[i+1][3]]
                    beacon_list.append(line)
                    line=[lines[i+2][0], lines[i+2][1], lines[i+2][2], lines[i+2][3]]
                    beacon_list.append(line)
                    line=[lines[i+3][0], lines[i+3][1], lines[i+3][2], lines[i+3][3]]
                    beacon_list.append(line)
                    line=[lines[i+4][0], lines[i+4][1], lines[i+4][2], lines[i+4][3]]
                    beacon_list.append(line)
                    patterns.append("beacon")
                    patterns.append(beacon_list)

                if lines[i] == "spaceship":
                    spaceship_list=[]
                    line=[lines[i+1][0], lines[i+1][1], lines[i+1][2], lines[i+1][3]]
                    spaceship_list.append(line)
                    line=[lines[i+2][0], lines[i+2][1], lines[i+2][2], lines[i+2][3]]
                    spaceship_list.append(line)
                    line=[lines[i+3][0], lines[i+3][1], lines[i+3][2], lines[i+3][3]]
                    spaceship_list.append(line)
                    line=[lines[i+4][0], lines[i+4][1], lines[i+4][2], lines[i+4][3]]
                    spaceship_list.append(line)
                    patterns.append("spaceship")
                    patterns.append(spaceship_list)
        f.close()
        return patterns

    def _row_repr(self, row:list):
        result=[]
        for symbol in row:
            if symbol is None:
                result.append(" ")
            else:
                result.append(symbol)
        return result

    def __str__(self):
        board=Texttable()
        board.header(["/"]+list(range(1, 9)))
        board.add_row([1]+self._row_repr(self._data[0]))
        for i in range(7):
            board.add_row([2+i]+self._row_repr(self._data[i+1]))
        return board.draw()


