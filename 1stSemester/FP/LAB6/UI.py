from datetime import datetime
import re
from Functions import add_trans
from Functions import insert_trans
from Functions import remove_day
from Functions import remove_from_interval
from Functions import remove_type
from Functions import replace_amount
from Functions import display_trans
from Functions import display_in
from Functions import display_trans_if_condition
from Functions import display_balance
from Functions import filter_type
from Functions import filter_by_value
from Functions import create_stack


def create_dict(day, value, type, description):
    return {"day": day, "value": value, "type": type, "description": description}


def print_menu():
    print('1. add <value> <type> <description>')
    print('2. insert <day> <value> <type> <description>')
    print('3. remove <day>')
    print('4. remove <start day> to <end day>')
    print('5. remove <type>')
    print('6. replace <day> <type> <description> with <value>')
    print('7. list')
    print('8. list <type>')
    print('9. list [ < | = | > ] <value>')
    print('10. list balance <day>')
    print('11. filter <type>')
    print('12. filter <type> <value>')
    print('13. undo ')
    print('14. exit\n')


def split_lower(option):
    for i in range(len(option)):
        option[i] = option[i].lower()
    return option


def menu():
    l1 = []
    stack = []
    l1.append(create_dict(11, 45, "in", "cake"))
    l1.append(create_dict(3, 1000, "in", "pizza"))
    l1.append(create_dict(13, 345, "in", "clothes"))
    l1.append(create_dict(1, 453, "out", "fuel"))
    l1.append(create_dict(20, 415, "in", "burger"))
    l1.append(create_dict(4, 65, "out", "plants"))
    l1.append(create_dict(16, 90, "out", "soap"))
    l1.append(create_dict(21, 30, "out", "makeup"))
    l1.append(create_dict(9, 47, "in", "perfumme"))
    l1.append(create_dict(7, 89, "in", "cake"))
    print(l1)
    while True:
        print_menu()
        option = input("Choose an option: ")
        option = split_lower(option.split())
        is_in_undo = True
        if option[0] == "add" and len(option) == 4:
            # if test_add()==False:
            print(option_add(l1, option))
        elif option[0] == "insert" and len(option) == 5:
            # if test_insert()==False:
            print(option_insert(l1, option))
        elif option[0] == "remove":
            if len(option) == 2:
                if option[1].isdigit():
                    # if test_remove_day()==False:
                    print(option_removeday(l1, option))
                else:
                    # if test_remove_type()==False:
                    option_removetype(l1, option)
            elif option[2] == "to":
                # if test_remove_from_interval()==False:
                option_remove_interval(l1, option)
        elif option[0] == "replace" and len(option) == 6:
            # if test_replace()==False:
            option_replace(l1, option)
        elif option[0] == "list":
            is_in_undo = False
            if len(option) == 2:
                option_list_type(l1, option)
            elif len(option) == 1:
                option_list(l1,option)
            else:
                if option[1] == "balance":
                    option_list_balance(l1, option)
                elif option[1] == ">" or option[1] == "=" or option[1] == "<":
                    option_list_comp(l1, option)
        elif option[0] == "filter":
            if len(option) == 2:
                option_filter_type(l1, option)
            else:
                option_filter_val(l1, option)
        elif option[0] == "undo":
            if len(stack) == 1:
                print("No operations were done before this point")
            else:
                print(undo(stack))
        elif option[0] == "exit":
            print("Program exited")
            break
            is_in_undo = False
        else:
            print("Invalid command")
        if is_in_undo == True:
            create_stack(stack, l1)


def ui_day(day):
    while True:
        try:
            assert day.isdigit()
            assert int(day) > 0 and int(day) < 31
            break
        except:
            print("Insert a natural number")
            print_menu()
    return int(day)


def ui_value(value):
    while True:
        try:
            assert value.isdigit()
            assert int(value) > 0
            break
        except:
            print("Insert a natural number")
            print_menu()
    return int(value)


def ui_type(type):
    while True:
        try:
            assert type == "in" or type == "out"
            break
        except:
            print("Insert an in or out type")
            print_menu()
    return type


def ui_operator(operator):
    while True:
        try:
            assert operator == ">" or operator == "=" or operator == "<"
            break
        except:
            print("Insert one of the operators <,>,=")
            print_menu()
    return str(operator)


def option_add(l1, option):
    value = ui_value(option[1])
    type = ui_type(option[2])
    description = option[3]
    add_trans(datetime.now().day, value, type, description, l1)


def option_insert(l1, option):
    day = ui_day(option[1])
    value = ui_value(option[2])
    type = ui_type(option[3])
    description = option[4]
    insert_trans(day, value, type, description, l1)


def option_removeday(l1, option):
    day = ui_day(option[1])
    remove_day(day, l1)


def option_removetype(l1, option):
    type = ui_type(option[1])
    remove_type(type, l1)


def option_remove_interval(l1, option):
    start_day = ui_day(option[1])
    end_day = ui_day(option[3])
    remove_from_interval(start_day, end_day, l1)


def option_list(l1, option):
    for i in l1:
        print(display_trans(i))


def option_replace(l1, option):
    day = ui_day(option[1])
    type = ui_type(option[2])
    description = option[3]
    value = ui_value(option[5])
    replace_amount(day, type, description, value, l1)


def option_list_type(l1, option):
    type = ui_type(option[1])
    print(*display_in(type, l1), sep='\n')


def option_list_balance(l1, option):
    day = ui_day(option[2])
    print(display_balance(day, l1))


def option_list_comp(l1, option):
    op = ui_operator(option[1])
    value = ui_value(option[2])
    print(*display_trans_if_condition(op, value, l1), sep='\n')


def option_filter_type(l1, option):
    type = ui_type(option[1])
    filter_type(type, l1)


def option_filter_val(l1, option):
    value = ui_value(option[2])
    type = ui_type(option[1])
    filter_by_value(type, value, l1)
