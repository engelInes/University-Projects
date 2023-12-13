package Model.Statement;

import Model.ProgramState.PrgState;
import Model.Utils.*;

public class CompStmt implements IStmt{
    //if i have on the stack a compound statement it is written like this: s1;s2| s3..
    //after execution it is distributed in 2 separate statements like s1|s2|s3..
    //symtable out are the same
    private final IStmt first;
    private final IStmt snd;
    public CompStmt(IStmt firsts, IStmt seconds){
        first=firsts;
        snd=seconds;
    }
    @Override
    public PrgState execute(PrgState state) {
        IExeStack<IStmt> stk=state.getStck();
        stk.push(snd);
        stk.push(first);
        return state;
    }

    @Override
    public IStmt deepCopy() {
        return new CompStmt(first.deepCopy(),snd.deepCopy());
    }

    @Override
    public String toString(){
        return "(" + first.toString() + ";" + snd.toString() + ")";
    }
}
