package view;

import controller.Controller;
import exceptions.*;
import model.expressions.ArithmeticExpression;
import model.expressions.LogicalExpression;
import model.expressions.ValueExpression;
import model.expressions.VariableExpression;
import model.programState.ProgramState;
import model.stmt.*;
import model.types.BoolType;
import model.types.IntType;
import model.types.StringType;
import model.utils.ExeStack;
import model.utils.FileTable;
import model.utils.OutputList;
import model.utils.SymbolTable;
import model.values.BoolValue;
import model.values.IValue;
import model.values.IntValue;
import model.values.StringValue;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.util.InputMismatchException;
import java.util.Scanner;

public class View {
    private final Controller controller;
    private int executionOption;

    public View(Controller ctrl)
    {
        this.controller=ctrl;
    }

    public void printMenu()
    {
        System.out.println("1-first example");
        System.out.println("2-second example");
        System.out.println("3-third example");
        System.out.println("4-fourth example");
        System.out.println("5-fifth example(includes reading from file)");
        System.out.println("6-exit");
    }

    public void example1()
    {
        // int v
        // v = 2
        // print v
        IStmt firstProgram = new CompoundStmt(new VarDeclStmt("v", new IntType()),
                new CompoundStmt(new AssignStmt("v",new ValueExpression(new IntValue(2))), new PrintStmt(new VariableExpression("v"))
                )
        );

        ProgramState newProgram = new ProgramState(
                new ExeStack<IStmt>(),
                new SymbolTable<String, IValue>(),
                new OutputList<IValue>(),
                new FileTable<String, BufferedReader>(),
                firstProgram
        );

        controller.addProgram(newProgram);

    }

    public void example2()
    {
        // int a
        // int b
        // a = 2 + 3 * 5
        // b = a + 1
        // print b
        IStmt secondProgram =
                new CompoundStmt(new VarDeclStmt("a",new IntType()),
                        new CompoundStmt(new VarDeclStmt("b",new IntType()),
                                new CompoundStmt(new AssignStmt("a",new ArithmeticExpression("+",new ValueExpression(new IntValue(2)),new ArithmeticExpression("*",new ValueExpression(new IntValue(3)),new ValueExpression(new IntValue(5))))),
                                        new CompoundStmt(new AssignStmt("b",new ArithmeticExpression("+",new VariableExpression("a"), new ValueExpression(new IntValue(1)))), new PrintStmt(new VariableExpression("b"))))
                        )
                );

        ProgramState program = new ProgramState(new ExeStack<IStmt>(), new SymbolTable<String,IValue>(), new OutputList<IValue>(),new FileTable<String,BufferedReader>(),   secondProgram);

        controller.addProgram(program);
    }

    public void example3()
    {
        // bool a
        // int v
        // a = true
        // if a then v = 2 else v = 3
        // print v
        IStmt thirdProgram =
                new CompoundStmt(new VarDeclStmt("a", new BoolType()),
                        new CompoundStmt(new VarDeclStmt("v",new IntType()),
                                new CompoundStmt(new AssignStmt("a", new ValueExpression(new BoolValue(true))),
                                        new CompoundStmt(
                                                new IfStmt(
                                                        new VariableExpression("a"),
                                                        new AssignStmt("v",new ValueExpression(new IntValue(2))),
                                                        new AssignStmt("v",new ValueExpression(new IntValue(3)))
                                                ),
                                                new PrintStmt(new VariableExpression("v"))
                                        )
                                )
                        )
                );

        ProgramState newProgram = new ProgramState(
                new ExeStack<IStmt>(),
                new SymbolTable<String,IValue>(),
                new OutputList<IValue>(),
                new FileTable<String,BufferedReader>(),
                thirdProgram
        );

        controller.addProgram(newProgram);
    }

