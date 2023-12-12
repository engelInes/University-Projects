from src.Repository.expenses_repository import GenericRepository
from src.Repository.file_repository import FileExpensesRepository
from src.Repository.binary_repo import BinaryRepository
from src.Services.expenses_service import Services
from src.UI.ui import UI

if __name__ == "__main__":
    implementation = "file"
    if implementation == "file":
        repo = FileExpensesRepository(r"C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.txt")
    elif implementation == "memory":
        repo = GenericRepository()
    elif implementation == "binary":
        repo = BinaryRepository(r"C:\Users\Ines\PycharmProjects\a7-inesEngel\src\data.bin")
    service = Services(repo,implementation)
    ui = UI(service)
    ui.run_menu()
