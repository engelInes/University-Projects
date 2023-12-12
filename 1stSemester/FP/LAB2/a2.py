import random
def number(n):
    randomList=random.sample(range(0,100),n)
    return randomList

#sort 1
def merge_list(x,y):
    l2=[]
    while len(x) and len(y):
        if x[0]<y[0]:
            l2.append(x.pop(0))
        else:
            l2.append(y.pop(0))
    l2=l2+x
    l2=l2+y
    return l2

def strand(l1):
    i, e=0, [l1.pop(0)]
    while i< len(l1):
        if l1[i]>e[-1]:
            e.append(l1.pop(i))
        else:
            i=i+1
    return e

def strand_sort(l1,steps):
    list2=strand(l1)
    cnt=0
    while len(l1):
        list2=merge_list(list2,strand(l1))
        cnt=cnt+1
        if cnt==steps:
            print(list2)
            cnt=0
    return list2
#sort 2
def selection_sort(l1,steps):
    cnt=0
    i=0
    for i in range(len(l1)):
        min_ind_val=i
        for j in range(i+1,len(l1)):
            if l1[j]<l1[min_ind_val]:
                min_ind_val=j
        l1[i],l1[min_ind_val]=l1[min_ind_val],l1[i]
        cnt=cnt+1
        if cnt==steps:
            print(l1)
            cnt=0


def print_options():
    print("1. Enter a number n and generate n numbers from [0,100]")
    print("2. Sort the generated numbers using Strand Sort")
    print("3. Sort the generated numbers using Selection Sort")
    print("0. Exit the program")

def run_menu():
    print_options()
    while True:
        option=input("Option= ")
        if option=="1":
            n=int(input("Choose a number: "))
            l1 = number(n)
            print("The initial list is:", l1)
            break
        elif option=="2":
            n = int(input("Choose a number: "))
            l1 = number(n)
            steps=int(input("Choose a number of steps: "))
            print("The sorted list is:", strand_sort(l1,steps))
            break
        elif option=="3":
            n = int(input("Choose a number: "))
            l1 = number(n)
            steps=int(input("Choose a number of steps: "))
            print("The sorted list is:", selection_sort(l1,steps))
            break
        elif option=="0":
            break
        else:
            print("Invalid command")
            break

print(run_menu())
