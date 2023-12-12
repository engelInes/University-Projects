from src.Domain.domain import Board
import random

class Repo:
    def __init__(self, board, file_name):
        self._file_name=file_name
        self._board=board

    def place_human(self, row, col, value):
        if row > 3:
            raise Exception("Invalid row")
        if col > 3:
            raise Exception("Invalid column")
        row=row-1
        col=col-1
        #if self._computer_pieces<4:
        if self._board._data[row][col]!=" ":
            raise Exception("The square is already occupied")
        else:
            self._board._data[row][col]=value

    def place_computer(self,value):
        possible_squares=[]
        for i in range(3):
            for j in range(3):
                if self._board._data[i][j]==" ":
                    possible_squares.append([i, j])
        rand_place=random.choice(possible_squares)
        row=rand_place[0]
        col=rand_place[1]
        self._board._data[row][col]=value


    def check_win(self, value):
        win=0
        for i in range(0,3):
            for j in range(0,3):
                if i==0 and j==0:
                    if self._board._data[i][j]==self._board._data[i+1][j+1]==self._board._data[i+2][j+2]==value:
                        win=1
                        break
                    if self._board._data[i+1][j]==self._board._data[i+2][j]==self._board._data[i][j]==value:
                        win=1
                        break
                    if self._board._data[i][j]==self._board._data[i][j+1]==self._board._data[i][j+2]==value:
                        win=1
                        break
                elif i==0:
                    if j==1:
                        if self._board._data[i][j] == self._board._data[i + 1][j] == self._board._data[i + 2][j]==value:
                            win = 1
                            break
                        if self._board._data[i][j-1]==self._board._data[i][j]==self._board._data[i][j+1]==value:
                            win=1
                            break
                    else:
                        if self._board._data[i][j]==self._board._data[i+1][j-1]==self._board._data[i+2][j-2]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i][j-1]==self._board._data[i][j-2]==value:
                            win=1
                            break
                elif i==1:
                    if j==0:
                        if self._board._data[i][j]==self._board._data[i][j+1]==self._board._data[i][j+2]==value:
                            win=1
                            break
                        if self._board._data[i-1][j]==self._board._data[i][j]==self._board[i+1][j]==value:
                            win=1
                            break
                    if j==1:
                        if self._board._data[i][j]==self._board._data[i-1][j-1]==self._board._data[i+1][j+1]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i-1][j+1]==self._board._data[i+1][j-1]==value:
                            win=1
                            break
                        if self._board._data[i-1][j]==self._board._data[i][j]==self._board._data[i+1][j]==value:
                            win=1
                            break
                        if self._board._data[i][j-1]==self._board._data[i][j]==self._board._data[i][j+1]==value:
                            win=1
                            break
                    else:
                        if self._board._data[i][j]==self._board._data[i-1][j]==self._board._data[i+1][j]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i][j-1]==self._board._data[i][j-2]==value:
                            win=1
                            break
                else:
                    if j==0:
                        if self._board._data[i][j]==self._board._data[i-1][j]==self._board._data[i-2][j]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i][j+1]==self._board._data[i][j+2]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i-1][j+1]==self._board._data[i-2][j+2]==value:
                            win=1
                            break
                    elif j==1:
                        if self._board._data[i][j]==self._board._data[i][j-1]==self._board._data[i][j+1]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i-1][j]==self._board._data[i-2][j]==value:
                            win=1
                            break
                    else:
                        if self._board._data[i][j]==self._board._data[i][j-1]==self._board._data[i][j-2]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i-1][j]==self._board._data[i-2][j]==value:
                            win=1
                            break
                        if self._board._data[i][j]==self._board._data[i-1][j-1]==self._board._data[i-2][j-2]==value:
                            win=1
                            break
        return win


    def check_movement(self, row, col):
        #row col where is the symbol
        row=row-1
        col=col-1
        can_move=1
        if row==0 and col==0:
            if self._board._data[row+1][col]==" ":
                self._board._data[row+1][col]=self._board._data[row][col]
            elif self._board._data[row+1][col+1]==" ":
                self._board._data[row + 1][col + 1]=self._board._data[row][col]
            elif self._board._data[row][col+1]==" ":
                self._board._data[row][col + 1] =self._board._data[row][col]
            else:
                can_move=0
        elif row==0:
            if col==1:
                if self._board._data[row][col-1]==" ":
                    self._board._data[row][col-1]=self._board._data[row][col]
                elif self._board._data[row+1][col-1]==" ":
                    self._board._data[row + 1][col - 1] =self._board._data[row][col]
                elif self._board._data[row+1][col]==" ":
                    self._board._data[row + 1][col] =self._board._data[row][col]
                elif self._board._data[row+1][col+1]==" ":
                    self._board._data[row+1][col+1]=self._board._data[row][col]
                elif self._board._data[row][col+1]==" ":
                    self._board._data[row][col + 1] =self._board._data[row][col]
            else:
                if self._board._data[row][col-1]==" ":
                    self._board._data[row][col-1]=self._board._data[row][col]
                elif self._board._data[row+1][col]==" ":
                    self._board._data[row+1][col]=self._board._data[row][col]
        elif row==1:
            pass
        else:
            pass
        return can_move


    def computer_move(self, value):
        possible_squares = []
        for i in range(3):
            for j in range(3):
                if self._board._data[i][j] == " ":
                    possible_squares.append([i, j])
        rand_place = random.choice(possible_squares)
        row = rand_place[0]
        col = rand_place[1]
        self._board._data[row][col] = value

    def player_move(self, row, col, value):
        row=row-1
        col=col-1
        self._board._data[row][col]=value

    def save(self, file_name):
        self._board.write_to_file(file_name)

    def read_from_file(self, file_name):
        with open(file_name, 'r') as f:
            lines=f.readlines()
            i=0
            for line in lines:
                for j in range(3):
                    if line[j]=="+":
                        self._board._data[i][j]=" "
                    elif line[j] == "X":
                        self._board._data[i][j]="X"
                    elif line[j]=="O":
                        self._board._data[i][j]="O"
                i=i+1
        f.close()

    def write_to_file(self, file_name):
        with open(file_name, "w") as f:
            for line in self._board._data:
                for i in line:
                    if i==" ":
                        f.write("+")
                    else:
                        f.write(i)
                f.write("\n")
        f.close()


# if __name__=="__main__":
#     b=Board(3,3)
#     repo=Repo(b)
#     repo.place_human(2,1,"X")
#     print(b)
#     repo.place_computer("O")
#     print(b)
#     repo.computer_move("O")
#     print(b)
#     repo.player_move(1,1, "X")
#     print(b)