package Model.ProgramState;

import Model.Statement.IStmt;
import Model.Utils.IExeStack;
import Model.Utils.ISymTable;
import Model.Utils.MyIList;
import Model.Value.IValue;

public class PrgState {
    private IExeStack<IStmt> stck;
    private ISymTable<String, IValue> symTable;
    private MyIList<IValue> out;
    //private IStmt originalProgram; //optional but should try to have it

    public PrgState(IExeStack<IStmt> s, ISymTable<String, IValue> st, MyIList<IValue> l, IStmt prg){
        stck=s;
        symTable=st;
        out=l;
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

    public void setOut(MyIList<IValue> out) {
        this.out = out;
    }

    public void setStck(IExeStack<IStmt> stck) {
        this.stck = stck;
    }

    public void setSymTable(ISymTable<String, IValue> symTable) {
        this.symTable = symTable;
    }

    @Override
    public String toString() {
        return "Execution stack: \n" + stck/*.getReverse()*/ + "\nSymbol table: \n" + symTable/*.toString()*/ + "\nOutput list: \n" + out/*.toString()*/ + "\n";
    }
}
