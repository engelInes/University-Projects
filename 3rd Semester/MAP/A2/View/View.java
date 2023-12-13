package View;

import Controller.Controller;
import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Exceptions.StatementExecutionException;
import Model.Statement.*;
import Model.Type.BoolType;
import Model.Type.IntType;
import Model.Value.*;
import Model.expression.ArithmeticExpression;
import Model.expression.ValueExpression;
import Model.expression.VariableExpression;
import Repository.IRepo;
import Repository.Repo;
import Model.Utils.*;
import Model.ProgramState.PrgState;

import java.util.Scanner;

public class View {
    private final Controller controller;
    private final Scanner scanner;
    private boolean displayFlag;
    public View(Controller ctr){
        controller=ctr;
        scanner=new Scanner(System.in);
    }
    public void example1(){
        IStmt ex1= new CompStmt(new VarDecl("v",new IntType()),
                new CompStmt(new AssignStmt(new ValueExpression(new IntValue(2)), "v"), new PrintStmt(new VariableExpression("v"))));

        IExeStack<IStmt> stk = new ExeStack<IStmt>();
        ISymTable<String, IValue> symtbl =new SymTable<String,IValue>();
        MyIList<IValue> out = new MyList<IValue>();
        PrgState crtPrgState= new PrgState(stk,symtbl,out,ex1);
//        IRepo repo=new Repo();
//        repo.add(crtPrgState);
//        Controller controller=new Controller(repo);
        controller.addProgram(crtPrgState);
//        try {
//            controller.allSteps();
//        } catch (ExpressionEvaluationException | ADTException | StatementExecutionException e) {
//            throw new RuntimeException(e);
//        };
    }
    public void example2(){
        IStmt secondPrg=new CompStmt(new VarDecl("a",new IntType()),
                    new CompStmt(new VarDecl("b",new IntType()),
                        new CompStmt(new AssignStmt(new ArithmeticExpression(new ValueExpression(new IntValue(2)),new ArithmeticExpression(new ValueExpression(new IntValue(3)), new ValueExpression(new IntValue(5)),3),1), "a"),
                        new CompStmt(new AssignStmt(new ArithmeticExpression(new VariableExpression("a"),new ValueExpression(new IntValue(1)),1), "b"),new PrintStmt(new VariableExpression("b")))
                        )));
        //PrgState program=new PrgState(new ExeStack<>(), new SymTable<>(), new MyList<>(), secondPrg);
        //controller.addProgram(program);
        IExeStack<IStmt> stk = new ExeStack<IStmt>();
        ISymTable<String, IValue> symtbl =new SymTable<String,IValue>();
        MyIList<IValue> out = new MyList<IValue>();
        PrgState crtPrgState= new PrgState(stk,symtbl,out,secondPrg);
        controller.addProgram(crtPrgState);
    }
    public void example3(){
        IStmt thirdProgram =
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
        IExeStack<IStmt> stk = new ExeStack<IStmt>();
        ISymTable<String, IValue> symtbl =new SymTable<String,IValue>();
        MyIList<IValue> out = new MyList<IValue>();
        PrgState crtPrgState= new PrgState(stk,symtbl,out,thirdProgram);
//        IRepo repo=new Repo();
//        repo.add(crtPrgState);
//        Controller controller=new Controller(repo);
        controller.addProgram(crtPrgState);

    }
    private void runProgram() throws ExpressionEvaluationException, StatementExecutionException, ADTException {
        PrgState program=controller.getCurrentProgram();
        if(!displayFlag){
            controller.allSteps();
            System.out.println(program);
            return;
        }
        System.out.println(program);
        while(!controller.isEmpty()){
            controller.oneStep(program);
            System.out.println(program);
        }
    }
    public void mainMenu() throws ExpressionEvaluationException,StatementExecutionException,ADTException{
        String option;
        while(true) {
            try {
                System.out.println("Press 1 to enable display flag, 0 otherwise.");
                option = scanner.nextLine();

                displayFlag = option.equals("1");


                System.out.println("Press 1 for the first example.");
                System.out.println("Press 2 for the second example.");
                System.out.println("Press 3 for the third example.");
                System.out.println("Press 4 to exit.");

                option = scanner.nextLine();

                switch (option) {
                    case "1":
                        this.example1();
                        break;

                    case "2":
                        this.example2();
                        break;

                    case "3":
                        this.example3();
                        break;

                    case "4":
                        return;

                    default:
                        System.out.println("Please choose a valid option!");
                }

                runProgram();
            }

            catch (ExpressionEvaluationException | StatementExecutionException e)
        {
            System.out.println(e.getMessage());
        }
    }
    }
}
//    private void printMenu(){
//        System.out.println("0-exit");
//        //System.out.println("1" + ex1);
//    }
//    private void executeEx1(){
//        //create program state, repo and add initial prgstate to repo and controller
//        MyIStack<IStmt> stk = new MyStack<IStmt>();
//        MyIDictionary<String, Value> symtbl =new MyDictionary<String,Value>();
//        MyIList<Value> out = new MyList<Value>();
//        PrgState crtPrgState= new PrgState(stk,symtbl,out,ex1);
////        where the class MyStack<T1> implements the interface MyIStack<T1>,
////                the class MyDictionary<T2,T3> implements the interface MyIDictionary<T2,T3>, and
////                the class MyList<T4> implements the interface MyIList<T4>
//        IRepo repo=new Repo();
//        repo.add(crtPrgState);
//        Controller controller=new Controller(repo);
//        try {
//            controller.allSteps();
//        }catch (MyException e){
//            System.out.println(e.getMessage());
//        }
//    }
//}
