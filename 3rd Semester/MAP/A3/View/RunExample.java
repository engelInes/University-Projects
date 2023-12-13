package View;

import Controller.Controller;
import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;

import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

public class RunExample extends Command{
    private final Controller controller;
    public RunExample(String key, String description, Controller contr){
        super(key,description);
        controller=contr;
    }
    @Override
    public void execute() {
        try{
            System.out.println("Do you want to display the steps? (y/n");
            Scanner readOption=new Scanner(System.in);
            String option=readOption.next();
            controller.setDisplayFlag(Objects.equals(option,"y"));
            controller.allSteps();
        }catch (ExpressionEvaluationException| ADTException| StatementExecutionException| IOException e){
            System.out.println("\u001B[31m" + e.getMessage() + "\u001B[0m");
        }
    }
}
