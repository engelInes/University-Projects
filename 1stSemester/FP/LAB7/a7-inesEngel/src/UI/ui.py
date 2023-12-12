from src.Services.expenses_service import Services
from src.Domain.entities import Expense
from src.Repository.expenses_repository import GenericRepository
from src.Services.expenses_service import Services
from src.Tests.test import Test

# class UI_Expt(Exception):
#     def __init__(self,msg):
#         self.__msg=msg
#
#     def get_message(self):
#         return self.__msg

class UI:
    def __init__(self, service):
        self._service=service

    def run_menu(self):
        while True:
            print("1. Add an expense")
            print("2. Display the list of expenses")
            print("3. Filter the list by a certain value")
            print("4. Undo the operation")
            print("5. Exit")
            print("\n")
            option=int(input("Choose an option: "))
            if option==1:
                day=input("Enter the day of the expense: ")
                amount=input("Enter the amount of money of the expense: ")
                type=input("Enter the type of the expense: ")
                try:
                    assert int(day)>0
                    assert int(day)<31
                    assert int(amount)>0
                except:
                    print("Please insert a valid number")
                self._service.add_expense(int(day),int(amount),type)
            elif option==2:
                print(self._service.get_all())
            elif option==3:
                value=int(input("Enter a value: "))
                try:
                    assert int(value)>0
                    assert int(value)==value
                except:
                    print("Please insert a valid number")
                self._service.change_by_val(value)
            elif option==4:
                self._service.undo()
            elif option==5:
                print("Program exited")
                return
            else:
                print("Invalid command")
            #la undo

