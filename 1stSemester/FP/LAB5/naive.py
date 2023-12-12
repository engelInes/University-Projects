set1=[]
can_be_partitioned=0

def sum(set1):
    '''

    :param set1: a set of integers
    :return: the sum of the elements of the given set (list)
    '''
    s=0
    for i in range(len(set1)):
        s=s+set1[i]
    return s

n=int(input("Enter a lenght: "))
is_included=[0]*(n+1)

def create_list(set1):
    '''

    :param set1: the set where the elements given will belong to
    :return: a set containing n elements
    '''
    for i in range(0,n):
        element=int(input())
        set1.append(element)

def check_list(sum_of_elements):
    '''

    :param sum_of_elements: the sum of the elements from the set
    :return: the function checks whether the sum of the elements is an odd number or not
    '''
    return sum_of_elements%2==1

def partition1():
    '''

    :return: the call of this function will display the firts partition which has the sum of sum_of_elements//2
    '''
    for i in range(0,n):
        if is_included[i]==1:
            print(set1[i] , " ", end="")

def partition2():
    '''

    :return: the call of this function will display the second partition that has the sum of sum_of_elements//2
    '''
    for i in range(0,n):
        if is_included[i]==0:
            print(set1[i] , " ", end="")

def recursive_solution(set1, index, sum_of_elements):
    '''

    :param set1: the set (list) of integer elements
    :param index: the position from which the algorithm will traverse the list recursively
    :param sum_of_elements: the sum of the elements of the set1
    :return: the function will return True if the set can be partitioned into 2 subsets with
    equal sum
    '''
    global can_be_partitioned
    if index>=0 and can_be_partitioned==0:
        if sum_of_elements==0:# 2 partitions have been formed
            can_be_partitioned=1
            return True
        if sum_of_elements<0:
            return False
        is_included[index] = 1 #the index will be marked as included in the 1st partition
        include_index= recursive_solution(set1, index-1, sum_of_elements-set1[index])
        if(can_be_partitioned==0):
            is_included[index] = 0
            not_include_index=recursive_solution(set1, index-1, sum_of_elements)
        return include_index or not_include_index
    return False

create_list(set1)
sum_of_elements=sum(set1)

if check_list(sum_of_elements)==True:
    print("The set cannot be partitioned into 2 subsets with equal sum")
else:
    sum_of_elements = sum_of_elements // 2
    print(recursive_solution(set1, n-1, sum_of_elements))
    print("The set can be partitioned into the subsets ")
    partition1()
    print('\nand')
    partition2()



