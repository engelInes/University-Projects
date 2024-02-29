package model.programState;

import exceptions.*;
import model.stmt.IStmt;
import model.utils.*;
import model.values.IValue;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.Buffer;
import java.util.HashMap;
import java.util.List;

public class ProgramState {
    private MyIStack<IStmt> exeStack;
    private MyIDictionary<String, IValue> symTable;
    private MyIList<IValue> output;
    private MyIDictionary<String, BufferedReader> fileTable;
    private MyIHeap heapTable;
    private IStmt originalProgram;
    private int id;
    private static int lastId=0;
    public ProgramState(MyIStack<IStmt> s, MyIDictionary<String, IValue> symT, MyIList<IValue> l, MyIDictionary<String, BufferedReader> fileT, MyIHeap h, IStmt prg)
    {
        this.exeStack=s;
        this.symTable=symT;
        this.output=l;
        this.fileTable=fileT;
        this.heapTable = h;

        //this.originalProgram=deepCopy(prg);
        this.exeStack.push(prg);
        this.id=setId();
    }

    public MyIStack<IStmt> getExeStack(){return this.exeStack;}

    public void setExeStack(MyIStack<IStmt> st){this.exeStack=st;}
    public MyIDictionary<String,IValue> getSymbolTable(){return this.symTable;}
    public void setSymTable(MyIDictionary<String,IValue> d){this.symTable=d;}
    public MyIList<IValue> getOutput(){return this.output;}
    public void setOutput(MyIList<IValue> l){this.output=l;}
    public MyIDictionary<String,BufferedReader> getFileTable(){return this.fileTable;}
    public void setFileTable(MyIDictionary<String,BufferedReader> f){this.fileTable=f;}

    public MyIHeap getHeapTable(){return this.heapTable;}
    public void  setHeapTable(MyIHeap newHeap){this.heapTable = newHeap;}

    public IStmt getOriginalProgram(){return this.originalProgram;}
    public void setOriginalProgram(IStmt newPrg){this.originalProgram=newPrg;}

    //FOR PRINTING IN FILE
    public String stackToString()
    {
        StringBuilder exeStackString= new StringBuilder();
        List<IStmt> stackToList= exeStack.getReverse();
        for(IStmt elem: stackToList)
            exeStackString.append(elem.toString()).append("\n");

        return exeStackString.toString();
    }


    public String dictionarySymTblToString()
    {
        StringBuilder dictionaryToString = new StringBuilder();
        for(String key : symTable.keySet())
            dictionaryToString.append(String.format("%s -> %s\n",key, symTable.lookup(key).toString()));
        return dictionaryToString.toString();
    }

    public String listToString()
    {
        StringBuilder listToString = new StringBuilder();
        for(IValue elem: this.output.getList())
            listToString.append(String.format("%s\n",elem.toString()));

        return listToString.toString();
    }

    public String dictionaryFileTableToString()
    {
        StringBuilder dictionaryToString = new StringBuilder();
        for(String key: this.fileTable.keySet())
            dictionaryToString.append(String.format("%s\n",key));

        return dictionaryToString.toString();
    }

    public String dictionaryHeapTableToString() throws HeapException {
        StringBuilder dictionaryToString = new StringBuilder();
        for(int key: this.heapTable.keySet())
            dictionaryToString.append(String.format("%s -> %s\n", key, heapTable.get(key)));

        return dictionaryToString.toString();
    }


    public String programStateToStringFile() throws HeapException {
        return "Id: "+ id +"\nExeStack: \n" + this.stackToString() + "\nSymbol Table: \n" + this.dictionarySymTblToString() + "\nOutput List: \n" + this.listToString()+"\nFile Table: \n" + this.dictionaryFileTableToString()+"\nHeap Table: \n" + this.dictionaryHeapTableToString() +"\nEND\n";
    }

    public String toString() {
        return "ProgramState{" +
                "Id: "+ id+
                "exeStack=" + exeStack +
                ", symTable=" + symTable +
                ", output=" + output +
                ", fileTable=" + fileTable +
                ", heapTable=" + heapTable +
                ", originalProgram=" + originalProgram +
                '}';
    }

    public Boolean isNotCompleted(){
        if(exeStack.isEmpty()){
            return false;
        }
        return true;
    }
    public ProgramState executeOneStep() throws IOException, StatementExecutionException, ExpressionEvaluationException, DivisionByZero, StackException, DictionaryException, HeapException {

        if(exeStack.isEmpty())
            throw new StackException("Stack is empty, no more statements!");

        IStmt currentStmt = exeStack.pop();
        return currentStmt.execute(this);
    }
    public synchronized int setId(){
        lastId++;
        return lastId;
    }
    public ProgramState(MyIStack<IStmt> stack, MyIDictionary<String,IValue> symTbl,MyIList<IValue> out, MyIDictionary<String,BufferedReader>fileTbl,MyIHeap heap){
        exeStack=stack;
        symTable=symTbl;
        output=out;
        fileTable=fileTbl;
        heapTable=heap;
    }
}
