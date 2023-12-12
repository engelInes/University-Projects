#from Start import *
from datetime import date
import operator

def create_dict(day,value,type,description):
    return{"day":day,"value":value,"type":type,"description":description}

def create_stack(stack,l1):
    stack.append(l1)
    return stack

def get_day(transactions_list):
    return transactions_list["day"]

def get_amount(transactions_list):
    return transactions_list["amount"]

def get_value(transactions_list):
    return transactions_list["value"]

def get_description(transactions_list):
    return transactions_list["description"]

def set_day(transactions_list,day):
    transactions_list["day"]=day
    return transactions_list["day"]

def set_value(transactions_list,value):
    transactions_list["value"]=value
    return transactions_list["value"]

def set_type(transactions_list,type):
    transactions_list["type"]=type
    return transactions_list["type"]

def set_description(transactions_list,description):
    transactions_list["description"]=description
    return transactions_list["description"]

#A
def add_trans(day, value, type, description, l1):
    '''

    :param value: a positive integer representing the value that needs to be added into the account
    :param type: a string representing the type of the transaction: in the account or out from the account
    :param description: a string that contains a detail regarding the transaction
    :param transactions: the list of dictionaries storing the transactions
    :return: the function returns the list with the transfer update
    '''
    transaction=create_dict(day ,value,type,description)
    l1.append(transaction)
    return l1

def test_add():
    return add_trans(date.today().day,1340,"out","cola",[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}]


def insert_trans(day, value, type, description, l1):
    '''

    :param day: a positive integer between 1 and 30 that is the day to which the transaction must be added
    :param value: a positive integer representing the value that needs to be added into the account
    :param type: the type of the transaction: in the account or out from the account
    :param description: a string that contains a detail regarding the transaction
    :param transactions: the list of dictionaries storing the transactions
    :return: the function returns the list with the transfer update
    '''

    l1.append(create_dict(day,value,type,description))
    return l1

def test_insert():
    return insert_trans(3,360,"out","books",[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}] and (add_trans(5,1340,"out","cola",[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])

#B
def remove_day(day, l1):
    '''

    :param day: a positive integer which represents the day from which the transactions will be deleted
    :param transactions: the list of dictionaries storing the transactions
    :return: the function returns the modified list
    '''
    n = len(l1)
    i = 0
    while i < n:
        if day == get_day(l1[i]):
            del l1[i]
            n=n-1
        else:
            i=i+1
    return l1

def test_remove_day():
    return remove_day(13,[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}]

def remove_from_interval(start_day, end_day, l1):
    '''

    :param start_day: a positive integer representing the day from which the transactions will be removed
    :param end_day: a positive integer representing the day where removal of the transactions will stop
    :param transactions: the list of dictionaries storing the transactions
    :return: the function returns the list with deleted transactions between the starting day and the ending day
    '''
    l1.sort(key=operator.itemgetter("day"))
    n = len(l1)
    i = 0
    while i < n:
        if get_day(l1[i]) >= start_day and get_day(l1[i]) <= end_day:
            del l1[i]
            n -= 1
        else:
            i += 1
    return l1

def test_remove_from_interval():
    return remove_from_interval(2,6,[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}]

def remove_type(type, l1):
    '''

    :param type: a string containing the type of the transaction : in the account or out from the account
    :param transactions: the list of dictionaries storing the transactions
    :return: the function returns the list from which all the transactions that are of the type given have been removed
    '''
    l = 0
    for i in range(len(l1) - l):
        if l1[i]["type"] == type:
            l = l + 1
    for i in range(len(l1) - l):
        if l1[i]["type"] == type:
            del l1[i]
    return l1

def test_remove_type():
    return remove_type("in",[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}]

def replace_amount(day, type, description, value, l1):
    '''

    :param day: a positive integer which represents the day where the transactions will be modified
    :param type: the type of the transaction: in the account or out from the account
    :param description: a string that contains a detail regarding the transaction that will be replaced
    :param value: a positive integer representing the value that will to be added to the transaction
    :param transactions: the list of dictionaries storing the transactions
    :return: the function returns the modified list
    '''
    for i in range(len(l1)):
        if int(day)==int(l1[i]["day"]):
            if type==l1[i]["type"]:
                if description==l1[i]["description"]:
                    l1[i]["value"]=int(value)
    return l1

def test_replace():
    return replace_amount(13,"in","pizza",1000,[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}])==[{"day":13, "value": 200, "type":"in", "description":"pizza"},{"day":3, "value": 30, "type":"in", "description":"drinks"}]

#C
def display_trans(l1):
    '''

    :param transactions: the list of dictionaries containing the transactions
    :return: the function displays all the transactions
    '''
    return l1

def display_in(type, l1):
    '''

    :param transactions: the list of dictionaries containing the transactions
    :return: the function displays the transactions that have taken place in the account
    '''
    new_list=[]
    for i in range(len(l1)):
        if l1[i]["type"]==type:
            new_list.append(l1[i])
    return new_list

def display_trans_if_condition(operator, value, l1):
    '''

    :param value: a positive integer representing an amount of money
    :param transactions: the list of dictionaries containing the transactions
    :return: the function returns the transactions that have the amount of money according to the condition
    '''
    new_list=[]
    for i in range(len(l1)):
        if operator==">":
            if int(l1[i]["value"])>int(value):
                new_list.append(l1[i])
        elif operator=="<":
            if int(l1[i]["value"])<int(value):
                new_list.append(l1[i])
        elif operator=="=":
            if int(l1[i]["value"]==value):
                new_list.append(l1[i])
    return new_list

def display_balance(day, l1):
    '''

    :param day: an integer number representing the day from where the balance will be computed
    :param transactions: the list of dictionaries containing the transactions
    :return: the function will return the balance at the end of the given day
    '''
    sum_out=0
    sum_in=0
    for i in range(len(l1)):
        if int(l1[i]["day"])<int(day) or int(l1[i]["day"])==int(day):
            if l1[i]["type"]=="in":
                sum_in=sum_in+l1[i]["value"]
            else:
                sum_out=sum_out+l1[i]["value"]
    return sum_in-sum_out

#D
def filter_type(type, l1):
    '''

    :param type: the type of the transaction: in the account or out from the account
    :param transactions: the list of dictionaries containing the transactions
    :return: the function will return the list only with the transactions belonging to the given type
    '''
    l=0
    for i in range(len(l1)):
        if l1[i]["type"] != type:
            l=l+1
    for i in range(len(l1)-l):
        if l1[i]["type"]!=type:
            del l1[i]
    return l1

def filter_by_value(type, value, l1):
    '''

    :param type: the type of the transaction: in the account or out from the account
    :param value: a positive integer representing an amount of money by which the list will be filtered
    :param transactions: the list of dictionaries containing the transactions
    :return: the function will return the list only with the transactions belonging to the given type and smaller than the given value
    '''
    l=0
    for i in range(len(l1)):
        if l1[i]["type"] != type and int(l1[i]["value"]) >= int(value):
            l=l+1
    for i in range(len(l1)-l):
        if l1[i]["type"]!=type and int(l1[i]["value"])>=int(value):
            del l1[i]
    return l1

