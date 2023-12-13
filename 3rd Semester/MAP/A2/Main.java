import Controller.Controller;
import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Repository.*;
import View.View;
public class Main {
    public static void main(String[] args) throws ADTException, StatementExecutionException, ExpressionEvaluationException {
        Repo repo=new Repo();
        Controller controller=new Controller(repo);
        View view=new View(controller);
        view.mainMenu();
    }
}