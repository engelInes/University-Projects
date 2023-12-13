import Controller.Controller;
import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Repository.*;
import View.View;

import java.io.IOException;

public class Main {
    public static void main(String[] args) throws ADTException, StatementExecutionException, ExpressionEvaluationException, IOException {
        View view=new View();
        view.mainMenu();
    }
}