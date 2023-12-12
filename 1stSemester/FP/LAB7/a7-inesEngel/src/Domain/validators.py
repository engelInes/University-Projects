
class ExpenseValidator:
    def validate_day(self, expense):
        if expense.get_day() == "":
            raise ValueError("day can not be empty")

    def validate_amount(self,expense):
        if expense.get_amount()=="":
            raise ValueError("amount can not be empty")

    def validate_type(self,expense):
        if expense.get_type()=="":
            raise ValueError("type can not be empty")
