package model.stmt;

import exceptions.*;
import model.programState.ProgramState;
import model.utils.ExeStack;
import model.utils.MyIDictionary;
import model.utils.MyIStack;
import model.utils.SymbolTable;
import model.values.IValue;

import java.io.IOException;
import java.util.Map;

public class ForkStmt implements IStmt{

    private final IStmt stmt;

    public ForkStmt(IStmt stmt1){
        stmt=stmt1;
    }

    @Override
    public ProgramState execute(ProgramState state) throws ExpressionEvaluationException, DivisionByZero, StatementExecutionException, IOException, DictionaryException, HeapException {
        MyIStack<IStmt> newStack=new ExeStack<>();
        newStack.push(stmt);
        MyIDictionary<String, IValue> newSymTable=new SymbolTable<>();
        for(Map.Entry<String,IValue> entry:state.getSymbolTable().getContent().entrySet()){
            newSymTable.put(entry.getKey(),entry.getValue().deepcopy());
        }
        return new ProgramState(newStack,newSymTable,state.getOutput(),state.getFileTable(),state.getHeapTable());
    }

    @Override
    public IStmt deepcopy() {
        return new ForkStmt(stmt.deepcopy());
    }

    @Override
    public String toString() {
        return "ForkStmt{" +
                "stmt=" + stmt.toString() +
                '}';
    }
}
