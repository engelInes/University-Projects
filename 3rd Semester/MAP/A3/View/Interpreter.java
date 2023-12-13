package View;

import Controller.Controller;
import Model.ProgramState.PrgState;
import Model.Statement.*;
import Model.Type.BoolType;
import Model.Type.IntType;
import Model.Utils.*;
import Model.Value.BoolValue;
import Model.Value.IValue;
import Model.Value.IntValue;
import Model.expression.ArithmeticExpression;
import Model.expression.ValueExpression;
import Model.expression.VariableExpression;
import Repository.IRepo;
import Repository.Repo;

import java.io.BufferedReader;

public class Interpreter {
    public static void main(String[] args){
        IStmt ex1= new CompStmt(new VarDecl("v",new IntType()),
                new CompStmt(new AssignStmt(new ValueExpression(new IntValue(2)), "v"), new PrintStmt(new VariableExpression("v"))));
        IExeStack<IStmt> stk = new ExeStack<>();
        ISymTable<String, IValue> symtbl =new SymTable<>();
        MyIList<IValue> out = new MyList<>();
        ISymTable<String, BufferedReader> texttbl =new SymTable<>();
        PrgState prg1= new PrgState(stk,symtbl,out,texttbl,ex1);
        IRepo repo1=new Repo(prg1,"log1.txt");
        Controller contr1=new Controller(repo1);

        IStmt ex2=new CompStmt(new VarDecl("a",new IntType()),
                new CompStmt(new VarDecl("b",new IntType()),
                        new CompStmt(new AssignStmt(new ArithmeticExpression(new ValueExpression(new IntValue(2)),new ArithmeticExpression(new ValueExpression(new IntValue(3)), new ValueExpression(new IntValue(5)),3),1), "a"),
                                new CompStmt(new AssignStmt(new ArithmeticExpression(new VariableExpression("a"),new ValueExpression(new IntValue(1)),1), "b"),new PrintStmt(new VariableExpression("b")))
                        )));
        IExeStack<IStmt> stk2 = new ExeStack<>();
        ISymTable<String, IValue> symtbl2 =new SymTable<>();
        MyIList<IValue> out2 = new MyList<>();
        ISymTable<String, BufferedReader> texttbl2 =new SymTable<>();
        PrgState prg2= new PrgState(stk2,symtbl2,out2,texttbl2,ex2);
        IRepo repo2=new Repo(prg2,"log2.txt");
        Controller contr2=new Controller(repo2);

        IStmt ex3=
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
        IExeStack<IStmt> stk3 = new ExeStack<>();
        ISymTable<String, IValue> symtbl3 =new SymTable<>();
        MyIList<IValue> out3 = new MyList<>();
        ISymTable<String, BufferedReader> texttbl3 =new SymTable<>();
        PrgState prg3= new PrgState(stk3,symtbl3,out3,texttbl3,ex3);
        IRepo repo3=new Repo(prg3,"log3.txt");
        Controller contr3=new Controller(repo3);

        TextMenu menu=new TextMenu();
        menu.addCommand(new ExitCommand("0","exit"));
        menu.addCommand(new RunExample("1", ex1.toString(), contr1));
        menu.addCommand(new RunExample("2", ex2.toString(), contr2));
        menu.addCommand(new RunExample("3", ex3.toString(), contr3));
        menu.show();
    }
}
