n = int(input("Choose a number= "))
x=[0]*n

def print_solution():
    for i in range(0,n):
        print(x[i], end="")
    print('\n')

def solution(k):
    return k+1==n#checking if the list is full

def check_existence(k):
    if x[k]<9:#checking if the current level is below the number of possible digits
        return True
    return False

def is_consistent(k):
    if x[0]==0:
        return 0
    for l in range(1, int(n/2)+1): #this loop checks whether the subsequences of lenght l are identical and neighbours
        for z in range(0, (k-l)+1):
            if x[z]==x[z+l]: #if there are two identical digits at the z+l position
                j=z
                while j<k-l+1 and x[j]==x[j+l]: #j increases while the digit at the j pos is identical to the one at j+l pos
                    j=j+1
                if j-z>=l:
                    return 0
    return 1

def back_it(n):
    k=0
    x[k]=-1 #initialising the level
    while k>=0:
        if check_existence(k):
            x[k]=x[k]+1
            if is_consistent(k): #if the sequence is valid
                if solution(k):
                    print_solution()
                else:
                    k=k+1 #if the solution is incorrect, it goes to the next level in the list
                    x[k]=-1
        else:
            k=k-1

back_it(n)
