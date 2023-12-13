package View;

import Controller.Controller;
import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Model.Statement.*;
import Model.Type.BoolType;
import Model.Type.IntType;
import Model.Type.StringType;
import Model.Value.*;
import Model.expression.ArithmeticExpression;
import Model.expression.ValueExpression;
import Model.expression.VariableExpression;
import Repository.IRepo;
import Repository.Repo;
import Model.Utils.*;
import Model.ProgramState.PrgState;

import java.io.BufferedReader;
import java.io.IOException;
import java.util.Objects;
import java.util.Scanner;

public class View {
    private void showMenu(){
        System.out.println("Choose an option: ");
        System.out.println("0. Exit.");
        System.out.println("1. Run the first program");
        System.out.println("2. Run the second program");
        System.out.println("3. Run the third program");
        System.out.println("4. Run the fourth program");
    }

    private void example1() throws ExpressionEvaluationException,ADTException,StatementExecutionException,IOException{
        IStmt ex1= new CompStmt(new VarDecl("v",new IntType()),
                new CompStmt(new AssignStmt(new ValueExpression(new IntValue(2)), "v"), new PrintStmt(new VariableExpression("v"))));

        runProgram(ex1);
    }
    private void example2() throws ExpressionEvaluationException,StatementExecutionException,ADTException,IOException{
        IStmt ex2=new CompStmt(new VarDecl("a",new IntType()),
                new CompStmt(new VarDecl("b",new IntType()),
                        new CompStmt(new AssignStmt(new ArithmeticExpression(new ValueExpression(new IntValue(2)),new ArithmeticExpression(new ValueExpression(new IntValue(3)), new ValueExpression(new IntValue(5)),3),1), "a"),
                                new CompStmt(new AssignStmt(new ArithmeticExpression(new VariableExpression("a"),new ValueExpression(new IntValue(1)),1), "b"),new PrintStmt(new VariableExpression("b")))
                        )));
        runProgram(ex2);
    }
    private void example3() throws StatementExecutionException,ExpressionEvaluationException,ADTException,IOException{
        IStmt ex3 =
                new CompStmt(
                        new VarDecl("a", new BoolType()),
                        new CompStmt(
                                new VarDecl("v", new IntType()),
                                new CompStmt(
                                        new AssignStmt(new ValueExpression(new BoolValue(true)), "a"),
                                        new CompStmt(
                                                new IfStmt(
                                                        new VariableExpression("a"),
                                                        new AssignStmt(new ValueExpression(new IntValue(2)), "v"),
                                                        new AssignStmt(new ValueExpression(new IntValue(3)), "v")
                                                ),
                                                new PrintStmt(
                                                        new VariableExpression("v")
                                                )
                                        )
                                )
                        )
                );
        runProgram(ex3);

    }
    private void example4() throws ExpressionEvaluationException, StatementExecutionException,ADTException,IOException{
        IStmt ex4=new CompStmt(
                new VarDecl("varf", new StringType()),
                new CompStmt(
                        new AssignStmt(new ValueExpression(new StringValue("C:\\Users\\Ines\\IdeaProjects\\A3\\test.in")), "varf"),
                        new CompStmt(
                                new OpenReadFile(new VariableExpression("varf")),
                                new CompStmt(
                                        new VarDecl("varc", new IntType()),
                                        new CompStmt(
                                                new ReadFile(new VariableExpression("varf"),"varc"),
                                                new CompStmt(
                                                        new PrintStmt(new VariableExpression("varc")),
                                                        new CompStmt(
                                                                new ReadFile(new VariableExpression("varf"),"varc"),
                                                                new CompStmt(
                                                                        new PrintStmt(new VariableExpression("varc")),
                                                                        new CloseReadFile(new VariableExpression("varf"))
                                                                )
                                                        )
                                                )
                                        )
                                )
                        )
                )
        );
        runProgram(ex4);
    }
    private void runProgram(IStmt stmt) throws ExpressionEvaluationException, StatementExecutionException, ADTException, IOException {
        IExeStack<IStmt> exeStack=new ExeStack<>();
        ISymTable<String,IValue> symTable=new SymTable<>();
        MyIList<IValue> out=new MyList<>();
        ISymTable<String, BufferedReader> fileTable=new SymTable<>();
        PrgState state=new PrgState(exeStack,symTable,out,fileTable,stmt);

        IRepo repo=new Repo(state,"log.txt");
        Controller controller=new Controller(repo);

        System.out.println("Do you want to display the steps? (y/n)");
        Scanner readOption= new Scanner(System.in);
        String option=readOption.next();
        if(Objects.equals(option,"y")){
            controller.setDisplayFlag(Objects.equals(option,"y"));
            controller.allSteps();
        }
        else{
            controller.setDisplayFlag(Objects.equals(option,"n"));
            controller.oneStep(state);
        }
//        controller.setDisplayFlag(Objects.equals(option,"y"));
//        controller.allSteps();
        System.out.println("Result is" + state.getOut().toString().replace('[', ' ').replace(']', ' '));
    }
    public void mainMenu() throws ExpressionEvaluationException,StatementExecutionException,ADTException,IOException{
        boolean isFinished=false;
        while(!isFinished) {
            try {
                showMenu();
                Scanner readOption=new Scanner(System.in);
                int option=readOption.nextInt();
                switch (option) {
                    case 1:
                        this.example1();
                        break;

                    case 2:
                        this.example2();
                        break;

                    case 3:
                        this.example3();
                        break;
                    case 4:
                        this.example4();
                        break;
                    case 0:
                        return;

                    default:
                        System.out.println("Please choose a valid option!");
                }

            }
            catch (ExpressionEvaluationException | StatementExecutionException e)
            {
                System.out.println(e.getMessage());
            }
        }
    }
}

