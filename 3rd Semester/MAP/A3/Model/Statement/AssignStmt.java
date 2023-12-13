package Model.Statement;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;
import Model.Utils.ISymTable;
import Model.Value.IValue;
import Model.expression.IExpression;
import Model.Type.*;

//after the execution we remove the top element(assignstmt) of the stack
//output is the same
//for symtable:
//we need some methods
//Eval(Exp)
//IsVarDef(SymTable, Id) checks whether the id is in the table returns true or false
//Update(SymTable1, Id, Val1)-update the value found on id with val1
//GetType(Eval(exp))-get the type of an expression
//GetType(SymTable1, Id)
public class AssignStmt implements IStmt{
    private final IExpression exp;
    private final String id;
    public AssignStmt(IExpression expression,String key){
        exp=expression;
        id=key;
    }
    @Override
    public String toString(){
        return "(" + id+ "=" +exp.toString() + ")";
    }
    @Override
    public PrgState execute(PrgState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException {
        ISymTable<String, IValue> symTbl= state.getSymTable();
        if (symTbl.isDefined(id)){
            IValue val = exp.eval(symTbl);
            IType typeId= (symTbl.lookup(id)).getType();
            if (val.getType().equals(typeId)){
                symTbl.update(id, val);
            }else
            {
                throw new StatementExecutionException("declared type of variable"+id+" and type of the assigned expression do not match");
            }
        }
        else throw new StatementExecutionException("the used variable" +id + " was not declared before");
        return state;
    }

    @Override
    public IStmt deepCopy() {
        return new AssignStmt(exp.deepCopy(),id);
    }
}
