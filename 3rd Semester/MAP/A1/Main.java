import Controller.Controller;
import Exceptions.MyException;
import Repository.Repo;
import view.View;

public class Main {
    public static void main(String[] args) throws MyException {
        Repo repository=new Repo(100);
        Controller controller=new Controller(repository);
        View ui=new View(controller);
        ui.runMenu();
    }
}