    public void example4()
    {
        IStmt fourthProgram =
                new CompoundStmt(
                        new VarDeclStmt("a", new IntType()),
                        new CompoundStmt(
                                new VarDeclStmt("b",new IntType()),
                                new CompoundStmt(
                                        new VarDeclStmt("bool1", new BoolType()),
                                        new CompoundStmt(
                                                new VarDeclStmt("bool2", new BoolType()),
                                                new CompoundStmt(
                                                        new AssignStmt("a", new ValueExpression(new IntValue(100))),
                                                        new CompoundStmt(
                                                                new AssignStmt("b", new ValueExpression(new IntValue(100))),
                                                                new CompoundStmt(
                                                                        new AssignStmt("bool1", new ValueExpression(new BoolValue(true))),
                                                                        new CompoundStmt(
                                                                                new AssignStmt("bool2", new ValueExpression(new BoolValue(false))),
                                                                                new CompoundStmt(
                                                                                        new IfStmt(
                                                                                                new LogicalExpression("&&", new VariableExpression("bool1"), new VariableExpression("bool2")),
                                                                                                new AssignStmt("a", new ArithmeticExpression("+", new VariableExpression("a"), new ValueExpression(new IntValue(77)))),
                                                                                                new AssignStmt("b",new ArithmeticExpression("-", new VariableExpression("b"), new ValueExpression(new IntValue(77))))
                                                                                        ),
                                                                                        new CompoundStmt(
                                                                                                new PrintStmt(new VariableExpression("a")),
                                                                                                new PrintStmt(new VariableExpression("b"))
                                                                                        )
                                                                                )
                                                                        )
                                                                )
                                                        )
                                                )
                                        )
                                )
                        )
                );


        ProgramState newProgram = new ProgramState(
                new ExeStack<IStmt>(),
                new SymbolTable<String,IValue>(),
                new OutputList<IValue>(),
                new FileTable<String,BufferedReader>(),
                fourthProgram
        );

        controller.addProgram(newProgram);
    }

    public void example5()
    {

//        IStmt fifthProgram =
//                new CompoundStmt(
//                        new VarDeclStmt("varf", new StringType()),
//                        new CompoundStmt(
//                                new AssignStmt("varf",new ValueExpression(new StringValue("C:\\Users\\Sergiu\\Desktop\\SEM3\\metode_avansate_de_programare\\A3\\A3_interpreter_file\\test.in"))),
//                                new CompoundStmt(
//                                        new OpenReadFileStmt(new VariableExpression("varf")),
//                                        new CompoundStmt(
//                                                new VarDeclStmt("varc", new IntType()),
//                                                new CompoundStmt(
//                                                        new ReadFileStmt(new VariableExpression("varf"),"varc"),
//                                                        new CompoundStmt(
//                                                                new PrintStmt(new VariableExpression("varc")),
//                                                                new CloseReadFileStmt(new VariableExpression("varf"))
//                                                        )
//                                                )
//                                        )
//                                )
//                        )
//                );

        IStmt fifthProgram =
                new CompoundStmt(
                        new VarDeclStmt("varf", new StringType()),
                        new CompoundStmt(
                                new AssignStmt("varf",new ValueExpression(new StringValue("C:\\Users\\Sergiu\\Desktop\\SEM3\\metode_avansate_de_programare\\A3\\A3_interpreter_file\\test.in"))),
                                new CompoundStmt(
                                        new OpenReadFileStmt(new VariableExpression("varf")),
                                        new CompoundStmt(
                                                new VarDeclStmt("varc", new IntType()),
                                                new CompoundStmt(
                                                        new ReadFileStmt(new VariableExpression("varf"),"varc"),
                                                        new CompoundStmt(
                                                                new PrintStmt(new VariableExpression("varc")),
                                                                new CompoundStmt(
                                                                        new ReadFileStmt(new VariableExpression("varf"),"varc"),
                                                                        new CompoundStmt(
                                                                                new PrintStmt(new VariableExpression("varc")),
                                                                                new CloseReadFileStmt(new VariableExpression("varf"))
                                                                        )
                                                                )
                                                        )
                                                )
                                        )
                                        )
                                )
                        );

        ProgramState newProgram = new ProgramState(
                new ExeStack<IStmt>(),
                new SymbolTable<String,IValue>(),
                new OutputList<IValue>(),
                new FileTable<String,BufferedReader>(),
                fifthProgram
        );

        controller.addProgram(newProgram);
    }



    public void runMenu()
    {
        int option;
        Scanner scanner=new Scanner(System.in);

        while(true)
        {
            try {
                System.out.println("1-step by step");
                System.out.println("2-see results after all-steps-execution");
                System.out.println("give execution option: ");
                executionOption=scanner.nextInt();

                printMenu();
                System.out.println("give option number: ");
                option = scanner.nextInt();

                switch (option)
                {
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
                    case 5:
                        this.example5();
                        break;
                    case 6:
                        System.exit(0);
                    default:
                        throw new InvalidInput("Invalid command, use only integers 1 to 5");
                }

                ProgramState program = controller.getCurrentProgram();

                if(executionOption == 2)
                {
                    controller.executeAllSteps();
                    System.out.println(program);
                }
                else
                {
                    System.out.println(program);

                    while(!controller.isEmpty())
                    {
                        controller.executeOneStep(program);
                        System.out.println(program);
                    }
                }

            }catch(InvalidInput | ExpressionEvaluationException | StatementExecutionException | DivisionByZero |
                   StackException | InputMismatchException | IOException | DictionaryException e) {
                System.out.println(e.getMessage());
            }

        }
    }
}
