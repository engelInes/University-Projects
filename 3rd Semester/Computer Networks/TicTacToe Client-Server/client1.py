import socket, struct, sys, pickle

matrix = [
    [" ", " ", " "],
    [" ", " ", " "],
    [" ", " ", " "]
]


def print_board(current_board):
    print("-------")
    for i in range(3):
        print("|", end='')
        for j in range(3):
            if j < 2:
                print(current_board[i][j], end='|')
            elif j == 2:
                print(current_board[i][j], end='|\n')
    print("-------")


def check_winner(board, symbol):
    for row in board:
        if row[0] == row[1] == row[2] and row[0] != " ":
            return 1 if row[0] == symbol else 2

    for col in range(3):
        if board[0][col] == board[1][col] == board[2][col] and board[0][col] != " ":
            return 1 if board[0][col] == symbol else 2

    if board[0][0] == board[1][1] == board[2][2] and board[0][0] != " ":
        return 1 if board[0][0] == symbol else 2

    if board[0][2] == board[1][1] == board[2][0] and board[0][2] != " ":
        return 1 if board[0][2] == symbol else 2

    if all(cell != " " for row in board for cell in row):
        return -1

    return 0


if __name__ == "__main__":
    socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    socket.connect(("127.0.0.1", 7777))

    welcome_msg = socket.recv(1024).decode('utf-8')
    print(welcome_msg)

    wins = 0
    finished = False
    client_won = 0
    while not finished:

        wins_data = socket.recv(4)
        wins = struct.unpack("!I", wins_data)[0]

        print(f"WINS: {wins}")

        matrix_data = socket.recv(1024)
        matrix = pickle.loads(matrix_data)

        client_won = check_winner(matrix, "0")
        if client_won == 1:
            print("you won")
        elif client_won == 2:
            print("you lost")
        elif client_won == -1:
            print("tie")

        print("this is your matrix: ")
        print_board(matrix)

        a = 3
        b = 3
        while (a not in [0, 1, 2] or b not in [0, 1, 2]) or matrix[a][b] != " ":
            a = int(input("give coordinate x: "))
            b = int(input("give coordinate y: "))

        if client_won == 1:
            print("you won")
        elif client_won == 2:
            print("you lost")
        elif client_won == -1:
            print("tie")

        socket.send(struct.pack('!I', a))
        socket.send(struct.pack('!I', b))