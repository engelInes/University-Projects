import random
from timeit import default_timer as timer

def num(n):
    randomList = random.sample(range(0, 100), n)
    return randomList

def num2(n):
    randomList = random.choices(range(0, 100), k=n)
    return randomList

# sort 1
def merge_list(x, y):
    l2 = []
    while len(x) and len(y):
        if x[0] < y[0]:
            l2.append(x.pop(0))
        else:
            l2.append(y.pop(0))
    l2 = l2 + x
    l2 = l2 + y
    return l2


def strand(l1):
    i, e = 0, [l1.pop(0)]
    while i < len(l1):
        if l1[i] > e[-1]:
            e.append(l1.pop(i))
        else:
            i = i + 1
    return e


def strand_sort(l1 ,steps):
    list2 = strand(l1)
    cnt=0
    while len(l1):
        list2 = merge_list(list2, strand(l1))
        cnt=cnt+1
        if cnt==steps:
            print(list2)
            cnt=0
    return list2

def strand_sort_runtimes(l1):
    list2 = strand(l1)
    while len(l1):
        list2 = merge_list(list2, strand(l1))
    return list2

# sort 2
def selection_sort(l1, steps):
    cnt=0
    i = 0
    for i in range(len(l1)):
        min_ind_val = i
        for j in range(i + 1, len(l1)):
            if l1[j] < l1[min_ind_val]:
                min_ind_val = j
        l1[i], l1[min_ind_val] = l1[min_ind_val], l1[i]
        cnt=cnt+1
        if cnt==steps:
            print(l1)
            cnt=0
    return l1

def selection_sort_runtimes(l1):
    i = 0
    for i in range(len(l1)):
        min_ind_val = i
        for j in range(i + 1, len(l1)):
            if l1[j] < l1[min_ind_val]:
                min_ind_val = j
        l1[i], l1[min_ind_val] = l1[min_ind_val], l1[i]
    return l1

def reversed_list(l1):
    list_reversed=[]
    for i in l1:
        list_reversed=[i]+list_reversed
    return list_reversed

def print_options():
    print("1. Enter a number n and generate n numbers from [0,100]")
    print("2. Sort the generated numbers using Strand Sort")
    print("3. Sort the generated numbers using Selection Sort")
    print("4. Test runtimes for the best case of the sorting algorithms")
    print("5. Test runtimes for the average case of the sorting algorithms")
    print("6. Test runtimes for the worst case of the sorting algorithms")
    print("0. Exit the program")


def run_menu():
    ok = 0
    while True:
        print_options()
        option = input("Option= ")
        if option == "1":
            n = int(input("Choose a number: "))
            l1 = num(n)
            print("The initial list is:", l1)
            ok = 1
        elif ok == 1:
            if option == "2":
                steps=int(input("Choose a number of steps: "))
                print("The sorted list is:", strand_sort(l1 ,steps))
            elif option == "3":
                steps=int(input("Choose a number of steps: "))
                print("The sorted list is:", selection_sort(l1 ,steps))
            elif option == "4":
                sort_method = input("Choose a sorting method: ")
                if sort_method == "Selection Sort":
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered=sorted(l3)
                        #print (l3_ordered)
                        start = timer()
                        selection_sort_runtimes(l3_ordered)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
                else:
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered = sorted(l3)
                        start = timer()
                        strand_sort_runtimes(l3_ordered)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
            elif option == "5":
                sort_method = input("Choose a sorting method: ")
                if sort_method == "Selection Sort":
                    lenght= int(input("Choose a lenght: "))
                    for i in range(0,5):
                        l3=num2(lenght)
                        start = timer()
                        selection_sort_runtimes(l3)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:",end - start)
                        lenght=lenght*2
                else:
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        start = timer()
                        strand_sort_runtimes(l3)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
            elif option == "6":
                sort_method = input("Choose a sorting method: ")
                if sort_method == "Selection Sort":
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered = sorted(l3)
                        l3_reversed= reversed_list(l3_ordered)
                        # print (l3_ordered)
                        start = timer()
                        selection_sort_runtimes(l3_reversed)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
                else:
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered = sorted(l3)
                        l3_reversed= reversed_list(l3_ordered)
                        start = timer()
                        strand_sort_runtimes(l3_reversed)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2

            elif option == "0":
                print("Program finished")
                break
        else:
            if option == "2":
                print("The list is empty")
            elif option == "3":
                print("The list is empty")
            elif option == "4":
                sort_method = input("Choose a sorting method: ")
                if sort_method == "Selection Sort":
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered=sorted(l3)
                        #print (l3_ordered)
                        start = timer()
                        selection_sort_runtimes(l3_ordered)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
                else:
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered = sorted(l3)
                        start = timer()
                        strand_sort_runtimes(l3_ordered)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
            elif option == "5":
                sort_method = input("Choose a sorting method: ")
                if sort_method == "Selection Sort":
                    lenght= int(input("Choose a lenght: "))
                    for i in range(0,5):
                        l3=num2(lenght)
                        start = timer()
                        selection_sort_runtimes(l3)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:",end - start)
                        lenght=lenght*2
                else:
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        start = timer()
                        strand_sort_runtimes(l3)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
            elif option == "6":
                sort_method = input("Choose a sorting method: ")
                if sort_method == "Selection Sort":
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered = sorted(l3)
                        l3_reversed= reversed_list(l3_ordered)
                        # print (l3_ordered)
                        start = timer()
                        selection_sort_runtimes(l3_reversed)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
                else:
                    lenght = int(input("Choose a lenght: "))
                    for i in range(0, 5):
                        l3 = num2(lenght)
                        l3_ordered = sorted(l3)
                        l3_reversed= reversed_list(l3_ordered)
                        start = timer()
                        strand_sort_runtimes(l3_reversed)
                        end = timer()
                        print("List lenght:", lenght, "Sort duration:", end - start)
                        lenght = lenght * 2
            elif option == "0":
                print("Program finished")
                break

run_menu()

