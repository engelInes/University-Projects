package Model.Statement;

import Model.ProgramState.PrgState;

//no operation is executed
//if we have a nop in stack we simply pop it and everything remains the same
public class NOP implements IStmt{
    public NOP(){}
    @Override
    public PrgState execute(PrgState state){
        return state;
    }

    @Override
    public IStmt deepCopy() {
        return new NOP();
    }

    @Override
    public String toString() {
        return "NopStatement";
    }
}
