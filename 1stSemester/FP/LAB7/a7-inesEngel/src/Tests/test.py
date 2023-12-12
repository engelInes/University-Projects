from src.Domain.entities import Expense
from src.Repository.expenses_repository import GenericRepository
from src.Services.expenses_service import Services
from src.Repository.file_repository import FileExpensesRepository
from src.Repository.binary_repo import BinaryRepository


class Test:

    def test_add_generic(self):
        day = 12
        amount = 300
        type = "flight ticket"
        expense = Expense(day, amount, type)
        generic_repo = GenericRepository()
        generic_repo._save(expense)
        total_list = generic_repo.print_all()
        try:
            assert expense.get_day() > 0
            assert expense.get_day() < 31
            assert expense.get_amount() == int(expense.get_amount())
            assert total_list[-1] == expense
        except:
            print("Incorrect")

    def test_add_file(self):
        test_file = r'C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.txt'
        open(r'C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.txt', 'w').close()
        repo = FileExpensesRepository(test_file)
        assert len(repo.print_all()) == 0
        expense = Expense(12, 300, "flight ticket")
        repo.add_expense(expense)
        assert len(repo.print_all()) == 1

    def test_add_bin(self):
        test_file = r"C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.bin"
        open(r"C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.bin", "w").close()
        binary_repo = BinaryRepository(test_file)
        assert len(binary_repo.print_all())==0
        expense=Expense(3,2,"hotdog")
        binary_repo._save(expense)
        assert len(binary_repo.print_all())==1

    def test_add_mem_service(self):
        service = Services(GenericRepository, "memory")
        expense = Expense(12, 45, "books")
        service.add_expense(12, 45, "books")
        expenses = service.get_all()
        try:
            expenses[-1] == expense
        except:
            print("The expense wasn't added")

    def test_add_file_service(self):
        service = Services(FileExpensesRepository, "file")
        expense = Expense(12, 45, "books")
        service.add_expense(12, 45, "books")
        expenses = service.get_all()
        try:
            expenses[-1] == expense
        except:
            print("The expense wasn't added")

    def test_add_bin_service(self):
        service = Services(BinaryRepository, "binary")
        expense = Expense(12, 45, "books")
        service.add_expense(12, 45, "books")
        expenses = service.get_all()
        try:
            expenses[-1] == expense
        except:
            print("The expense wasn't added")
