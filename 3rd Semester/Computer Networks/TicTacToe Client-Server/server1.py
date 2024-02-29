import socket, struct, sys, threading, pickle

lock_thread = threading.Lock()

client_won = 0
client_count = 0

matrix = [
    [" ", " ", " "],
    [" ", " ", " "],
    [" ", " ", " "]
]


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


def run_program(client_socket1, client_socket2):
    global client_won, client_count, matrix

    message1 = 'Hello client #1! welcome to the game !'
    client_socket1.sendall(bytes(message1, 'ascii'))

    message2 = 'Hello client #2! welcome to the game !'
    client_socket2.sendall(bytes(message2, 'ascii'))

    client1_winner = 0
    client2_winner = 0
    client1_loser = 0
    client2_loser = 0
    ties = 0

    client1_won = -10
    client2_won = -10
    finished = False
    turn = 1
    while not finished:

        print_board(matrix)

        if turn == 1:
            client_socket1.send(struct.pack("!I", client1_winner))

            matrix_data = pickle.dumps(matrix)
            client_socket1.send(matrix_data)

            a_data = client_socket1.recv(4)
            a = struct.unpack('!I', a_data)[0]

            b_data = client_socket1.recv(4)
            b = struct.unpack('!I', b_data)[0]

            matrix[a][b] = "0"

            client1_won = check_winner(matrix, "0")
            if client1_won == 1:
                print(f"player #1 has won!")
                client1_winner += 1
                reset_game()
            elif client1_won == 2:
                print("player #1 has lost")
                client1_loser += 1
                reset_game()
            elif client1_won == -1:
                print("tie")
                ties += 1
                reset_game()


        elif turn == 2:

            client_socket2.send(struct.pack("!I", client2_winner))

            matrix_data = pickle.dumps(matrix)
            client_socket2.send(matrix_data)

            a_data = client_socket2.recv(4)
            a = struct.unpack('!I', a_data)[0]

            b_data = client_socket2.recv(4)
            b = struct.unpack('!I', b_data)[0]

            matrix[a][b] = "X"

            client2_won = check_winner(matrix, "X")
            if client2_won == 1:
                print(f"player #2 has won!")
                client2_winner += 1
                reset_game()
            elif client2_won == 2:
                print("player #2 has lost")
                client2_loser += 1
                reset_game()
            elif client2_won == -1:
                print("tie")
                ties += 1
                reset_game()

        if turn == 1:
            turn = 2
        elif turn == 2:
            turn = 1


def reset_game():
    global matrix
    matrix = [3 * [" "] for row in range(3)]


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


if __name__ == "__main__":
    print_board(matrix)

    main_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    main_socket.bind(('0.0.0.0', 7777))
    main_socket.listen(4)

    current_player = 0

    print("waiting for 2 clients to connect...")

    client_socket1, client_address1 = main_socket.accept()
    print("First client connected to the server with: ")

    client_socket2, client_address2 = main_socket.accept()
    print("Second client connected to the server with: ")

    run_program(client_socket1, client_socket2)