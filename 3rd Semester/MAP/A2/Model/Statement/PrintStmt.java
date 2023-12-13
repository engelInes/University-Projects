package Model.Statement;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Model.ProgramState.PrgState;
import Model.Utils.MyIList;
import Model.Value.IValue;
import Model.expression.IExpression;

//again we pop the first el from the stack
//symtable remains the same
//out will have besides the first out eval(exp)
public class PrintStmt implements IStmt{
    private final IExpression exp;
    public PrintStmt(IExpression expression){
        exp=expression;
    }
    @Override
    public PrgState execute(PrgState state) throws ExpressionEvaluationException, ADTException {
        MyIList<IValue> out=state.getOut();
        out.add(exp.eval(state.getSymTable()));
        //state.setOut(out);
        return state;
    }

    @Override
    public String toString(){
        return "print" + "(" + exp/*.toString()*/+ ")";
    }

}
