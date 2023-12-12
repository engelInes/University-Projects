from texttable import Texttable

class Board:
    def __init__(self, row, col):
        self._row=row
        self._col=col
        self._data=[[" " for j in range(self._row)] for i in range(self._col)]

    def row_repr(self, row:list):
        result=[]
        for symbol in row:
            if symbol is None:
                result.append(" ")
            else:
                result.append(symbol)
        return result

    def __str__(self):
        board=Texttable()
        for i in range(3):
            new_row=[]
            for j in range(3):
                new_row.append(self._data[i][j])
            board.add_row(new_row)

        # board.add_row([1]+self.row_repr(self._data[0]))
        # for i in range(3):
        #     board.add_row([2+i]+self.row_repr(self._data[i+1]))
        return board.draw()
    # def move(self, row, col, value):
    #     self._data[row][col]=value

if __name__=="__main__":
    b=Board(3,3)
    print(b)
    #b.move(1,2,"x")
    #print(b)


