
set1=[]

def sum(set1):
    '''

    :param set1: a set of integers
    :return: the sum of the elements of the given set
    '''
    s=0
    for i in range(len(set1)):
        s=s+set1[i]
    return s

n=int(input("Enter a lenght: "))

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

def equal_partitions(set1, n):
    '''
    :param set1: the set of integer elements
    :param n: the number of the elements of the set
    :return: the function will display 2 partitions that have the same sum if the sum of
    the elements of the set is an even number, otherwise it will display an appropriate message
    '''
    sum_of_elements=sum(set1)
    if check_list(sum_of_elements)==True:
        print("The set cannot be partitioned into 2 subsets with equal sum")
        return

    k=sum_of_elements//2
    #creating a boolean table with a matrix

    matrix=[[0 for i in range(k+1)]for j in range(n+1)]

    #there cannot be any sum if the number of elements is zero
    for i in range(1, k+1):
        matrix[0][i]=False

    #the sum equal to 0 can be obtained without any element
    for i in range(n+1):
        matrix[i][0]=True

    for i in range(1, n+1):
        for j in range (1, k+1):
            matrix[i][j]=matrix[i-1][j]
            if set1[i-1]<=j:#if the element is less than the current sum it will be included
                matrix[i][j]=(matrix[i][j] or matrix[i-1][j-set1[i-1]])

    partition1=[]#the 1st possible partition
    partition2=[]#the 2nd possible partition

    if matrix[n][k]==0:
        print("The set cannot be partitioned into two subsets with equal sum")
        return

    i=n
    j=k
    #going backwards
    while i>0 and j>=0:
        #checking whether the current element belongs to the partition 1 or 2
        if matrix[i-1][j]:
            i=i-1
            partition2.append(set1[i])
        elif matrix[i-1][j-set1[i-1]]:
            i=i-1
            j=j-set1[i]
            partition1.append(set1[i])

    print("The set can be partitoned into 2 subsets, ")
    for i in range(len(partition1)):
        print(partition1[i], end=" ")
    print("\nand ")
    for i in range(len(partition2)):
        print(partition2[i], end=" ")

create_list(set1)
equal_partitions(set1,n)


