from a5 import create_dictionary
from a5 import set_real_and_img
from a5 import get_real_from_index
from a5 import get_img_from_index
from a5 import get_real
from a5 import get_img
from a5 import modulus
from a5 import convert_to_string
from a5 import display_list
from a5 import property_one_list
from a5 import property_one_dict
from a5 import property_two_list
from a5 import property_two_dict

def create_new_dictionary(n):
    list_real = []
    list_imag = []
    for i in range(n):
        r = input("Real part of number " + str(i + 1) + ": ")
        im = input(("Imaginary part of number " + str(i + 1) + ": "))
        r = float(r)
        if int(r) == r:
            r = int(r)
        im = float(im)
        if int(im) == im:
            im = int(im)
        list_real.append(r)
        list_imag.append(im)
    dictionary = {"real part": list_real, "imaginary part": list_imag}
    return dictionary


def read_list(n):
    l2 = []
    for i in range(n):
        real_part = input("Real part of number " + str(i + 1) + ": ")
        try:
            real_part = float(real_part)
        except:
            return
        imag_part = input("Imaginary part of number " + str(i + 1) + ": ")
        try:
            imag_part = float(imag_part)
        except:
            return
        x = complex(real_part, imag_part)
        l2.append(x)
    return l2

def display_dictionary(dictionary):
    l1 = [complex(3, 5), complex(0, 11.23), complex(1, 15), complex(3, 5), complex(10, -13), complex(1, -2.22),complex(-3, -7), complex(2, 1.87), complex(-4, 9), complex(1.25, 8)]
    for i in range(len(l1)):
        print(dictionary["real part"][i], "+", dictionary["imaginary part"][i], "i", " ", end=" ")

def display_initial_list(l1):
    for i in range(len(l1)):
        print(l1[i], end=" ")

def start():
    lenght = 0
    l1 = [complex(3, 5), complex(0, 11.23), complex(1, 15), complex(3, 5), complex(10, -13),
          complex(1, -2.22), complex(-3, -7), complex(2, 1.87), complex(-4, 9), complex(1.25, 8)]
    prev_list = []
    prev_dict = []
    prev_list.append(l1)
    dictionary = create_dictionary(l1)
    prev_dict.append(dictionary)
    ok = 0
    while True:
        menu()
        option = input("Choose an option= ")
        if option == "1":
            n = int(input("Enter a number of complex numbers to insert: "))
            if n != 0:
                gen_list = read_list(n)
                print("The list is: ", gen_list)
                prev_list.append(gen_list)
                dictionary = create_dictionary(gen_list)
                print("The dictionary is: ", dictionary)
                prev_dict.append(dictionary)
                lenght = 1
            elif lenght == 0:
                print("The list is: ", display_initial_list(l1))
                print('\n')
                dictionary = create_dictionary(l1)
                print("The dictionary is: ", dictionary)
            else:
                print("Invalid command")
        elif option == "2":
            if lenght == 1:
                l1 = prev_list[-1]
                print("The list is: ", end=" ")
                display_list(l1)
                print("The dictionary is: ", prev_dict[-1])
            elif lenght == 0:
                print("The list is: ", end=" ")
                display_initial_list(l1)
                print('\n')
                dictionary = create_dictionary(l1)
                print("The dictionary is: ", end=" ")
                display_dictionary(dictionary)
                print('\n')
            else:
                print("Invalid command")
        elif option == "3.1":
            if lenght == 1:
                l1 = prev_list[-1]
                print("The lenght and the subarray of the list are: ", property_one_list(l1))
                print('\n')
                dictionary = prev_dict[-1]
                print("The lenght and the subarray of the dictionary are: ", property_one_dict(dictionary))
                print('\n')
            elif lenght == 0:
                print("The lenght and the subarray of the list are: ", property_one_list(l1))
                print('\n')
                dictionary = create_dictionary(l1)
                print("The lenght and the subarray of the dictionary are: ", property_one_dict(dictionary))
            else:
                print("Invalid command")
        elif option == "3.2":
            if lenght == 1:
                l1 = prev_list[-1]
                print("The lenght and the subsequence of the list are: ", property_two_list(l1))
                print('\n')
                dictionary = prev_dict[-1]
                print("The lenght and the subsequence of the dictionary are: ", property_two_dict(dictionary))
                print('\n')
            elif lenght == 0:
                print("The lenght and the subsequence of the list are: ", property_two_list(l1))
                print('\n')
                complex_dictionary = create_dictionary(l1)
                print("The lenght and the subsequence of the dictionary are: ", property_two_dict(complex_dictionary))
            else:
                print("Invalid command")
        elif option == "4":
            return
        else:
            print("Invalid command")
            return


def menu():
    print("1. Read a list of complex numbers")
    print("2. Display the list")
    print("3.1. Display the lenght and elements of a longest subarray of numbers having increasing modulus")
    print("3.2. Display the lenght and elements of a longest increasing subsequence, when considering each number's real part")
    print("4. Exit the program")

start()
