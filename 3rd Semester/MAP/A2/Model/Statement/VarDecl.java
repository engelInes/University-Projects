package Model.Statement;

import Exceptions.MyException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;
import Model.Type.IType;
import Model.Type.IntType;
import Model.Utils.ISymTable;
import Model.Value.BoolValue;
import Model.Value.IValue;
import Model.Value.IntValue;

//after execution we pop the first element from the exestack
//then we check if the value is already in the table; if it is not then we add it
//!! defaultValue for int and bool
public class VarDecl implements IStmt{
    private final String name;
    private final IType type;
    public VarDecl(String n, IType t){
        name=n;
        type=t;
    }
    @Override
    public PrgState execute(PrgState state) throws StatementExecutionException {
        ISymTable<String, IValue> symTable=state.getSymTable();
        if(symTable.isDefined(name)){
            throw new StatementExecutionException("Variable " + name + " already exists in the symTable.");
        }
        if(type.equals(new IntType())){
            symTable.put(name,new IntValue(0));
        }
        else{
            symTable.put(name, new BoolValue(false));
        }
        return state;
    }

    @Override
    public String toString() {
        return "(" +  name + " " + type +
                ")";
    }
}
