package Model.Statement;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;
import Model.Type.BoolType;
import Model.Utils.IExeStack;
import Model.Value.BoolValue;
import Model.Value.IValue;
import Model.expression.IExpression;

//raise an error if the condition is not type bool
//Cond= Eval(Exp
//if getType(Cond)!=bool) error "conditional expr is not a boolean"
//else
// if Cond ==True ExeStack2={Stmt1|Stmt3|...} else ExeStack2={Stmt2|Stmt3|...}
//if the condition is true then push on the stack the first case otherwise the second
//symtable and output remain the same

public class IfStmt implements IStmt{
    private final IExpression exp;
    private final IStmt thenStmt;
    private final IStmt elseStmt;
    public IfStmt(IExpression e, IStmt t, IStmt el){
        exp=e;
        thenStmt=t;
        elseStmt=el;
    }
    @Override
    public String toString(){
        return "(IF(" + exp.toString() + ")" + "THEN(" + thenStmt.toString() + ")" + "ELSE(" + elseStmt.toString() + "))";
    }
    @Override
    public PrgState execute(PrgState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException {
        IExeStack<IStmt> stack= state.getStck();
        IValue result=exp.eval(state.getSymTable());
        BoolValue condVal;

        if(!result.getType().equals(new BoolType())) {
            throw new ExpressionEvaluationException("Conditional expression must be boolean!");
        }

        condVal=(BoolValue) result;

        if(condVal.getVal())
            stack.push(thenStmt);
        else{
            stack.push(elseStmt);
        }
        return state;
    }

    @Override
    public IStmt deepCopy() {
        return new IfStmt(exp.deepCopy(), thenStmt.deepCopy(), elseStmt.deepCopy());
    }
}
