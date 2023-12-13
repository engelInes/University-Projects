package Model.ProgramState;

import Exceptions.ADTException;
import Model.Statement.IStmt;
import Model.Utils.IExeStack;
import Model.Utils.ISymTable;
import Model.Utils.MyIList;
import Model.Value.IValue;

import java.io.BufferedReader;
import java.util.List;

public class PrgState {
    private IExeStack<IStmt> stck;
    private ISymTable<String, IValue> symTable;
    private MyIList<IValue> out;
    private ISymTable<String, BufferedReader> fileTable;
    //private IStmt originalProgram; //optional but should try to have it

    public PrgState(IExeStack<IStmt> s, ISymTable<String, IValue> st, MyIList<IValue> l, ISymTable<String, BufferedReader> ft, IStmt prg){
        stck=s;
        symTable=st;
        out=l;
        fileTable=ft;
        //originalProgram=deepCopy(prg);
        stck.push(prg);
    }

    /*private IStmt deepCopy(IStmt prg) {
    }*/


    public IExeStack<IStmt> getStck() {
        return stck;
    }

    public ISymTable<String, IValue> getSymTable() {
        return symTable;
    }

//    public IStmt getOriginalProgram() {
//        return originalProgram;
//    }

    public MyIList<IValue> getOut() {
        return out;
    }

//    public void setOriginalProgram(IStmt originalProgram) {
//        this.originalProgram = originalProgram;
//    }
    public ISymTable<String, BufferedReader> getFileTable(){
        return fileTable;
    }

    public void setOut(MyIList<IValue> out) {
        this.out = out;
    }

    public void setStck(IExeStack<IStmt> stck) {
        this.stck = stck;
    }

    public void setSymTable(ISymTable<String, IValue> symTable) {
        this.symTable = symTable;
    }
    public void setFileTable(ISymTable<String,BufferedReader> newFileTable){fileTable=newFileTable;}

    @Override
    public String toString() {
        return "Execution stack: \n" + stck/*.getReverse()*/ + "\nSymbol table: \n" + symTable/*.toString()*/ + "\nOutput list: \n" + out/*.toString()*/ + "\n";
    }
    public String exeStackToString() {
        StringBuilder exeStackStringBuilder = new StringBuilder();
        List<IStmt> stack = stck.getReverse();
        for (IStmt statement: stack) {
            exeStackStringBuilder.append(statement.toString()).append("\n");
        }
        return exeStackStringBuilder.toString();
    }

    public String symTableToString() throws ADTException {
        StringBuilder symTableStringBuilder = new StringBuilder();
        for (String key: symTable.keySet()) {
            symTableStringBuilder.append(String.format("%s -> %s\n", key, symTable.lookup(key).toString()));
        }
        return symTableStringBuilder.toString();
    }

    public String outToString() {
        StringBuilder outStringBuilder = new StringBuilder();
        for (IValue elem: out.getList()) {
            outStringBuilder.append(String.format("%s\n", elem.toString()));
        }
        return outStringBuilder.toString();
    }

    public String fileTableToString() {
        StringBuilder fileTableStringBuilder = new StringBuilder();
        for (String key: fileTable.keySet()) {
            fileTableStringBuilder.append(String.format("%s\n", key));
        }
        return fileTableStringBuilder.toString();
    }
    public String programStateToString() throws ADTException {
        return "Execution stack: \n" + exeStackToString() + "Symbol table: \n" + symTableToString() + "Output list: \n" + outToString() + "File table:\n" + fileTableToString();
    }
}
